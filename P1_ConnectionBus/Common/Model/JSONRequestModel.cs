using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Model
{
    public class JSONRequestModel
    {
        public string Verb { get; set; }
        public string Noun { get; set; }
        public string Querry { get; set; }
        public string Fields { get; set; }
        
        public JSONRequestModel() { }
        public JSONRequestModel(string verb, string noun, string querry, string fields)
        {
            Verb = verb;
            Noun = noun;
            Querry = querry;
            Fields = fields;
        }
    }
}
