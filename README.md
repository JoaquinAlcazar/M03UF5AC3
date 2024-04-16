# M03 UF5 AC3: GUI EN C#

## Biblografía

-No han sigut requerides consultes a págines web

## IAs Consultades
-GitHub Copilot (autocompletació)

-ChatGPT:

Exemples de prompts utilitzades:


"Hola ChatGPT, soy yo otra vez. Te explico la movida:
Estoy trabajando en una aplicación de Windows Forms, y se requiere que pase los datos de un archivo CSV a un dataGridView de Windows Forms."
//Nota: vaig estar 3 hores a classe intentant-ho pero no sortía res

Resposta:
```
using System;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace TuNombreDeProyecto
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            // Abre el diálogo para seleccionar el archivo CSV
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Archivos CSV (*.csv)|*.csv|Todos los archivos (*.*)|*.*";
            openFileDialog.Title = "Seleccione un archivo CSV";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Lee el archivo CSV seleccionado
                string filePath = openFileDialog.FileName;
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
                    string[] data = lines[i].Split(',');
                    dataTable.Rows.Add(data);
                }

                // Asigna el DataTable al DataGridView
                dataGridView.DataSource = dataTable;
            }
        }
    }
}
```

