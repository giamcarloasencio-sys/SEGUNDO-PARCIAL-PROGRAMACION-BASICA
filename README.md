# SEGUNDO-PARCIAL-PROGRAMACION-BASICA

Examen_Cafeteria_Giamcarlo

Estudiante: Giamcarlo Asencio Robles

Matrícula: [2025-3103]

Asignatura: Lógica de Programación — Universidad Central del Este

Descripción del programa

Aplicación de escritorio hecha en C# (Windows Forms) para la cafetería "El Buen Sabor". Permite registrar los productos de un pedido en una lista y calcular el total a pagar aplicando descuento, empaque e ITBIS. Todo funciona en un solo formulario (frmPedidos).

Datos de entrada
Cliente, fecha y si es cliente frecuente.
Producto, precio (se digita) y cantidad (1 a 20).
Tamaño (Normal / Grande +RD$25) y porción extra (+RD$30).
Servicio (Consumir en local / Para llevar +RD$20).

Precios de referencia (RD$): Café americano 75, Batida 150, Sándwich 180, Jugo 120, Pastelito 60.

Proceso
Precio unitario = precio digitado + 25 si es grande + 30 si lleva porción extra.
Total de línea = precio unitario × cantidad. Subtotal = suma de las líneas.
Descuento = 10 % del subtotal si el cliente es frecuente.
Empaque = RD$20 una sola vez si el servicio es "Para llevar".
Base imponible = subtotal − descuento + empaque.
ITBIS = 18 % de la base imponible. Total = base imponible + ITBIS.

Validaciones: cliente y producto obligatorios, precio numérico mayor que cero, no se calcula si no hay productos. Al salir se pide confirmación.

Salida

Lista del pedido en columnas y etiquetas con Subtotal, Descuento, Empaque, ITBIS y Total a pagar.

Caso de prueba (María Pérez, cliente frecuente, para llevar): Sándwich 180, cantidad 2, grande = 410; Jugo 120, cantidad 1, porción extra = 150. Subtotal 560.00 · Descuento 56.00 · Empaque 20.00 · Base 524.00 · ITBIS 94.32 · Total RD$ 618.32.

Cómo ejecutarlo

Requiere .NET 8 SDK (o Visual Studio 2022) en Windows.


Capturas de pantalla

<img width="1310" height="732" alt="image" src="https://github.com/user-attachments/assets/f6bbfc3a-72c8-4252-a454-044f59d94e43" />

