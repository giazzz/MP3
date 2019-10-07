﻿using Mp3.Entity;
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
        MemberService memberService;

        public Login()
        {
            this.InitializeComponent();
            this.memberService = new MemberServiceImp();
            ////Doc file chua token:
            //Windows.Storage.StorageFolder storageFolder =
            //    Windows.Storage.ApplicationData.Current.LocalFolder;
            //Windows.Storage.StorageFile tokenFile =
            //     storageFolder.GetFileAsync("token.txt").GetAwaiter().GetResult();
            //var token1 = Windows.Storage.FileIO.ReadTextAsync(tokenFile).GetAwaiter().GetResult();
            //Debug.WriteLine(token1);

            ////Lay info tu APi bang token:
            //Member memberLogin = memberService.GetInformation(token1, INFORMATION_URL);
            //Debug.WriteLine("Email da dang nhap: " + memberLogin.email);
        }

        private void ButtonLogin_Click(object sender, RoutedEventArgs e)
        {
            string token = memberService.Login(this.email.Text, this.password.Password);
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
