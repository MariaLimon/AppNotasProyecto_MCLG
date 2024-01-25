using System;
using System.Collections.Generic;
using System.Text;
using Firebase.Database;

namespace AppNotasProyecto_MCLG.Conexion
{
	public class Cconexion
	{
		public static FirebaseClient firebase = new FirebaseClient("https://proyectonotasmclg-default-rtdb.firebaseio.com/");
	}
}
