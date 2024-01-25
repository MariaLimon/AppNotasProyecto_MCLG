using AppNotasProyecto_MCLG.Modelo;
using AppNotasProyecto_MCLG.VistaModelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppNotasProyecto_MCLG.Vista
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EditarNota : ContentPage
	{
		public EditarNota(Mnota1 parametros)
		{
			InitializeComponent();
			BindingContext = new VMeditarnota(Navigation, parametros);
		}
	}
}