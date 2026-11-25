-- Normalización del despacho: detalle_despacho pasa a (idDespacho, idProd, cantidad).
-- El producto se obtiene de ordenproduccion.idProducto (antes idProducto era redundante: idProd -> idProducto).
-- FASE DE DESARROLLO: no hay despachos reales, así que se revierten los de prueba y se recrea la estructura.
-- Hacer BACKUP antes. Ejecutar todo junto.

SET SQL_SAFE_UPDATES = 0;
START TRANSACTION;

-- 1) Devolver al stock lo despachado de prueba y reabrir los pedidos
UPDATE productos p
JOIN (SELECT idProducto, SUM(cantidad) AS c FROM detalle_despacho GROUP BY idProducto) x
  ON x.idProducto = p.idProducto
SET p.StockActual = p.StockActual + x.c;

UPDATE detalle_pedido SET cantidadDespachada = 0;
UPDATE solicitudpedido SET fechaReal = NULL
 WHERE estadoPedido IN ('Parcial', 'Completado');
UPDATE solicitudpedido sp SET sp.estadoPedido = 'Aceptado'
 WHERE sp.estadoPedido IN ('Parcial', 'Completado');

DELETE FROM detalle_despacho;
DELETE FROM despacho;

-- 2) Tabla de origen del intento anterior (si existe)
DROP TABLE IF EXISTS despacho_origen;

COMMIT;

-- 3) Nueva estructura (DDL: confirma implícitamente)
ALTER TABLE detalle_despacho DROP FOREIGN KEY detalle_despacho_ibfk_2;
ALTER TABLE detalle_despacho DROP PRIMARY KEY;
ALTER TABLE detalle_despacho DROP COLUMN idProducto;
ALTER TABLE detalle_despacho ADD COLUMN idProd INT NOT NULL AFTER idDespacho;
ALTER TABLE detalle_despacho ADD PRIMARY KEY (idDespacho, idProd);
ALTER TABLE detalle_despacho
  ADD CONSTRAINT detalle_despacho_ibfk_2 FOREIGN KEY (idProd) REFERENCES ordenproduccion (idProd);

SET SQL_SAFE_UPDATES = 1;

-- Control: ninguna orden despachada por encima de lo producido (debe devolver 0 filas)
SELECT o.idProd, o.cantidadAProducir, SUM(dd.cantidad) AS despachado
FROM detalle_despacho dd JOIN ordenproduccion o ON o.idProd = dd.idProd
GROUP BY o.idProd, o.cantidadAProducir
HAVING SUM(dd.cantidad) > o.cantidadAProducir;
