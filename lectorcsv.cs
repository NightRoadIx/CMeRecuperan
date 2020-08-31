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
			
			// Escribir todo el contenido del archivo
			Console.WriteLine(archon);
			// Esperar que se presione una tecla 
			Console.Write("Presione una tecla para continuar-->");
			Console.ReadKey(true);
			// Limpiar la consola
			Console.Clear();
			
			// TODO: 
			Console.ReadKey(true);
		}
	}
}