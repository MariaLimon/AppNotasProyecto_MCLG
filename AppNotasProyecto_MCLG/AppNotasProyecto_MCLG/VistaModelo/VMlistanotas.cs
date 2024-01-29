using AppNotasProyecto_MCLG.Datos;
using AppNotasProyecto_MCLG.Modelo;
using AppNotasProyecto_MCLG.Vista;
using MvvmGuia.VistaModelo;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppNotasProyecto_MCLG.VistaModelo
{
	public class VMlistanotas : BaseViewModel
	{
		#region VARIABLES
		string _Texto;
		ObservableCollection<Mnota1> _ListaNotas;
		#endregion
		#region CONSTRUCTOR
		public VMlistanotas(INavigation navigation)
		{
			Navigation = navigation;
			MostrarNotas();
		}
		#endregion
		#region OBJETOS
		public string Texto
		{
			get { return _Texto; }
			set { SetValue(ref _Texto, value); }
		}
		public ObservableCollection<Mnota1> ListaNotas
		{
			get { return _ListaNotas; }
			set
			{
				SetValue(ref _ListaNotas, value);
				OnpropertyChanged();
			}

		}
		#endregion
		#region PROCESOS
		public async Task MostrarNotas()
		{
			var funcion = new Dnota();
			ListaNotas = await funcion.MostrarNotas();
		}
		public async Task IrRegistro()
		{
			await Navigation.PushAsync(new RegistroNotas());
		}

		public async Task ActualizarNota(Mnota1 parametros)
		{
			await Navigation.PushAsync(new EditarNota(parametros));
		}
		public async Task<bool> MostrarMenuEmergente()
		{
			var respuesta = await DisplayAlert("Eliminar nota", "¿Seguro que quiere eliminar esta nota?", "Aceptar", "Cancelar");
			return respuesta;
		}

		bool _activadorAnimacionImg;
		public bool ActivadorAnimacionImg
		{
			get { return _activadorAnimacionImg; }
			set { SetValue(ref _activadorAnimacionImg, value); }
		}

		



		public async Task EliminrNota(Mnota1 notaTitulo)
		{
			bool respuesta = await MostrarMenuEmergente();
			if(respuesta != false)
			{
				ActivadorAnimacionImg = true;
				var dataAccess = new Dnota();
				var notaToDelete = _ListaNotas.FirstOrDefault(p => p.idNota == notaTitulo.idNota);

				if (notaToDelete != null)
				{
					await dataAccess.EliminarNota(notaToDelete.idNota);
					_ListaNotas.Remove(notaToDelete);
				}
				
			}
			else
			{
				//nada
			}
		}

		
		#endregion
		#region COMANDOS
		public ICommand IrRegistrocommand => new Command(async () => await IrRegistro());
		public ICommand EliminarCommand => new Command<Mnota1>(async (p) => await EliminrNota(p));
		public ICommand ActualizarCommand => new Command<Mnota1>(async (p) => await ActualizarNota(p));


		//public ICommand ProcesoAsyncommand => new Command(async () => await ProcesoAsyncrono());
		//public ICommand ProcesoSimpcommand => new Command(ProcesoSimple);
		#endregion
	}
}
