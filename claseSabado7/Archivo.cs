using claseSabado7.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace claseSabado7
{
    public partial class Archivo : Form
    {
        List<Venta> ventas = new List<Venta>();
        public Archivo()
        {
            InitializeComponent();
            agregarVentas();
            inicializarListBox();
            comboBoxMeses();
            comboBoxAnios();
           
        }
        private void agregarVentas()
        {
            ventas.Add(new Venta(2024, 1, "Guatemala", 100000));
            ventas.Add(new Venta(2024, 2, "Guatemala", 80000));
            ventas.Add(new Venta(2024, 3, "Guatemala", 95000));
            ventas.Add(new Venta(2024, 4, "Guatemala", 120000));
            ventas.Add(new Venta(2024, 5, "Guatemala", 100000));
            ventas.Add(new Venta(2024, 6, "Guatemala", 110000));
            ventas.Add(new Venta(2024, 1, "Jutiapa", 50000));
            ventas.Add(new Venta(2024, 2, "Jutiapa", 80000));
            ventas.Add(new Venta(2024, 3, "Jutiapa", 67000));
            ventas.Add(new Venta(2024, 4, "Jutiapa", 55000));
            ventas.Add(new Venta(2024, 5, "Jutiapa", 67000));
            ventas.Add(new Venta(2024, 6, "Jutiapa", 45000));
            ventas.Add(new Venta(2024, 1, "Chiquimula", 43000));
            ventas.Add(new Venta(2024, 2, "Chiquimula", 55000));
            ventas.Add(new Venta(2024, 3, "Chiquimula", 23000));
            ventas.Add(new Venta(2024, 4, "Chiquimula", 34000));
            ventas.Add(new Venta(2024, 5, "Chiquimula", 56000));
            ventas.Add(new Venta(2024, 6, "Chiquimula", 78000));
            ventas.Add(new Venta(2024, 1, "Escuintla", 86000));
            ventas.Add(new Venta(2024, 2, "Escuintla", 75000));
            ventas.Add(new Venta(2024, 3, "Escuintla", 64000));
            ventas.Add(new Venta(2024, 4, "Escuintla", 78000));
            ventas.Add(new Venta(2024, 5, "Escuintla", 79000));
            ventas.Add(new Venta(2024, 6, "Escuintla", 90000));
            ventas.Add(new Venta(2024, 6, "Zacapa", 10000));
        }
        private void mostrarVentas()
        {
            flowLayoutPanel2.Controls.Clear();
            List<Venta> ventasFiltradas = ventas
                .Where(venta => listBox1.SelectedItem == null || listBox1.SelectedItems.Contains(venta.Departamento))
                .Where(venta => venta.Año == (int)comboBox1.SelectedItem) 
                .Where(venta => venta.Mes == comboBox2.SelectedIndex + 1).ToList();

            foreach (Venta venta in ventasFiltradas)
            {
                Label labelVenta = crearEqituetaVenta(venta);
                flowLayoutPanel2.Controls.Add(labelVenta);
            }
        }
        private void inicializarListBox()
        {
            List<string> departamentos = new List<string>();
            foreach (Venta venta in ventas)
            {
                if (!departamentos.Contains(venta.Departamento))
                {
                    departamentos.Add(venta.Departamento);
                }
                foreach (string departamento in departamentos)
                {
                    listBox1.Items.Add(departamento);
                }




            }
        }
        private void comboBoxAnios()
        {
            List<int> anios = new List<int>();
            foreach (Venta venta in ventas)
            {
                if (!anios.Contains(venta.Año))
                {
                    anios.Add(venta.Año);
                }
                foreach (int año in anios)
                {
                    comboBox1.Items.Add(año);
                }
            }
        }
        private void comboBoxMeses()
        {
            List<string> meses = new List<string>();
            foreach (Venta venta in ventas)
            {
                string nombresMeses = obtenerNombreMesPorNumero(venta.Mes);
                if (!meses.Contains(nombresMeses))
                {
                    meses.Add(nombresMeses);
                }
                foreach (string mes in meses)
                {
                    comboBox2.Items.Add(mes);
                }
                comboBox2.SelectedIndex = 0;
            }
        }
        private string obtenerNombreMesPorNumero(int numeroMes)
        {
            string[] meses = { "Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre" };
            return meses[numeroMes - 1];
        }
        private Label crearEqituetaVenta(Venta venta)
        {

            Label labelVenta = new Label();
            string nombreMes = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(venta.Mes);
            labelVenta.Text = $"Año: {venta.Año} \n Mes: {venta.Mes} \n Departamento: {venta.Departamento} \n Ventas: Q.{venta.Precio.ToString("C", CultureInfo.CurrentCulture)}";
            labelVenta.AutoSize = false;
            labelVenta.Size = Size(250, 150);
            labelVenta.Font = new Font("Arial", 12, FontStyle.Bold);
            labelVenta.Padding = new Padding(10);
            labelVenta.Padding = new Padding(10);
            labelVenta.BorderStyle = BorderStyle.FixedSingle;
            labelVenta.Margin = new Padding(10);
            labelVenta.Margin = new Padding(10);
            labelVenta.BackColor = Color.LightGray;
            labelVenta.TextAlign = ContentAlignment.MiddleCenter;
            return labelVenta;
        }

        private Size Size(int v1, int v2)
        {
            throw new NotImplementedException();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            mostrarVentas();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            mostrarVentas();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            mostrarVentas();
        }
    }
}
