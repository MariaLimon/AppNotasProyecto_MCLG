using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace AppNotasProyecto_MCLG.Trigger
{
    class TeliminarNota
    {
        public class Teliminar : TriggerAction<SwipeView>
        {
			public bool activacion { get; set; }
			protected override async void Invoke(SwipeView sender)
			{
				if (activacion == true)
				{
					sender.BackgroundColor = Color.Red;
					await sender.RelRotateTo(360, 5000, Easing.BounceOut);
				}
				if (activacion == false)
				{
					sender.BackgroundColor = new SwipeView().BackgroundColor;
					sender.Rotation = new SwipeView().Rotation;
				}
			}
		}
    }
}
