using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mp3.Entity
{
    class Song
    {
        public string name { get; set; }
        public string description { get; set; }
        public string singer { get; set; }
        public string author { get; set; }
        public string thumbnail { get; set; }
        public string link { get; set; }

        public Dictionary<string, string> errors = new Dictionary<string, string>();
        public Dictionary<string, string> Validate()
        {
            if (string.IsNullOrEmpty(name))
            {
                errors.Add("name", "Name is required!");
            }
            else if(name.Length < 3 || name.Length > 50)
            {
                errors.Add("name", "Name is between 3 to 50!");
            }
            return errors;
        }


    }
}
