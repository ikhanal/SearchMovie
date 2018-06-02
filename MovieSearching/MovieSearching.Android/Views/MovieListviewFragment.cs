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
using Android.Support.V7.Widget;
using Android.Support.V4.Widget;

namespace MovieSearching.Droid.Views
{
    public class MovieListviewFragment : Android.Support.V4.App.Fragment
    {
        View rootView;
        Button searchButton;
        EditText searchText;
        RecyclerView recyclerView;
        SwipeRefreshLayout swipeRefreshLayout;

        MovieRecyclerViewAdapter movieAdapter;
        List<MovieModel> dataList;
        MovieModel movieModel;


        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
            dataList = new List<MovieModel>();
            movieAdapter = new MovieRecyclerViewAdapter(this.Context,dataList);
            
            var defaultTitle = "Russian";
            LoadMovieData(defaultTitle);

        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            rootView=inflater.Inflate(Resource.Layout.fragment_movie_list, container, false);
            searchButton = rootView.FindViewById<Button>(Resource.Id.search_button);
            searchText = rootView.FindViewById<EditText>(Resource.Id.search_text);
            recyclerView = rootView.FindViewById<RecyclerView>(Resource.Id.recycler_view);
            swipeRefreshLayout = rootView.FindViewById<SwipeRefreshLayout>(Resource.Id.swipe_refresh);

            SetRecyclerView(recyclerView);

            searchText.FocusChange += SearchText_FocusChange;
            searchText.ClearFocus();

            searchButton.Click += SearchButton_Click;

            return rootView;
        }

        private void SearchText_FocusChange(object sender, View.FocusChangeEventArgs e)
        {
            if(e.HasFocus)
            {
                searchText.Hint = "";

            }else
            {
                searchText.SetHint(Resource.String.search_hint_text);
            }
        }

        private async void SearchButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(searchText.Text))
            {
                movieModel = await CoreService.GetMovieService(searchText.Text);
                if (movieModel != null)
                {
                    dataList.Clear();
                    dataList.Add(movieModel);
                   
                    movieAdapter.NotifyDataSetChanged();

                }else
                {
                    dataList.Clear();
                    movieAdapter.NotifyDataSetChanged();
                    Toast.MakeText(this.Context, "No movies found", ToastLength.Short);
                }
            }else
            {
                searchText.SetError("Please enter searching title", null);
            }
        }

       

        protected void SetRecyclerView(RecyclerView recyclerView)
        {
            recyclerView.HasFixedSize = true;
            LinearLayoutManager layoutManager = new LinearLayoutManager(this.Context);
            recyclerView.SetLayoutManager(layoutManager);
            recyclerView.SetAdapter(movieAdapter);
        }

        protected async void LoadMovieData(string searchTitle)
        {
           
                movieModel = await CoreService.GetMovieService(searchTitle);
                if (movieModel != null)
                {
                    dataList.Add(movieModel);
                    movieAdapter.NotifyDataSetChanged();
                }else
                {
                    dataList.Clear();
                    movieAdapter.NotifyDataSetChanged();
                    Toast.MakeText(this.Context, "No movies found", ToastLength.Short);
                }
                   
           
        }
    }
}