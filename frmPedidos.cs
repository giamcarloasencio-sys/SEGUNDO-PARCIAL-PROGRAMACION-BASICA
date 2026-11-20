using System;
using System.Drawing;
using System.Windows.Forms;

namespace SEGUNDO_PARCIAL_PROGRAMACION_BASICA
{
    // Formulario unico de la cafeteria "El Buen Sabor".
    // La interfaz se crea aqui mismo con codigo, asi que no hace falta el disenador.
    public class frmPedidos : Form
    {
        // Valores fijos que da el enunciado
        const decimal RECARGO_GRANDE = 25;
        const decimal RECARGO_EXTRA = 30;
        const decimal EMPAQUE = 20;
        const decimal DESCUENTO_FRECUENTE = 0.10m;
        const decimal ITBIS = 0.18m;

        // Aqui voy sumando el total de cada producto que se agrega
        decimal subtotal = 0;

        // Controles del formulario (con los nombres que pide el enunciado)
        TextBox txtCliente;
        TextBox txtProducto;
        TextBox txtPrecio;
        CheckBox chkFrecuente;
        CheckBox chkPorcionExtra;
        DateTimePicker dtpFecha;
        NumericUpDown nudCantidad;
        GroupBox grpTamano;
        GroupBox grpServicio;
        RadioButton rbtNormal;
        RadioButton rbtGrande;
        RadioButton rbtLocal;
        RadioButton rbtLlevar;
        Label lblEncabezado;
        ListBox lstPedido;
        Label lblSubtotal;
        Label lblDescuento;
        Label lblEmpaque;
        Label lblItbis;
        Label lblTotal;
        Button btnAgregar;
        Button btnCalcular;
        Button btnLimpiar;
        Button btnSalir;

        public frmPedidos()
        {
            CrearInterfaz();

            // Conecto los botones con sus metodos
            this.Load += frmPedidos_Load;
            btnAgregar.Click += btnAgregar_Click;
            btnCalcular.Click += btnCalcular_Click;
            btnLimpiar.Click += btnLimpiar_Click;
            btnSalir.Click += btnSalir_Click;
        }

        // ---------------------------------------------------------
        // Dibujo de la interfaz
        // ---------------------------------------------------------
        private void CrearInterfaz()
        {
            this.SuspendLayout();

            // Para que se vea bien aunque la pantalla tenga escalado (125%, 150%...)
            this.AutoScaleDimensions = new SizeF(96F, 96F);
            this.AutoScaleMode = AutoScaleMode.Dpi;

            this.Name = "frmPedidos";
            this.Text = "Cafeteria El Buen Sabor - Pedidos";
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;

            // ----- Lado izquierdo: datos del cliente y del producto -----
            Label lblCliente = new Label();
            lblCliente.Text = "Cliente:";
            lblCliente.Location = new Point(20, 23);
            lblCliente.AutoSize = true;

            txtCliente = new TextBox();
            txtCliente.Name = "txtCliente";
            txtCliente.Location = new Point(100, 20);
            txtCliente.Width = 260;

            chkFrecuente = new CheckBox();
            chkFrecuente.Name = "chkFrecuente";
            chkFrecuente.Text = "Cliente frecuente";
            chkFrecuente.Location = new Point(100, 52);
            chkFrecuente.AutoSize = true;

            Label lblFecha = new Label();
            lblFecha.Text = "Fecha:";
            lblFecha.Location = new Point(20, 87);
            lblFecha.AutoSize = true;

            dtpFecha = new DateTimePicker();
            dtpFecha.Name = "dtpFecha";
            dtpFecha.Location = new Point(100, 84);
            dtpFecha.Width = 260;
            dtpFecha.Format = DateTimePickerFormat.Short;

            Label lblProducto = new Label();
            lblProducto.Text = "Producto:";
            lblProducto.Location = new Point(20, 119);
            lblProducto.AutoSize = true;

            txtProducto = new TextBox();
            txtProducto.Name = "txtProducto";
            txtProducto.Location = new Point(100, 116);
            txtProducto.Width = 260;

            Label lblPrecio = new Label();
            lblPrecio.Text = "Precio:";
            lblPrecio.Location = new Point(20, 151);
            lblPrecio.AutoSize = true;

            txtPrecio = new TextBox();
            txtPrecio.Name = "txtPrecio";
            txtPrecio.Location = new Point(100, 148);
            txtPrecio.Width = 260;

            Label lblCantidad = new Label();
            lblCantidad.Text = "Cantidad:";
            lblCantidad.Location = new Point(20, 183);
            lblCantidad.AutoSize = true;

            nudCantidad = new NumericUpDown();
            nudCantidad.Name = "nudCantidad";
            nudCantidad.Location = new Point(100, 180);
            nudCantidad.Width = 80;
            nudCantidad.Minimum = 1;
            nudCantidad.Maximum = 20;
            nudCantidad.Value = 1;

            // ----- Grupo Tamano -----
            grpTamano = new GroupBox();
            grpTamano.Name = "grpTamano";
            grpTamano.Text = "Tamaño";
            grpTamano.Location = new Point(20, 220);
            grpTamano.Size = new Size(160, 90);

            rbtNormal = new RadioButton();
            rbtNormal.Name = "rbtNormal";
            rbtNormal.Text = "Normal";
            rbtNormal.Location = new Point(12, 25);
            rbtNormal.AutoSize = true;
            rbtNormal.Checked = true;

            rbtGrande = new RadioButton();
            rbtGrande.Name = "rbtGrande";
            rbtGrande.Text = "Grande (+RD$25)";
            rbtGrande.Location = new Point(12, 55);
            rbtGrande.AutoSize = true;

            grpTamano.Controls.Add(rbtNormal);
            grpTamano.Controls.Add(rbtGrande);

            // ----- Grupo Servicio -----
            grpServicio = new GroupBox();
            grpServicio.Name = "grpServicio";
            grpServicio.Text = "Servicio";
            grpServicio.Location = new Point(195, 220);
            grpServicio.Size = new Size(185, 90);

            rbtLocal = new RadioButton();
            rbtLocal.Name = "rbtLocal";
            rbtLocal.Text = "Consumir en local";
            rbtLocal.Location = new Point(12, 25);
            rbtLocal.AutoSize = true;
            rbtLocal.Checked = true;

            rbtLlevar = new RadioButton();
            rbtLlevar.Name = "rbtLlevar";
            rbtLlevar.Text = "Para llevar (+RD$20)";
            rbtLlevar.Location = new Point(12, 55);
            rbtLlevar.AutoSize = true;

            grpServicio.Controls.Add(rbtLocal);
            grpServicio.Controls.Add(rbtLlevar);

            chkPorcionExtra = new CheckBox();
            chkPorcionExtra.Name = "chkPorcionExtra";
            chkPorcionExtra.Text = "Porción extra (+RD$30)";
            chkPorcionExtra.Location = new Point(20, 322);
            chkPorcionExtra.AutoSize = true;

            // ----- Botones de abajo a la izquierda -----
            btnCalcular = new Button();
            btnCalcular.Name = "btnCalcular";
            btnCalcular.Text = "Calcular total";
            btnCalcular.Location = new Point(20, 380);
            btnCalcular.Size = new Size(110, 40);

            btnLimpiar = new Button();
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Text = "Nuevo pedido";
            btnLimpiar.Location = new Point(145, 380);
            btnLimpiar.Size = new Size(110, 40);

            btnSalir = new Button();
            btnSalir.Name = "btnSalir";
            btnSalir.Text = "Salir";
            btnSalir.Location = new Point(270, 380);
            btnSalir.Size = new Size(110, 40);

            // ----- Lado derecho: lista del pedido y resultados -----
            btnAgregar = new Button();
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Text = "Agregar al pedido";
            btnAgregar.Location = new Point(400, 20);
            btnAgregar.Size = new Size(430, 40);

            lblEncabezado = new Label();
            lblEncabezado.Name = "lblEncabezado";
            lblEncabezado.Location = new Point(400, 75);
            lblEncabezado.AutoSize = true;

            lstPedido = new ListBox();
            lstPedido.Name = "lstPedido";
            lstPedido.Location = new Point(400, 98);
            lstPedido.Size = new Size(430, 150);

            Label lblTextoSubtotal = new Label();
            lblTextoSubtotal.Text = "Subtotal";
            lblTextoSubtotal.Location = new Point(400, 268);
            lblTextoSubtotal.AutoSize = true;

            lblSubtotal = CrearEtiquetaResultado("lblSubtotal", 560, 264);

            Label lblTextoDescuento = new Label();
            lblTextoDescuento.Text = "Descuento";
            lblTextoDescuento.Location = new Point(400, 298);
            lblTextoDescuento.AutoSize = true;

            lblDescuento = CrearEtiquetaResultado("lblDescuento", 560, 294);

            Label lblTextoEmpaque = new Label();
            lblTextoEmpaque.Text = "Empaque";
            lblTextoEmpaque.Location = new Point(400, 328);
            lblTextoEmpaque.AutoSize = true;

            lblEmpaque = CrearEtiquetaResultado("lblEmpaque", 560, 324);

            Label lblTextoItbis = new Label();
            lblTextoItbis.Text = "ITBIS (18 %)";
            lblTextoItbis.Location = new Point(400, 358);
            lblTextoItbis.AutoSize = true;

            lblItbis = CrearEtiquetaResultado("lblItbis", 560, 354);

            Label lblTextoTotal = new Label();
            lblTextoTotal.Text = "TOTAL A PAGAR";
            lblTextoTotal.Location = new Point(400, 398);
            lblTextoTotal.AutoSize = true;
            lblTextoTotal.Font = new Font("Segoe UI", 9, FontStyle.Bold);

            lblTotal = CrearEtiquetaResultado("lblTotal", 560, 394);
            lblTotal.Font = new Font("Segoe UI", 9, FontStyle.Bold);

            // Agrego todos los controles al formulario
            this.Controls.Add(lblCliente);
            this.Controls.Add(txtCliente);
            this.Controls.Add(chkFrecuente);
            this.Controls.Add(lblFecha);
            this.Controls.Add(dtpFecha);
            this.Controls.Add(lblProducto);
            this.Controls.Add(txtProducto);
            this.Controls.Add(lblPrecio);
            this.Controls.Add(txtPrecio);
            this.Controls.Add(lblCantidad);
            this.Controls.Add(nudCantidad);
            this.Controls.Add(grpTamano);
            this.Controls.Add(grpServicio);
            this.Controls.Add(chkPorcionExtra);
            this.Controls.Add(btnCalcular);
            this.Controls.Add(btnLimpiar);
            this.Controls.Add(btnSalir);
            this.Controls.Add(btnAgregar);
            this.Controls.Add(lblEncabezado);
            this.Controls.Add(lstPedido);
            this.Controls.Add(lblTextoSubtotal);
            this.Controls.Add(lblSubtotal);
            this.Controls.Add(lblTextoDescuento);
            this.Controls.Add(lblDescuento);
            this.Controls.Add(lblTextoEmpaque);
            this.Controls.Add(lblEmpaque);
            this.Controls.Add(lblTextoItbis);
            this.Controls.Add(lblItbis);
            this.Controls.Add(lblTextoTotal);
            this.Controls.Add(lblTotal);

            this.ClientSize = new Size(860, 450);

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        // Crea una etiqueta con borde para mostrar un resultado
        private Label CrearEtiquetaResultado(string nombre, int x, int y)
        {
            Label etiqueta = new Label();
            etiqueta.Name = nombre;
            etiqueta.Location = new Point(x, y);
            etiqueta.Size = new Size(140, 26);
            etiqueta.BorderStyle = BorderStyle.FixedSingle;
            etiqueta.TextAlign = ContentAlignment.MiddleRight;
            return etiqueta;
        }

        // ---------------------------------------------------------
        // Al abrir el formulario
        // ---------------------------------------------------------
        private void frmPedidos_Load(object sender, EventArgs e)
        {
            // Uso Consolas para que las columnas de la lista queden derechas
            lstPedido.Font = new Font("Consolas", 9);
            lblEncabezado.Font = new Font("Consolas", 9, FontStyle.Bold);

            // Fecha de hoy y opciones por defecto
            dtpFecha.Value = DateTime.Now;
            rbtNormal.Checked = true;
            rbtLocal.Checked = true;
            nudCantidad.Value = 1;

            // Titulos de las columnas, con el mismo ancho que usare en las lineas
            lblEncabezado.Text = "Cant".PadRight(6) + "Producto".PadRight(24)
                               + "Precio".PadLeft(10) + "Total".PadLeft(12);

            PonerResultadosEnCero();
            txtCliente.Focus();
        }

        // ---------------------------------------------------------
        // Boton: Agregar al pedido
        // ---------------------------------------------------------
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            // Primero reviso que los datos esten bien

            if (txtCliente.Text.Trim() == "")
            {
                MessageBox.Show("Escribe el nombre del cliente.");
                txtCliente.Focus();
                return;
            }

            if (txtProducto.Text.Trim() == "")
            {
                MessageBox.Show("Escribe el nombre del producto.");
                txtProducto.Focus();
                return;
            }

            // El precio tiene que ser un numero mayor que cero
            decimal precio;
            if (!decimal.TryParse(txtPrecio.Text, out precio) || precio <= 0)
            {
                MessageBox.Show("El precio tiene que ser un numero mayor que cero.");
                txtPrecio.Focus();
                txtPrecio.SelectAll();
                return;
            }

            // Calculo el precio unitario: el precio digitado mas los extras
            decimal precioUnitario = precio;
            string detalle = "";   // lo que va entre parentesis al lado del producto

            if (rbtGrande.Checked)
            {
                precioUnitario = precioUnitario + RECARGO_GRANDE;
                detalle = "Grande";
            }

            if (chkPorcionExtra.Checked)
            {
                precioUnitario = precioUnitario + RECARGO_EXTRA;
                // si ya era grande, los junto con coma
                if (detalle == "")
                {
                    detalle = "Extra";
                }
                else
                {
                    detalle = detalle + ", Extra";
                }
            }

            // Total de la linea = precio unitario x cantidad
            int cantidad = (int)nudCantidad.Value;
            decimal totalLinea = precioUnitario * cantidad;

            // Armo el nombre, por ejemplo: Sandwich (Grande)
            string nombre = txtProducto.Text.Trim();
            if (detalle != "")
            {
                nombre = nombre + " (" + detalle + ")";
            }

            // Si el nombre es muy largo lo corto para que no se descuadre la lista
            if (nombre.Length > 24)
            {
                nombre = nombre.Substring(0, 24);
            }

            // Armo la linea con las columnas (6, 24, 10 y 12 de ancho)
            string linea = cantidad.ToString().PadRight(6)
                         + nombre.PadRight(24)
                         + precioUnitario.ToString("F2").PadLeft(10)
                         + totalLinea.ToString("F2").PadLeft(12);

            lstPedido.Items.Add(linea);

            // Sumo la linea al subtotal general
            subtotal = subtotal + totalLinea;

            // Dejo los controles del producto listos para el siguiente
            LimpiarProducto();
        }

        // ---------------------------------------------------------
        // Boton: Calcular total
        // ---------------------------------------------------------
        private void btnCalcular_Click(object sender, EventArgs e)
        {
            // Si no hay productos no hay nada que calcular
            if (lstPedido.Items.Count == 0)
            {
                MessageBox.Show("Primero agrega al menos un producto.");
                return;
            }

            // Descuento: 10% del subtotal solo si es cliente frecuente
            decimal descuento = 0;
            if (chkFrecuente.Checked)
            {
                descuento = subtotal * DESCUENTO_FRECUENTE;
            }

            // Empaque: RD$20 una sola vez si el pedido es para llevar
            decimal empaque = 0;
            if (rbtLlevar.Checked)
            {
                empaque = EMPAQUE;
            }

            // Base imponible = subtotal - descuento + empaque
            decimal baseImponible = subtotal - descuento + empaque;

            // El ITBIS es el 18% de la base y el total es base + ITBIS
            decimal itbis = baseImponible * ITBIS;
            decimal total = baseImponible + itbis;

            // Muestro todo en las etiquetas
            lblSubtotal.Text = "RD$ " + subtotal.ToString("F2");
            lblDescuento.Text = "RD$ " + descuento.ToString("F2");
            lblEmpaque.Text = "RD$ " + empaque.ToString("F2");
            lblItbis.Text = "RD$ " + itbis.ToString("F2");
            lblTotal.Text = "RD$ " + total.ToString("F2");
        }

        // ---------------------------------------------------------
        // Boton: Nuevo pedido (limpia todo)
        // ---------------------------------------------------------
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtCliente.Clear();
            chkFrecuente.Checked = false;
            dtpFecha.Value = DateTime.Now;
            rbtLocal.Checked = true;

            lstPedido.Items.Clear();
            subtotal = 0;
            PonerResultadosEnCero();

            LimpiarProducto();

            // El foco termina en el cliente
            txtCliente.Focus();
        }

        // ---------------------------------------------------------
        // Boton: Salir
        // ---------------------------------------------------------
        private void btnSalir_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show("¿Seguro que quieres salir?",
                "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (respuesta == DialogResult.Yes)
            {
                this.Close();
            }
        }

        // ---------------------------------------------------------
        // Metodos de ayuda
        // ---------------------------------------------------------

        // Pone las etiquetas de resultados en RD$ 0.00
        private void PonerResultadosEnCero()
        {
            lblSubtotal.Text = "RD$ 0.00";
            lblDescuento.Text = "RD$ 0.00";
            lblEmpaque.Text = "RD$ 0.00";
            lblItbis.Text = "RD$ 0.00";
            lblTotal.Text = "RD$ 0.00";
        }

        // Reinicia solo los controles del producto
        private void LimpiarProducto()
        {
            txtProducto.Clear();
            txtPrecio.Clear();
            nudCantidad.Value = 1;
            rbtNormal.Checked = true;
            chkPorcionExtra.Checked = false;
            txtProducto.Focus();
        }
    }
}
