using System.ComponentModel;

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


            

        }


        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_Load(object sender, EventArgs e)
        {
            string rutaArchivo = @"..\..\..\consum.csv";

            dataGridView1.DataSource = CSVConverter.ReadCSV(rutaArchivo);
        }
    }
}
