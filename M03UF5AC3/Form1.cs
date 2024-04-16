using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Windows.Forms;

namespace M03UF5AC3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            label12.Text = string.Empty;
            label13.Text = string.Empty;
            label14.Text = string.Empty;
            label15.Text = string.Empty;

            // Especifica la ruta del archivo CSV aquí
            string filePath = @"..\..\..\consum.csv";
            CargarDatosDesdeCSV(filePath);

            for (int i = 2012; i <= 2050; i++)
            {
                comboBox1.Items.Add(i.ToString());
            }

            CargarValoresComboBox(filePath);

        }




        private void CargarDatosDesdeCSV(string filePath)
        {
            // Lee el archivo CSV especificado
            string[] lines = File.ReadAllLines(filePath);

            // Crea un DataTable para almacenar los datos
            DataTable dataTable = new DataTable();

            // Suponiendo que la primera línea del archivo CSV contiene los nombres de las columnas
            string[] headers = lines[0].Split(',');
            foreach (string header in headers)
            {
                dataTable.Columns.Add(header);
            }

            // Agrega las filas al DataTable
            for (int i = 1; i < lines.Length; i++)
            {
                string[] data = SplitCSVLine(lines[i]);
                dataTable.Rows.Add(data);
            }

            // Asigna el DataTable al DataGridView
            dataGridView1.DataSource = dataTable;
        }

        private string[] SplitCSVLine(string line)
        {
            var items = new System.Collections.Generic.List<string>();
            int start = 0;
            bool inQuotes = false;

            for (int current = 0; current < line.Length; current++)
            {
                if (line[current] == '"')
                    inQuotes = !inQuotes;

                bool atLastChar = (current == line.Length - 1);
                if (atLastChar)
                {
                    items.Add(line.Substring(start));
                }
                else if (line[current] == ',' && !inQuotes)
                {
                    items.Add(line.Substring(start, current - start));
                    start = current + 1;
                }
            }

            return items.ToArray();
        }

        private void CargarValoresComboBox(string filePath)
        {
            string[] lines = File.ReadAllLines(filePath);

            comboBox2.Items.Clear();

            for (int i = 1; i < lines.Length; i++)
            {
                string[] data = SplitCSVLine(lines[i]);
                if (data.Length > 2)
                {
                    comboBox2.Items.Add(data[2]);
                }
            }
        }


        private void netejarButton_Click(object sender, EventArgs e)
        {
            comboBox1.Text = string.Empty;
            comboBox2.Text = string.Empty;
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
            textBox3.Text = string.Empty;
            textBox4.Text = string.Empty;
            textBox5.Text = string.Empty;
        }

        private void guardarButton_Click(object sender, EventArgs e)
        {
            string any = comboBox1.Text;
            string comarca = comboBox2.Text;
            string poblacio = textBox1.Text;
            string domesticXarxa = textBox2.Text;
            string activitatsEconomiques = textBox3.Text;
            string total = textBox4.Text;
            string consumDomestic = textBox5.Text;

            if (string.IsNullOrEmpty(any) || string.IsNullOrEmpty(comarca) || string.IsNullOrEmpty(poblacio) || string.IsNullOrEmpty(domesticXarxa) || string.IsNullOrEmpty(activitatsEconomiques) || string.IsNullOrEmpty(total) || string.IsNullOrEmpty(consumDomestic))
            {
                MessageBox.Show("Si us plau, emplena tots els camps", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            string filePath = @"..\..\..\consum.csv";
            string lineToAdd = $"{any},22,{comarca},{poblacio},{domesticXarxa},{activitatsEconomiques},{total},{consumDomestic}";
            // Añadir la línea al final del archivo
            using (StreamWriter writer = File.AppendText(filePath))
            {
                writer.WriteLine(lineToAdd);
            }
            
            CargarDatosDesdeCSV(filePath);
        }
    }
}
