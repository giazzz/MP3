using Mp3.Entity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mp3.Service
{
    interface ISongService
    {
        Song PostSongFree(Song song);
        ObservableCollection<Song> GetFreeSongs();
    }
}
