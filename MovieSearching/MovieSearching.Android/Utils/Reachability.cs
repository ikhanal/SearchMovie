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
using Android.Net;

namespace MovieSearching.Droid.Utils
{
    public class Reachability
    {
        /**
   * Get the network info
   * @param context
   * @return
   */
        public static NetworkInfo GetNetworkInfo(Context context)
        {
            ConnectivityManager cm = (ConnectivityManager)context.GetSystemService(Context.ConnectivityService);
            return cm.ActiveNetworkInfo;
        }

        /**
     * Check if there is any connectivity
     * @param context
     * @return
     */
        public static Boolean IsConnected(Context context)
        {
            NetworkInfo info = Reachability.GetNetworkInfo(context);
            return (info != null && info.IsConnected);
        }

        /**
     * Check if there is any connectivity to a Wifi network
     * @param context
     * @param type
     * @return
     */
        public static Boolean IsConnectedWifi(Context context)
        {
            NetworkInfo info = Reachability.GetNetworkInfo(context);
            return (info != null && info.IsConnected && info.Type == ConnectivityType.Wifi);
        }

        /**
    * Check if there is any connectivity to a mobile network
    * @param context
    * @param type
    * @return
    */
        public static Boolean IsConnectedMobile(Context context)
        {
            NetworkInfo info = Reachability.GetNetworkInfo(context);
            return (info != null && info.IsConnected && info.Type == ConnectivityType.Mobile);
        }

        /**
     * Check if there is fast connectivity
     * @param context
     * @return
     */

    }
}