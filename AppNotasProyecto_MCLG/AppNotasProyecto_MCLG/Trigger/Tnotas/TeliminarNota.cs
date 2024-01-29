using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppNotasProyecto_MCLG.Trigger.Tnotas
{
    public class TeliminarNota : TriggerAction<Label>
    {
		public bool activacion { get; set; }
		protected override async void Invoke(Label sender)
		{
			if (activacion == true)
			{	
				sender.BackgroundColor = Color.Red;

				await sender.FadeTo(0.5, 1000, Easing.Linear);

				await Task.Delay(3000);
				sender.IsVisible = false;
			}
			if (activacion == false)
			{
				sender.BackgroundColor = new Label().BackgroundColor;
				sender.Rotation = new Label().Rotation;
			}
		}
	}
}
