using Mp3.Constant;
using Mp3.Entity;
using Mp3.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public sealed partial class MySong : Page
    {
        private ISongService songService;
        ObservableCollection<Song> songs;
        MemberServiceImp memberService;
        private string loginToken;
        public MySong()
        {
            this.memberService = new MemberServiceImp();
            loginToken = memberService.ReadTokenFromLocalStorage();
            if (loginToken == null)
            {
                Debug.WriteLine("Ban chua dang nhap!!!");
            }
            else
            {
                this.InitializeComponent();
                this.songService = new SongServiceImp();
                LoadSongs();
            }
        }
        private void LoadSongs()
        {
            songs = songService.GetSongs(loginToken, ApiUrl.GET_MINE_SONG_URL);
        }
    }
}
