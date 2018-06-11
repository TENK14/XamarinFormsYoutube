using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

//[assembly: Xamarin.Forms.Dependency(typeof(ToastMessageService))]
[assembly: Xamarin.Forms.Dependency(typeof(XamarinFormsYoutube.Droid.Toast_Android))]
namespace XamarinFormsYoutube.Droid
{
	public class Toast_Android : IToast
	{
		//public Toast_Android(Android.App.Application.Context context) : base(context)
		//{

		//}
		public void Show(string message)
		{
			Android.Widget.Toast.MakeText(Android.App.Application.Context, message, ToastLength.Short).Show();
		}
	}
}