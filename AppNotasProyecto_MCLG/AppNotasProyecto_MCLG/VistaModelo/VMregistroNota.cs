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
	public class VMregistroNota : BaseViewModel
	{
		#region VARIABLES
		string _TxtTitulo;
		string _TxtDescripcion;
		#endregion
		#region CONSTRUCTOR
		public VMregistroNota(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion
		#region OBJETOS
		public string TxtTitulo
		{
			get { return _TxtTitulo; }
			set { SetValue(ref _TxtTitulo, value); }
		}
		public string TxtDescripcion
		{
			get { return _TxtDescripcion; }
			set { SetValue(ref _TxtDescripcion, value); }
		}
		#endregion
		#region PROCESOS
		public async Task Volver()
		{
			await Navigation.PopAsync();
		}

		public async Task Insertar()
		{
			var funcion = new Dnota();
			var parametros = new Mnota1();

			parametros.Titulo = TxtTitulo;
			parametros.Descripcion = TxtDescripcion;
			
			await funcion.InsertarNota(parametros);
			await Volver();
		}
		#endregion
		#region COMANDOS
		public ICommand InsertarCommand => new Command(async () => await Insertar());
		public ICommand Volvercommand => new Command(async () => await Volver());
		//public ICommand ProcesoAsyncommand => new Command(async () => await ProcesoAsyncrono());
		//public ICommand ProcesoSimpcommand => new Command(ProcesoSimple);
		#endregion
	}
}
