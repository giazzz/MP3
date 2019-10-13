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
using System.Xml;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;
using Windows.Data.Xml.Dom;
using Windows.UI.Xaml;
using System.Numerics;
using Microsoft.Toolkit.Uwp.UI.Animations;
using System.Timers;
using Windows.UI.Xaml.Media.Imaging;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Mp3.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ListSong : Page
    {
        private PersonPicture pic;
        private ISongService songService;
        ObservableCollection<Song> _songs;
        MemberServiceImp memberService;
        private string loginToken;
        private bool _isPlaying;
        private int _currentIndex = 0;
        public ListSong()
        {
            this.memberService = new MemberServiceImp();
            loginToken = memberService.ReadTokenFromLocalStorage();
            if (loginToken == null)
            {
                MemberLoginAction.HideMenuIfLogged();
            }
            else
            {
                this.InitializeComponent();
                this.songService = new SongServiceImp();
                LoadSongs();
                //Storyboard.SetTargetProperty(spinrect, "spin1570887621808");
                //spinrect.Begin();
            }
        }
        private void LoadSongs()
        {
            _songs = songService.GetSongs(loginToken, ApiUrl.SONG_URL);
            Debug.WriteLine("id = " + _songs[0].id);
            MyListSong.ItemsSource = _songs;
            _currentIndex = 0;
        }

        private void SelectSong(object sender, TappedRoutedEventArgs e)
        {
            Animation.StopRotationImage(pic);
            var selectItem = sender as StackPanel;
            pic = selectItem.Children.ElementAt(0) as PersonPicture;
            MyMediaPlayer.Pause();
            if (selectItem != null)
            {
                if (selectItem.Tag is Song currentSong)
                {
                    _currentIndex = _songs.IndexOf(currentSong);
                    try
                    {
                        MyMediaPlayer.Source = new Uri(currentSong.link);
                        Play();
                    }
                    catch (Exception a)
                    {
                        Debug.WriteLine(a.Message);
                        //LINK BAI HAT HONG:
                        throw;
                    }
                }
            }
        }
        private void Play()
        { 
            MyMediaPlayer.Source = new Uri(_songs[_currentIndex].link);
            ControlLabel.Text = "Now Playing: " + _songs[_currentIndex].name;
            MyListSong.SelectedIndex = _currentIndex;
            MyMediaPlayer.Play();
            StatusButton.Icon = new SymbolIcon(Symbol.Pause);
            _isPlaying = true;
            //Rotate image:
            Animation.StartRotationImage(pic);
        }
        private void Pause()
        {
            ControlLabel.Text = "Paused";
            MyMediaPlayer.Pause();
            StatusButton.Icon = new SymbolIcon(Symbol.Play);
            _isPlaying = false;
            Animation.StopRotationImage(pic);
        }
        private void StatusButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (_isPlaying)
            {
                Pause();
            }
            else
            {
                Play();
            }
        }
        private void PreviousButton_OnClick(object sender, RoutedEventArgs e)
        {
            _currentIndex--;
            if (_currentIndex < 0)
            {
                _currentIndex = _songs.Count - 1;
            }
            else if (_currentIndex >= _songs.Count)
            {
                _currentIndex = 0;
            }
            Play();
            Animation.StopRotationImage(pic);
        }
        private void NextButton_OnClick(object sender, RoutedEventArgs e)
        {
            _currentIndex++;
            if (_currentIndex >= _songs.Count || _currentIndex < 0)
            {
                _currentIndex = 0;
            }
            Play();
            Animation.StopRotationImage(pic);
        }
        //private void ListViewSong_OnDoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
        //{
        //    Animation.StopRotationImage(pic);
        //    var selectItem = MyListSong.SelectedItem as Song;
        //    MyMediaPlayer.Pause();
        //    if (selectItem != null)
        //    {
        //        _currentIndex = _songs.IndexOf(selectItem);
        //        MyMediaPlayer.Source = new Uri(selectItem.link);
        //        //SongThumbnail.ImageSource = new BitmapImage(new Uri(selectItem.thumbnail));
        //        Play();
        //    }
        //}
    }
}
