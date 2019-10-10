using Mp3.Constant;
using Mp3.Entity;
using Mp3.Service;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    public sealed partial class Login : Page
    {
        MemberServiceImp memberService;
        public Login()
        {
            this.InitializeComponent();
            memberService = new MemberServiceImp();
            //Lay token da luu file trong lan dang nhap trc:
            var token = memberService.ReadTokenFromLocalStorage();
            //Lay info tu APi bang token:
            Member memberLogin = memberService.GetInformation(token);
        }
        private void ButtonLogin_Click(object sender, RoutedEventArgs e)
        {
            var errors = new Dictionary<string, string>();
            MemberLogin mem = new MemberLogin
            {
                email = this.email.Text,
                password = this.password.Password
            };
            errors = mem.Validate();
            if (errors.Count == 0)
            {
                string token = memberService.Login(this.email.Text, this.password.Password);
                if (token == null)
                {
                    //Show errors
                    Dialog.LoginFailedDialog();
                }
                else
                {
                    //Show success
                    Dialog.LoginSuccessfullDialog();
                    MemberLoginAction.ShowMenuIfLogged();
                    Frame.Navigate(typeof(MySong));
                }
            }
            else
            {
                ShowError(errors);
            }
            
        }

        private void ShowError(Dictionary<string, string> errors)
        {
            if (errors.ContainsKey("email"))
            {
                this.email_er.Visibility = Visibility.Visible;
                this.email_er.Text = errors["email"];
            }
            else
            {
                this.email_er.Visibility = Visibility.Collapsed;
            }
            if (errors.ContainsKey("password"))
            {
                this.password_er.Visibility = Visibility.Visible;
                this.password_er.Text = errors["password"];
            }
            else
            {
                this.password_er.Visibility = Visibility.Collapsed;
            }
        }

        private void ButtonReset_Click(object sender, RoutedEventArgs e)
        {
            ResetLoginForm();
        }

        private void ResetLoginForm()
        {
            this.email.Text = string.Empty;
            this.password.Password = string.Empty;
        }
    }
}
