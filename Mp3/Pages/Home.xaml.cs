using Mp3.Entity;
using Mp3.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Mp3.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Home : Page
    {
        MemberServiceImp memberService;
        private string tokenLogin;
        public Home()
        {
            this.InitializeComponent();
            spinrect.Begin();
            memberService = new MemberServiceImp();
            tokenLogin = memberService.ReadTokenFromLocalStorage();
            if (tokenLogin == null)
            {
                MemberLoginAction.HideMenuIfLogged();
                this.notlog.Visibility = Visibility.Visible;
            }
            else
            {
                Member memberLogin = memberService.GetInformation(tokenLogin);
                this.logged.Visibility = Visibility.Visible;
                this.messageLogged.Text = "Hi, " + memberLogin.lastName + ". Welcome to Music!";
            }
        }

        private void loginButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Login));
        }

        private void RegisterButtonTextBlock_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            Frame.Navigate(typeof(Register));
        }
    }
}
