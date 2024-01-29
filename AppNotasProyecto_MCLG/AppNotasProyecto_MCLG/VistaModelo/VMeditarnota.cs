using AppNotasProyecto_MCLG.Datos;
using AppNotasProyecto_MCLG.Modelo;
using MvvmGuia.VistaModelo;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppNotasProyecto_MCLG.VistaModelo
{
	public class VMeditarnota : BaseViewModel
	{

		#region VARIABLES
		string _Texto;
		public Mnota1 parametrosRecibe { get; set; }

		#endregion
		#region CONSTRUCTOR
		public VMeditarnota(INavigation navigation, Mnota1 parametros)
		{
			Navigation = navigation;
			parametrosRecibe = parametros;
		}
		#endregion
		#region OBJETOS
		public string Texto
		{
			get { return _Texto; }
			set { SetValue(ref _Texto, value); }
		}
		#endregion
		#region PROCESOS
		public async Task Volver()
		{
			await Navigation.PopAsync();
		}
		bool _activadorAnimacionImgED;
		public bool ActivadorAnimacionImgED
		{
			get { return _activadorAnimacionImgED; }
			set { SetValue(ref _activadorAnimacionImgED, value); }
		}
		public async Task ActualizarNota()
		{

			var notaA = new Mnota1()
			{
				Titulo = parametrosRecibe.Titulo,
				Descripcion = parametrosRecibe.Descripcion,
				idNota = parametrosRecibe.idNota
			};

			var dataAccess = new Dnota();
			await dataAccess.ActualizarNota(notaA);
			ActivadorAnimacionImgED = true;
			await Volver();
		}
		#endregion
		#region COMANDOS
		public ICommand Volvercommand => new Command(async () => await Volver());

		public ICommand ActualizarCommand => new Command(async () => await ActualizarNota());
		#endregion
	}
}
