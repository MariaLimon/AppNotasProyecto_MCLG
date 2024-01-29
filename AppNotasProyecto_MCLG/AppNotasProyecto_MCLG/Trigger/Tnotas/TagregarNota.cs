using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppNotasProyecto_MCLG.Trigger.Tnotas
{
    public class TagregarNota : TriggerAction<Label>
	{
		public bool activacion { get; set; }
		protected override async void Invoke(Label sender)
		{
			sender.IsVisible = true;

			if (activacion == true)
			{
				sender.BackgroundColor = Color.Green;
				await sender.RelRotateTo(360, 5000, Easing.BounceOut);

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
