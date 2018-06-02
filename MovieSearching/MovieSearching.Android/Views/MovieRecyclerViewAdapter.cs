using System;

using Android.Views;
using Android.Widget;
using Android.Support.V7.Widget;
using System.Collections.Generic;
using Android.Content;
using MovieSearching.Droid.Utils;
using Com.Squareup.Picasso;
using Newtonsoft.Json;

namespace MovieSearching.Droid.Views
{
    class MovieRecyclerViewAdapter : RecyclerView.Adapter
    {
        public event EventHandler<MovieRecyclerViewAdapterClickEventArgs> ItemClick;
        public event EventHandler<MovieRecyclerViewAdapterClickEventArgs> ItemLongClick;
        List<MovieModel> items;
        MovieModel movieItem;
        Context context;

        public MovieRecyclerViewAdapter(Context context, List<MovieModel> data)
        {
            items = data;
            this.context = context;
        }

        // Create new views (invoked by the layout manager)
        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {

            //Setup your layout here
            View itemView = null;
            var id = Resource.Layout.cardview_movie_item;
            itemView = LayoutInflater.From(parent.Context).Inflate(id, parent, false);

            // var vh = new MovieRecyclerViewAdapterViewHolder(itemView, OnClick, OnLongClick);
             var vh = new MovieRecyclerViewAdapterViewHolder(itemView);
            return vh;
        }

        // Replace the contents of a view (invoked by the layout manager)
        public override void OnBindViewHolder(RecyclerView.ViewHolder viewHolder, int position)
        {
            movieItem = items[position];

            // Replace the contents of the view with that element
            var holder = viewHolder as MovieRecyclerViewAdapterViewHolder;
            holder.Title.Text = movieItem.Title;
            holder.Year.Text = movieItem.Year;
            //var url = "https://images-na.ssl-images-amazon.com/images/M/MV5BZGNkZjM0NWMtZTkwNC00YThlLWE1ODctN2Y0Yjk1NDJiOWQ0XkEyXkFqcGdeQXVyMTMxODk2OTU@._V1_SX300.jpg";
            Picasso.With(this.context)
                       .Load(movieItem.Poster)
                       .Fit()
                       .Tag(this.context)
                       .Into(holder.Image);


            holder.mItemView.Click += delegate {
                
                CustomFragmentManager.ReplaceFragment(context, MovieDetailViewFragment.NewInstance(JsonConvert.SerializeObject(movieItem)));
            };

        }

       

        public override int ItemCount => items.Count;

        void OnClick(MovieRecyclerViewAdapterClickEventArgs args) => ItemClick?.Invoke(this, args);
        void OnLongClick(MovieRecyclerViewAdapterClickEventArgs args) => ItemLongClick?.Invoke(this, args);

    }

    public class MovieRecyclerViewAdapterViewHolder : RecyclerView.ViewHolder
    {
        public TextView Title { get; set; }
        public TextView Year { get; set; }
        public ImageView Image { get; set; }
        public View mItemView { get; set; }

        public MovieRecyclerViewAdapterViewHolder(View itemView):base(itemView)
        {
            Title = itemView.FindViewById<TextView>(Resource.Id.title);
            Year = itemView.FindViewById<TextView>(Resource.Id.year);
            Image = itemView.FindViewById<ImageView>(Resource.Id.image_view);
            mItemView = itemView;
        }


        //public MovieRecyclerViewAdapterViewHolder(View itemView, Action<MovieRecyclerViewAdapterClickEventArgs> clickListener,
        //                    Action<MovieRecyclerViewAdapterClickEventArgs> longClickListener) : base(itemView)
        //{
        //    Title = itemView.FindViewById<TextView>(Resource.Id.title);
        //    Year = itemView.FindViewById<TextView>(Resource.Id.year);
        //    Image = itemView.FindViewById<ImageView>(Resource.Id.image_view);

        //    itemView.Click += (sender, e) => clickListener(new MovieRecyclerViewAdapterClickEventArgs {View = itemView, Position = AdapterPosition });
        //    itemView.LongClick += (sender, e) => longClickListener(new MovieRecyclerViewAdapterClickEventArgs { View = itemView, Position = AdapterPosition });
        //}
    }

    public class MovieRecyclerViewAdapterClickEventArgs : EventArgs
    {
        public View View { get; set; }
        public int Position { get; set; }
    }
}