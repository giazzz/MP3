using Mp3.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace Mp3.Service
{
    class MemberLoginAction
    {
        public static void ShowMenuIfLogged()
        {
            NaView.uploadNav.Visibility = Visibility.Visible;
            NaView.mysongNav.Visibility = Visibility.Visible;
            NaView.listsongNav.Visibility = Visibility.Visible;
            NaView.profileNav.Visibility = Visibility.Visible;
        }
        public static void HideMenuIfLogged()
        {
            NaView.uploadNav.Visibility = Visibility.Collapsed;
            NaView.mysongNav.Visibility = Visibility.Collapsed;
            NaView.listsongNav.Visibility = Visibility.Collapsed;
            NaView.profileNav.Visibility = Visibility.Collapsed;
        }
    }
}
