// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace MovieSearching.iOS
{
    [Register ("MovieDetailViewController")]
    partial class MovieDetailViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel movieActors { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel movieDirector { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel movieLanguage { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel moviePlot { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel movieTitle { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel movieYear { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView posterImage { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel releaseDate { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (movieActors != null) {
                movieActors.Dispose ();
                movieActors = null;
            }

            if (movieDirector != null) {
                movieDirector.Dispose ();
                movieDirector = null;
            }

            if (movieLanguage != null) {
                movieLanguage.Dispose ();
                movieLanguage = null;
            }

            if (moviePlot != null) {
                moviePlot.Dispose ();
                moviePlot = null;
            }

            if (movieTitle != null) {
                movieTitle.Dispose ();
                movieTitle = null;
            }

            if (movieYear != null) {
                movieYear.Dispose ();
                movieYear = null;
            }

            if (posterImage != null) {
                posterImage.Dispose ();
                posterImage = null;
            }

            if (releaseDate != null) {
                releaseDate.Dispose ();
                releaseDate = null;
            }
        }
    }
}