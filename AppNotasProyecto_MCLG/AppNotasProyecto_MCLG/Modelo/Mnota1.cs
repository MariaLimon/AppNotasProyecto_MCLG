using System;
using System.Collections.Generic;
using System.Text;

namespace AppNotasProyecto_MCLG.Modelo
{
	public class Mnota1
	{
		private static int contadorGlobal = 0;

		public Mnota1()
		{
			contadorGlobal++;
			idNota = contadorGlobal.ToString();
		}
		public string Titulo { get; set; }
		public string Descripcion { get; set; }
		public string idNota { get; set; }

	}
}
