using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mp3.Constant
{
    class ApiUrl
    {
        public const string BASE_URL = "https://2-dot-backup-server-003.appspot.com/_api/v2";
        public const string REGISTER_URL = BASE_URL + "/members";
        public const string LOGIN_URL = BASE_URL+ "/members/authentication";
        public const string GET_INFORMATION_URL = BASE_URL+ "/members/information";
        public const string GET_FREE_SONG_URL = BASE_URL + "/songs/get-free-songs";
        public const string GET_UPLOAD_TOKEN = "https://2-dot-backup-server-003.appspot.com/get-upload-token";
        public const string POST_SONG_FREE = "https://2-dot-backup-server-003.appspot.com/_api/v2/songs/post-free";
    }
}
