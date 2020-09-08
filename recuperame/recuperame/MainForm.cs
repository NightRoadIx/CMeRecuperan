using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Collections.Generic;
using System.Net;	// Paquetería para manejar archivos desde una URL
using System.Linq;	// Paquetería con datos adicionales para el manejo de listas 

namespace recuperame
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		
		// PROPIEDADES DE LA CLASE MAINFORM
		// Donde se guardan los encabezados
		List<string> hutt = new List<string>();
		// Lista con los valores únicos de pago
		List<string> pagos = new List<string>();
		// IEnumerable<string> pagos = new List<string>();
		// Lista para guardar todos los datos
		List<string[]> data = new List<string[]>();		
		
		
		// METODOS DE LA CLASE MAINFORM 
		// Método para obtener los datos de un CSV a partir de una URL
		public static string obtenerCSV(string url)
		{
			// Se crea el pedido de una URL
			HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
			// Aquí es donde se manejará la respuesta que entregue esta URL
			HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
			
			// TODO: Hay que manejar las excepciones que ocurran, sobre todo cuando no exista el archivo o se presente un error de lectura
			// TODO: Generar una rutina para mostrar al usuario que se esta leyendo el archivo
			
			// Depués se crea un "streaming" para la lectura "en directo" del archivo solicitado
			StreamReader sr = new StreamReader(resp.GetResponseStream());
			// Se leerá el archivo hasta el final para asignarlo a una cadena de texto
			string results = sr.ReadToEnd();
			// IMPORTANTE: Cerrar el streaming de lectura
			sr.Close();
			
			return results;
		}		
		
		// Método principal de la ventana
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		void Label1Click(object sender, EventArgs e)
		{
			
		}
		
		// Cuando la ventana se genera o carga
		void MainFormLoad(object sender, EventArgs e)
		{
			
			// Variable temporal
			List<string> tmp = new List<string>();
			
			// Dirección del recurso CSV a tratar
			string destinoURL = "http://samplecsvs.s3.amazonaws.com/SalesJan2009.csv";
			
			// Llamar a la función para obtener un archivo CSV directamente de una URL
			string archon = obtenerCSV(destinoURL);
			
			/* Leer el contenido del archivo línea por línea */
			// Generar una cadena de texto temporal
			string aLine;
			// Un contador temporal
			int j = 0;
			// Crear un objeto StringReader, pasando como argumento al constructor el texto
			StringReader strReader = new StringReader(archon);

			// Recorrer todo el archivo
			while(true) 
			{
				// Leer línea a línea de la cadena de texto
				aLine = strReader.ReadLine();
				
				// Mientras no se halle el caracter null, realizar la lectura
				if(aLine != null)
				{
					// cuando se encuentre la primera línea
					if(j == 0)
					{
						// Recorrer elemento a elemento de la cadena
						// separados por comas
						foreach(string en in aLine.Split(','))
							hutt.Add(en);
					}
					// En otro caso, cuando no sea el encabezado
					// se almacenan todos los datos de la tabla
					else
					{
						data.Add(aLine.Split(','));
						// Aquí se puede añadir los valores del tipo de pago
						tmp.Add(aLine.Split(',')[3]);
					}
				}
				else // EOF = End Of File  ---> texto como null
					break;
				// Incrementar el contador
				j++;
			}			
			
			// IMPORTANTE: Cerrar el Lector de Cadenas
			strReader.Close();
			
			// Generar la lista de pagos con datos únicos (sin repetir)
			pagos = tmp.Distinct().ToList();
			
			// Rellenar el Combobox con los valores obtenidos
			foreach(string a in pagos)
				comboBox1.Items.Add(a);
			// Colocar el primer valor como defecto
			comboBox1.Text = comboBox1.Items[0].ToString();
		}
	}
}
