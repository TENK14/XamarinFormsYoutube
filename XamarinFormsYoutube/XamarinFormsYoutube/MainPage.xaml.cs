//using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamarinFormsYoutube
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();

			// [1] obsolete
			if (Device.OS == TargetPlatform.iOS)
			{
				Padding = new Thickness(0, 20, 0, 0);
			}
			else if (Device.OS == TargetPlatform.Android)
			{
				Padding = new Thickness(10, 20, 0, 0);
			}
			else if (Device.OS == TargetPlatform.WinPhone)
			{
				Padding = new Thickness(20, 20, 0, 0);
			}

			// [2] obsolete
			//Device.OnPlatform<Thickness>(
			Padding = Device.OnPlatform(
				iOS: new Thickness(0, 20, 0, 0),
				Android: new Thickness(10, 20, 0, 0),
				WinPhone: new Thickness(20, 20, 0, 0)
			);

			// [3] obsolete
			Device.OnPlatform(iOS: () =>
			{
				Padding = new Thickness(0, 20, 0, 0);
			},
			Android: () =>
			{
				Padding = new Thickness(10, 20, 0, 0);
			});
			
			// [4]
			switch (Device.RuntimePlatform)
			{
				case Device.iOS:
					Padding = new Thickness(0, 20, 0, 0);
					break;
				case Device.Android:
					Padding = new Thickness(10, 20, 0, 0);
					break;
				case Device.WinPhone:
					Padding = new Thickness(20, 20, 0, 0);
					break;
			}
		}

		/// <summary>
		/// 1. Přístup navěšení Handleru skrz Xaml > Button.Clicked
		/// </summary>
		void Handle_Clicked(object sender, EventArgs eventArgs)
		{
			//throw new NotImplementedException();
			if (sender is Button)
			{
				var view = sender as Button;
				if (view.CommandParameter is Label)
				{
					var label = view.CommandParameter as Label;

					//Toast.MakeText(this.BindingContext, $"{label.Text} - {label.TextColor.ToString()}", ToastLength.Short);
					DependencyService.Get<IToast>().Show($"{label.Text} - {label.TextColor.ToString()}");
				}
			}

			var alert = DisplayAlert("Název alertu", "Bylo kliknuto.", "ano", "ne");

			if (alert.IsCompleted)
			{
			}
			if (alert.IsCanceled)
			{ 
			}
		}

		/// <summary>
		/// 2. Přístup navěšení handleru skrz Cs > Button.Clicked
		/// https://randomtutes.com/2018/03/13/toast-in-android-using-xamarin-forms/
		/// </summary>
		protected override void OnAppearing()
		{
			MyButton.Clicked += ToastButton_Clicked;
			//ToastButton.Clicked += ToastButton_Clicked;
		}

		private void ToastButton_Clicked(object sender, EventArgs e)
		{
			// samotná implementace zobrazení toastu je platform-specific
			DependencyService.Get<IToast>().Show("Toast Message");
		}
	}
}
