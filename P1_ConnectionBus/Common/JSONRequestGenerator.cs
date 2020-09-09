using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Model;
namespace Common
{
    public static class JSONRequestGenerator
    {
        
         public static JSONRequestModel StringToJSON(string url)
        {
            JSONRequestModel JSONRequestModel = new JSONRequestModel();
            string[] urlSplited = url.Split('/');
            JSONRequestModel.Verb = urlSplited[0];
            JSONRequestModel.Noun = "/" + urlSplited[1] + "/" + urlSplited[2];
            return JSONRequestModel;
        }
    }
}
