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
