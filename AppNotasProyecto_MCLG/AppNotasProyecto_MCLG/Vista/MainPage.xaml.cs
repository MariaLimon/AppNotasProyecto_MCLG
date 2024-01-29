using AppNotasProyecto_MCLG.Datos;
using AppNotasProyecto_MCLG.VistaModelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppNotasProyecto_MCLG
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
			BindingContext = new VMlistanotas(Navigation);
		}
	}
}
