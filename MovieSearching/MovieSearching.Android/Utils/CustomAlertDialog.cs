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

namespace MovieSearching.Droid.Utils
{
    public class CustomAlertDialog
    {
        public static void ShowAlertDialog(Context context, string alertMessage)
        {
            Android.Support.V7.App.AlertDialog.Builder builder = new Android.Support.V7.App.AlertDialog.Builder(context);
            builder.SetMessage(alertMessage);
            builder.SetNegativeButton("Ok", Cancel_Action);
            Android.Support.V7.App.AlertDialog dialog = builder.Create();
            dialog.Show();
        }
        private static void Cancel_Action(object sender, EventArgs args)
        {
            var dialog = sender as Dialog;

            dialog.Dismiss();
        }
    }
}