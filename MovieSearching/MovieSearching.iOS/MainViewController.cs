using System;
using System.Collections.Generic;
using Foundation;
using MovieSearching.iOS.Utils;
using UIKit;

namespace MovieSearching.iOS
{
    public partial class MainViewController : UITableViewController
    {
        static NSString cellId = new NSString("SearchResultCell");
        List<MovieModel> searchResults;
        MovieModel movieModel;
        UISearchBar searchBar;

        public MainViewController()// : base("MainViewController", null)
        {
            searchResults = new List<MovieModel>();
            movieModel = new MovieModel();
          
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.
            View.BackgroundColor = UIColor.White;
            Title = "Movie Searching App ";
            TableView.Source = new TableSource(this);
            TableView.RowHeight = UITableView.AutomaticDimension;
            TableView.EstimatedRowHeight = 400f;
            TableView.SeparatorStyle = 0;

            searchBar = new UISearchBar();
            searchBar.Placeholder = "Enter Movie Title";
            searchBar.SizeToFit();
            searchBar.AutocorrectionType = UITextAutocorrectionType.No;
            searchBar.AutocapitalizationType = UITextAutocapitalizationType.None;
            searchBar.SearchButtonClicked += (sender, e) =>
            {
                // check whetehr seach has string or not
                if(!string.IsNullOrEmpty(searchBar.Text))
                {
                // first check network 
                    if(Reachability.IsNetworkAvailable())
                    {
                        
                    Search();
                    }else{
                    new UIAlertView("", "No network connection is available. Please check your netowrk.", null, "OK").Show(); 
                    }
                }else{
                    new UIAlertView("", "Please enter searching string", null, "OK").Show(); 
                }

            };

            TableView.TableHeaderView = searchBar;
        }
        async void Search()
        {
            UIApplication.SharedApplication.NetworkActivityIndicatorVisible = true;
            movieModel = await CoreService.GetMovieService(searchBar.Text);
            SyncToMain(movieModel);
            searchBar.ResignFirstResponder();
        }
        void SyncToMain(MovieModel results)
        {
            this.InvokeOnMainThread(delegate
            {
                if (results != null)
                {
                    // first clear the data
                    searchResults.Clear();

                    searchResults.Add(results);
                    TableView.ReloadData();
                }
                else
                {
                    new UIAlertView("", "Could not retrieve movies ! Try again", null, "OK").Show();
                }

                UIApplication.SharedApplication.NetworkActivityIndicatorVisible = false;
            });
        }


        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
       

        class TableSource : UITableViewSource
        {
            MainViewController controller;

            public TableSource(MainViewController controller)
            {
                this.controller = controller;
            }

            public override nint RowsInSection(UITableView tableView, nint section)
            {
                return controller.searchResults.Count;
            }

            public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
            {
                UITableViewCell cell = tableView.DequeueReusableCell(cellId);
               
                if (cell == null)
                {

                    cell = new UITableViewCell(
                        UITableViewCellStyle.Default,

                        cellId
                    );
                    cell.IndentationWidth = 0.5f;

                    cell.LayoutMargins = UIEdgeInsets.Zero; // remove table cell separator margin
                    SetCardView(cell.ContentView);
                }
                var backgroundView = new UIImageView(LoadImage.FromUrl(controller.searchResults[indexPath.Row].Poster));
                //backgroundView.ClipsToBounds = true;
                backgroundView.ContentMode = UIViewContentMode.ScaleToFill;

                cell.TextLabel.Text = controller.searchResults[indexPath.Row].Title +"  "+ controller.searchResults[indexPath.Row].Year;
                //cell.DetailTextLabel.Text = controller.searchResults[indexPath.Row].Year;
                cell.BackgroundView = backgroundView;

                return cell;
            }

            public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
            {
                var vc = new MovieDetailViewController() { MovieItem = controller.searchResults[indexPath.Row] };
                 controller.NavigationController.PushViewController(vc, true);
            }

            protected void SetCardView(UIView view)
            {
                view.Layer.CornerRadius = 5.0f;
                view.Layer.BorderColor = UIColor.Clear.CGColor;
                view.Layer.BorderWidth = 5.0f;
                view.Layer.ShadowOpacity = 0.5f;
                view.Layer.ShadowColor = UIColor.LightGray.CGColor;
                view.Layer.ShadowRadius = 5.0f;
                //view.Layer.ShadowOffset=Estimate
                view.Layer.MasksToBounds = false;
            }
        }
    }
}
