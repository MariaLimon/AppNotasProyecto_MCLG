using System;
using System.Collections.Generic;
using System.Text;
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
				await sender.RelRotateTo(360, 5000, Easing.BounceOut);
			}
			if (activacion == false)
			{
				sender.BackgroundColor = new Label().BackgroundColor;
				sender.Rotation = new Label().Rotation;
			}
		}
	}
}
