-- Aceptar un pedido ahora descuenta el stock en ese momento (antes se descontaba al despachar).
-- Los pedidos ya aceptados y no despachados todavía no descontaron: se ajusta una sola vez.
-- Hacer BACKUP y ejecutar UNA SOLA VEZ, justo al desplegar el cambio.

SET SQL_SAFE_UPDATES = 0;

UPDATE productos p
JOIN (SELECT idProducto, SUM(cantidadAceptada - cantidadDespachada) AS reservado
      FROM detalle_pedido
      WHERE cantidadAceptada > cantidadDespachada
      GROUP BY idProducto) x ON x.idProducto = p.idProducto
SET p.StockActual = p.StockActual - x.reservado;

SET SQL_SAFE_UPDATES = 1;

-- Control: no debería quedar stock negativo (si aparece algo, ese producto aceptó más de lo que hay)
SELECT idProducto, nombre, StockActual FROM productos WHERE StockActual < 0;
