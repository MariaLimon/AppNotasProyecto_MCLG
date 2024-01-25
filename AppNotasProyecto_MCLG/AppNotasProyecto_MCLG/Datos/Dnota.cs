using AppNotasProyecto_MCLG.Conexion;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AppNotasProyecto_MCLG.Modelo;
using Firebase.Database.Query;
using System.Collections.ObjectModel;
using Firebase.Database;
using System.Diagnostics;
using System.Linq;

namespace AppNotasProyecto_MCLG.Datos
{
	public class Dnota
	{
		public async Task InsertarNota(Mnota1 parametros)
		{
			string nuevoIdNota = Guid.NewGuid().ToString();
			await Cconexion.firebase
				.Child("Nota")
				.Child(nuevoIdNota)
				.PostAsync(new Mnota1()
				{

					Titulo = parametros.Titulo,
					Descripcion = parametros.Descripcion,
					idNota = nuevoIdNota
					
				});
		}

		public async Task<ObservableCollection<Mnota1>> MostrarNotas()
		{
			var data = await Task.Run(() => Cconexion.firebase
				.Child("Nota")
				.AsObservable<Mnota1>()
				.AsObservableCollection());
			// .Where(a => a.Nombre !="-"));
			return data;
		}

		public async Task EliminarNota(string notaId)
		{
			try
			{
				var notaAEliminar = (await Cconexion.firebase
					.Child("Nota")
					.OnceAsync<Mnota1>()).Where(p => p.Object.idNota == notaId).FirstOrDefault();

				if (notaAEliminar != null)
				{
					await Cconexion.firebase
						.Child("Nota")
						.Child(notaAEliminar.Key)
						.DeleteAsync();
				}
			}
			catch (Exception ex)
			{
				Debug.WriteLine($"Error al eliminar la nota: {ex.Message}");
			}
		}

		public async Task<bool> ActualizarNota(Mnota1 parametros)
		{
			var pokemonAEditar = (await Cconexion.firebase
				.Child("Nota")
				.OnceAsync<Mnota1>()).Where(p => p.Object.idNota == parametros.idNota).FirstOrDefault();

			if (pokemonAEditar != null)
			{
				await Cconexion.firebase
					.Child("Nota")
					.Child(pokemonAEditar.Key)
					.PutAsync(new Mnota1()
					{
						Titulo = parametros.Titulo,
						Descripcion = parametros.Descripcion,
					});
				return true;
			}
			return false;
		}
	}
}
