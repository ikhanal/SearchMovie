using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Fragment = Android.Support.V4.App.Fragment;
using Toolbar = Android.Support.V7.Widget.Toolbar;
using Android.Support.Design.Widget;
using Newtonsoft.Json;
using Com.Squareup.Picasso;
using Android.Support.V7.App;

namespace MovieSearching.Droid.Views
{
    public class MovieDetailViewFragment : Fragment
    {
        private static string ARG_PARAM1="param1";
        private static string ARG_PARAM2 = "param2";

       
        MovieModel movieItem;

        View rootView;
        Toolbar mToolbar;
        CollapsingToolbarLayout collapsingToolbar;
        MovieViewHolder viewHolder;
       

        public static MovieDetailViewFragment NewInstance(string param1, string param2=null)
        {
            MovieDetailViewFragment fragment = new MovieDetailViewFragment();
            Bundle args = new Bundle();
            args.PutString(ARG_PARAM1, param1);
            args.PutString(ARG_PARAM2, param2);
            fragment.Arguments=args;
            return fragment;
        }
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            
            var result = Arguments.Get(ARG_PARAM1).ToString();
            movieItem = JsonConvert.DeserializeObject<MovieModel>(result);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
           
            rootView= inflater.Inflate(Resource.Layout.fragment_movie_detail, container, false);
            viewHolder = new MovieViewHolder(rootView);
            var activityToolbar = (this.Activity).FindViewById<Toolbar>(Resource.Id.main_toolbar);
              activityToolbar.Visibility = ViewStates.Gone;

             mToolbar = rootView.FindViewById<Toolbar>(Resource.Id.toolbar);
            SetupToolbar(mToolbar);
            View navigationIcon = mToolbar.GetChildAt(1); //NavigationIcon

            navigationIcon.Click += delegate
            {               
                this.Activity.OnBackPressed();
                activityToolbar.Visibility = ViewStates.Visible;
            };
            // Set Collapsing Toolbar layout to the screen
            collapsingToolbar = (CollapsingToolbarLayout)rootView.FindViewById(Resource.Id.collapsing_toolbar);
           


            collapsingToolbar.SetTitle(movieItem.Title);

            var imageView = rootView.FindViewById<ImageView>(Resource.Id.image);
           
            Picasso.With(this.Context)
                       .Load(movieItem.Poster)
                       .Fit()
                       .Tag(this.Context)
                       .Into(imageView);

            SetMovieDetail(viewHolder, movieItem);

            return rootView;
        }
        protected void SetupToolbar(Toolbar toolbar)
        {
            ((AppCompatActivity)this.Activity).SetSupportActionBar(toolbar);
            toolbar.SetNavigationIcon(Resource.Drawable.abc_ic_ab_back_material);

        }
        protected void SetMovieDetail(MovieViewHolder viewHolder, MovieModel movieItem)
        {
            viewHolder.Title.Text = movieItem.Title;
            viewHolder.Year.Text = movieItem.Year;
            viewHolder.Language.Text = movieItem.Language;
            viewHolder.Actor.Text = movieItem.Actors;
            viewHolder.Writer.Text = movieItem.Writer;
            viewHolder.Genre.Text = movieItem.Genre;
            viewHolder.Plot.Text = movieItem.Plot;
            viewHolder.Rated.Text = movieItem.Rated;
            viewHolder.BoxOffice.Text = movieItem.BoxOffice;

        }

        public class MovieViewHolder
        {
            public TextView Title { get; set; }
            public TextView Year { get; set; }
            public TextView Genre { get; set; }
            public TextView Released { get; set; }
            public TextView Plot { get; set; }
            public TextView Actor { get; set; }
            public TextView Writer { get; set; }
            public TextView Rated { get; set; }
           
            public TextView Language { get; set; }
            public TextView BoxOffice { get; set; }

            public MovieViewHolder(View rootView)
            {
                Title = rootView.FindViewById<TextView>(Resource.Id.title);
                Year = rootView.FindViewById<TextView>(Resource.Id.year);
                Genre = rootView.FindViewById<TextView>(Resource.Id.genere);
                Released = rootView.FindViewById<TextView>(Resource.Id.released);
                Plot = rootView.FindViewById<TextView>(Resource.Id.plot);
                Actor = rootView.FindViewById<TextView>(Resource.Id.actors);
                Writer = rootView.FindViewById<TextView>(Resource.Id.writer);
                Rated = rootView.FindViewById<TextView>(Resource.Id.rated);
               
                Language = rootView.FindViewById<TextView>(Resource.Id.language);
                BoxOffice = rootView.FindViewById<TextView>(Resource.Id.boxoffice);
            }
        }
    }
}