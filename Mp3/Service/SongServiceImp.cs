using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Mp3.Constant;
using Mp3.Entity;
using Newtonsoft.Json;

namespace Mp3.Service
{
    class SongServiceImp : ISongService
    {
        public ObservableCollection<Song> GetFreeSongs()
        {
            ObservableCollection<Song> songs = new ObservableCollection<Song>();
            var client = new HttpClient();
            var responseContent = client.GetAsync(ApiUrl.GET_FREE_SONG_URL).Result.Content.ReadAsStringAsync().Result;
            songs = JsonConvert.DeserializeObject<ObservableCollection<Song>>(responseContent);
            return songs;
        }

        public Song PostSongFree(Song song)
        {
            try
            {
                var httpClient = new HttpClient();
                HttpContent content = new StringContent(JsonConvert.SerializeObject(song), Encoding.UTF8,
                    "application/json");
                Task<HttpResponseMessage> httpRequestMessage = httpClient.PostAsync(ApiUrl.POST_SONG_FREE, content);
                var responseContent = httpRequestMessage.Result.Content.ReadAsStringAsync().Result;
                var resSong = JsonConvert.DeserializeObject<Song>(responseContent);
                return resSong;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return null;
            }
        }
    }
}
