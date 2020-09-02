/*
 * Programa para la lectura de un archivo CSV
 * Los archivos CSV (Comma Separated Values, valores separados por comas) se utilizan mucho para el 
 * intercambio de grandes cantidades de información a través de la web, así como para el análisis de estos datos
 * con la finalidad de hallar patrones o información útil, muy utilizados en ciencia de datos.
 * 
 * En este programa se muestra como leer un archivo CSV desde una URL (Uniform Resource Locator)
 * */
using System;
using System.IO;
using System.Collections.Generic;
using System.Net;	// Paquetería para manejar archivos desde una URL

namespace leetura
{
	class Program
	{
		/* Función para obtener el contenido de un archivo de una URL en formato de cadena de texto */
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
		
		public static void Main(string[] args)
		{
			// TODO: Controlar posibles excepciones
			// Dirección del recurso CSV a tratar
			string destinoURL = "http://samplecsvs.s3.amazonaws.com/SalesJan2009.csv";
			
			// Llamar a la función para obtener un archivo CSV directamente de una URL
			string archon = obtenerCSV(destinoURL);
			
			// UNDONE: Eliminar mostrar el contendio del archivo CSV completo
			// Escribir todo el contenido del archivo
			// Console.WriteLine(archon);
			
			/* * * * */
			// FIXME:	Arreglar esta sección para la lectura de todo el archivo
			//		  	y almacenar los datos
			/* Leer el contenido del archivo línea por línea */
			// Generar una cadena de texto temporal
			string aLine;
			// Crear un objeto StringReader, pasando como argumento al constructor el texto
			StringReader strReader = new StringReader(archon);
			
			// Leer la cadena línea por línea (se entiende que estará delimitada por un '\n')
			aLine = strReader.ReadLine();
			// Escribir en consola
			Console.WriteLine(aLine);
			
			// Generar un arreglo de cadenas de texto
			string [] separada = new string[1];
			// Separamos la línea leída por medio de comas
			separada = aLine.Split(',');
			// Mostramos el elemento [0]
			Console.WriteLine(separada[0]);
			// Mostrar el tamaño del arreglo
			Console.WriteLine(separada.Length);
			
			// UNDONE: Eliminar este ejemplo de lectura de una nueva línea
			//aLine = strReader.ReadLine();
			//Console.WriteLine(aLine);
			
			//Leer completamente el texto
			// TODO: 	Separar el encabezado de los datos
			//			y después, lo que se hará es ingresar los datos a listas
			
			// HACK: Listas de tipo cadena de texto
			// List<string> nombre = new List<string>();
			// Añadir datos a la lista
			// nombre.Add()
			while(true) 
			{
				// Leer línea a línea de la cadena de texto
				aLine = strReader.ReadLine();
				
				// Mientras no se halle el caracter null 
				if(aLine != null)
					Console.WriteLine(aLine);
				else // EOF = End Of File  ---> texto como null
					break;
			}			
			
			// IMPORTANTE: Cerrar el Lector de Cadenas
			strReader.Close();
			
			/* * * * */
			
			// Esperar que se presione una tecla 
			Console.Write("Presione una tecla para continuar-->");
			Console.ReadKey(true);
			// Limpiar la consola
			Console.Clear();
			
			// TODO: Esto se debe de acabar, esta etiqueta será la última que van a quitar
			Console.ReadKey(true);
		}
	}
}