# ShipRateCalculator.Business — Capa de lógica de negocio

Class Library (.NET 8).

Responsabilidad: validar los datos de entrada (peso, país) y calcular el
costo de envío aplicando la tarifa del país correspondiente, obtenida a
través de la capa de datos. No conoce HTML ni SQL: solo reglas de negocio.

Se crea desde Visual Studio como proyecto **Class Library**, apuntando a
**.NET 8**, dentro de esta carpeta. Referencia a `ShipRateCalculator.Domain`
y `ShipRateCalculator.Data`.
