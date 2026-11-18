-- Flujo: aceptación de pedidos por producto y producción independiente del pedido.
-- Ejecutar una sola vez en la base alemanadb (AWS RDS).

-- 1) Columnas de detalle_pedido.
--    Si cantidadDespachada ya existe por el script anterior, omitir esa línea.
ALTER TABLE detalle_pedido
  ADD COLUMN cantidadAceptada INT NOT NULL DEFAULT 0,
  ADD COLUMN cantidadDespachada INT NOT NULL DEFAULT 0;

-- 2) Quitar la FK de ordenproduccion a solicitudpedido.
--    Primero consultar el nombre real de la constraint:
SELECT CONSTRAINT_NAME
  FROM information_schema.KEY_COLUMN_USAGE
 WHERE TABLE_SCHEMA = DATABASE()
   AND TABLE_NAME = 'ordenproduccion'
   AND COLUMN_NAME = 'idPedido'
   AND REFERENCED_TABLE_NAME IS NOT NULL;

--    Con el nombre obtenido (el mapeo EF indica ordenproduccion_ibfk_2):
ALTER TABLE ordenproduccion DROP FOREIGN KEY ordenproduccion_ibfk_2;

-- 3) Quitar la columna. MySQL elimina también el índice idPedido.
ALTER TABLE ordenproduccion DROP COLUMN idPedido;

-- 4) Estado de los pedidos que estaban con el estado anterior.
--    Revisar antes de ejecutar: estos pedidos no tienen cantidadAceptada cargada.
-- UPDATE solicitudpedido SET estadoPedido = 'En produccion' WHERE estadoPedido = 'Despacho parcial';
