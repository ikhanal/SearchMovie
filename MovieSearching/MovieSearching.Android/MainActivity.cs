using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using MovieSearching.Droid.Utils;
using MovieSearching.Droid.Views;
using Android.Support.V7.App;
using Toolbar = Android.Support.V7.Widget.Toolbar;

namespace MovieSearching.Droid
{
	[Activity (Theme = "@style/ActionBarTheme", Label = "MovieSearching.Android", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : AppCompatActivity
	{
		
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.activity_main);

            var toolbar = FindViewById<Toolbar>(Resource.Id.main_toolbar);
            SetToolbar(toolbar);

            // add main fragment view
            CustomFragmentManager.AddFragment(this, new MovieListviewFragment(), typeof(MovieListviewFragment).Name);
		}
        protected void SetToolbar(Toolbar toolbar)
        {
            SetSupportActionBar(toolbar);
            SupportActionBar.SetTitle(Resource.String.app_name);
            SupportActionBar.SetDisplayHomeAsUpEnabled(false);
        }
        public override void OnBackPressed()
        {
            if (FragmentManager.BackStackEntryCount != 0)
            {
               
                FragmentManager.PopBackStack();// fragmentManager.popBackStack();
            }
            else
            {
                base.OnBackPressed();
            }
        }
    }
}


