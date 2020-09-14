using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Model;
using Common.WebClientAdapter;

namespace Common.JSONToXMLAdapter
{
    public static class JSONRequestGenerator
    {

        public static JSONRequestModel StringToJSON(string url)
        {
            JSONRequestModel request = new JSONRequestModel();
            string[] urlSplited = url.Split('/');
            request.Verb = urlSplited[0];
            if (request.Verb == ERequest.GET.ToString()) { GetUrl(urlSplited, request); }
            else if (request.Verb == ERequest.POST.ToString()) { PostUrl(urlSplited, request); }
            else if (request.Verb == ERequest.PATCH.ToString()) { PatchUrl(urlSplited, request); }
            else if (request.Verb == ERequest.DELETE.ToString()) { DeleteUrl(urlSplited, request); }
            else { return null; }
            return request;
        }
        private static JSONRequestModel GetUrl(string[] urlSplited, JSONRequestModel request)
        {
            if (urlSplited.Length >= 2) { request.Noun = "/" + urlSplited[1]; }       //all resurs
            if (urlSplited.Length >= 3) { request.Noun = request.Noun + "/" + urlSplited[2]; }      //only one
            if (urlSplited.Length >= 4) { request.Query = urlSplited[3]; }
            if (urlSplited.Length == 5) { request.Fields = urlSplited[4]; }  
            return request;
        }
        private static JSONRequestModel PostUrl(string[] urlSplited, JSONRequestModel request)
        {//if (urlSplited.Length == 3)
            request.Noun = "/" + urlSplited[1];
            request.Query = urlSplited[2];
            return request;
        }
        private static JSONRequestModel PatchUrl(string[] urlSplited, JSONRequestModel request)
        {//if (urlSplited.Length == 4)
            request.Noun = "/" + urlSplited[1] + "/" + urlSplited[2];
            if (urlSplited.Length == 5) { request.Query = urlSplited[4]; }
            request.Fields = urlSplited[3];
            return request;
        }
        private static JSONRequestModel DeleteUrl(string[] urlSplited, JSONRequestModel request)
        {//if (urlSplited.Length == 4)
            request.Noun = "/" + urlSplited[1] + "/" + urlSplited[2];
            return request;
        }
    }
}
