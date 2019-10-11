using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace Mp3.Constant
{
    class Dialog
    {

        public static async void LoginSuccessfullDialog(string name)
        {
            ContentDialog noWifiDialog = new ContentDialog
            {
                Title = "Hi, "+ name+"!",
                Content = "Welcome back. You've been logged in.",
                CloseButtonText = "Ok"
            };
            ContentDialogResult result = await noWifiDialog.ShowAsync();
        }
        public static async void LoginFailedDialog()
        {
            ContentDialog noWifiDialog = new ContentDialog
            {
                Title = "Sorry",
                Content = "Login failed. Check your info again please!",
                CloseButtonText = "Ok"
            };
            ContentDialogResult result = await noWifiDialog.ShowAsync();
        }
        public static async void RegisterSuccessfullDialog()
        {
            ContentDialog noWifiDialog = new ContentDialog
            {
                Title = "Welcome",
                Content = "Register successful!",
                CloseButtonText = "Ok"
            };
            ContentDialogResult result = await noWifiDialog.ShowAsync();
        }
        public static async void RegisterFailedDialog()
        {
            ContentDialog noWifiDialog = new ContentDialog
            {
                Title = "Sorry",
                Content = "Register failed!",
                CloseButtonText = "Ok"
            };
            ContentDialogResult result = await noWifiDialog.ShowAsync();
        }
        public static async void UploadSongSuccessfullDialog()
        {
            ContentDialog noWifiDialog = new ContentDialog
            {
                Title = "Successful",
                Content = "Your song has been uploaded!",
                CloseButtonText = "Ok"
            };
            ContentDialogResult result = await noWifiDialog.ShowAsync();
        }
        public static async void UploadSongFailedDialog()
        {
            ContentDialog noWifiDialog = new ContentDialog
            {
                Title = "Sorry",
                Content = "Upload failed!",
                CloseButtonText = "Ok"
            };
            ContentDialogResult result = await noWifiDialog.ShowAsync();
        }
    }
}
