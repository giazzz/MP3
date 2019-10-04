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
    public sealed partial class Register : Page
    {
        private const string ApiUrl = "https://2-dot-backup-server-003.appspot.com/_api/v2/members";
        private string GET_UPLOAD_TOKEN = "https://2-dot-backup-server-003.appspot.com/get-upload-token";
        public Register()
        {
            this.InitializeComponent();
        }


        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            MemberServiceImp memberService = new MemberServiceImp();
            FileServiceImp fileService = new FileServiceImp();
            var member = new Member
            {
                firstName = this.firstname.Text,
                lastName = this.lastname.Text,
                password = this.password.Password,
                address = this.address.Text,
                avatar = "https://i.ytimg.com/vi/MBtJdkiEhBk/maxresdefault.jpg",
                birthday = "2000-12-26",
                email = this.email.Text,
                gender = 1,
                introduction = this.introduction.Text,
                phone = this.phone.Text

            };
            //Register:
            Member mem = memberService.Register(member, ApiUrl);
            Debug.WriteLine("Email da dang ki: " + mem.email);






        }

    }
}
