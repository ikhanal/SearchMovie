using System;
using MovieSearching.iOS.Utils;
using UIKit;

namespace MovieSearching.iOS
{
    public partial class MovieDetailViewController : UIViewController
    {
        public MovieModel MovieItem { get; set; }
        public MovieDetailViewController() : base("MovieDetailViewController", null)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.
            if (!string.IsNullOrEmpty(MovieItem.Poster))
            {
                var imageView = new UIImageView(LoadImage.FromUrl(MovieItem.Poster));
                this.posterImage.Add(imageView);
            }
                

            this.movieTitle.Text = MovieItem.Title;
            this.movieYear.Text = MovieItem.Year;
            this.movieActors.Text ="Actors         : "+ MovieItem.Actors;
            this.releaseDate.Text = "Released Date : " +MovieItem.Released;
            this.movieLanguage.Text = "Langauge    : " + MovieItem.Language;

            this.moviePlot.Text =" Movie Plot  : "+ MovieItem.Plot;
            this.movieDirector.Text = "Direcotr : "+MovieItem.Director;

        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}

