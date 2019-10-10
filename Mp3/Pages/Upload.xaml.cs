using Mp3.Constant;
using Mp3.Entity;
using Mp3.Service;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Mp3.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Upload : Page
    {
        private ISongService songService;
        MemberServiceImp memberService;
        private string loginToken;

        public Upload()
        {

            this.memberService = new MemberServiceImp();
            loginToken = memberService.ReadTokenFromLocalStorage();
            if(loginToken == null)
            {
                //Show popup not login:
                MemberLoginAction.HideMenuIfLogged();
            }
            else
            {
                this.InitializeComponent();
                this.songService = new SongServiceImp();
            }
        }
        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            var errors = new Dictionary<string, string>();
            var uploadSong = new Song
            {
                name = this.name.Text,
                description = this.description.Text,
                singer = this.singer.Text,
                author = this.author.Text,
                thumbnail = this.thumbnail.Text,
                link = this.link.Text,
            };
            errors = uploadSong.Validate();
            if (errors.Count == 0)
            {
                ResetAllErrorsToHidden();
                //Upload:
                uploadSong = songService.PostSong(uploadSong, loginToken);
                //Check null::
                if (uploadSong == null)
                {
                    //Show error
                }
                else
                {
                    //Show success
                    ResetTextbox();
                }
            }
            else
            {
                ShowErrors(errors); 
            }
        }
        private void ResetAllErrorsToHidden()
        {
            this.name_er.Visibility = Visibility.Collapsed;
            this.description_er.Visibility = Visibility.Collapsed;
            this.singer_er.Visibility = Visibility.Collapsed;
            this.author_er.Visibility = Visibility.Collapsed;
            this.thumbnail_er.Visibility = Visibility.Collapsed;
            this.link_er.Visibility = Visibility.Collapsed;
        }
        private void ShowErrors(Dictionary<string, string> errors)
        {
            if (errors.ContainsKey("name"))
            {
                this.name_er.Visibility = Visibility.Visible;
                this.name_er.Text = errors["name"];
            }
            else
            {
                this.name_er.Visibility = Visibility.Collapsed;
            }
        }

        private void Button_Reset(object sender, RoutedEventArgs e)
        {
            ResetTextbox();
        }

        private void ResetTextbox()
        {
            this.name.Text = "";
            this.description.Text = "";
            this.singer.Text = "";
            this.author.Text = "";
            this.thumbnail.Text = "";
            this.link.Text = "";
        }
    }
}
