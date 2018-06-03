using System;
using Foundation;
using UIKit;

namespace MovieSearching.iOS.Utils
{
    public class LoadImage
    {
       
        public static UIImage FromUrl(string uri)
        {
            using (var url = new NSUrl(uri))
            using (var data = NSData.FromUrl(url))
                return UIImage.LoadFromData(data);
        }
    }
}
