using CsvHelper;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace M03UF5AC3
{
    public class CSVConverter
    {
        public static DataTable ReadCSV(string rutaArchivo)
        {
            DataTable dataTable = new DataTable();

            // Llegeix la primera linea per obtenir el header
            string[] header;
            using (TextFieldParser parser = new TextFieldParser(rutaArchivo))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");
                if (!parser.EndOfData)
                {
                    header = parser.ReadFields();
                }
                else
                {
                    return null; // Si el fitxer està buit, retorna null
                }
            }

            // Afegir les columnes al DataTable
            foreach (string encabezado in header)
            {
                dataTable.Columns.Add(encabezado);
            }

            // Llegir les dades del fitxer i afegir-les al DataTable
            using (TextFieldParser parser = new TextFieldParser(rutaArchivo))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");

                // Ignorar el header
                parser.ReadLine();

                // Llegir les dades
                while (!parser.EndOfData)
                {
                    string[] campos = parser.ReadFields();

                    // Afegeix una fila al DataTable
                    dataTable.Rows.Add(campos);
                }
            }
            return dataTable;
        }


    }
}
