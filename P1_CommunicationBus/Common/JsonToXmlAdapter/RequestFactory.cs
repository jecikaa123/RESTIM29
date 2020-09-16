using Common.CommunicationModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Common.JsonToXmlAdapter
{
    public class UrlToRequest
    {
        public UrlToRequest()
        {

        }

        public Request ConvertUrl(string stringRequest)
        {
            Request request = new Request();
            string[] partsOfRequest = stringRequest.Split('/');
            if (partsOfRequest.Length <= 1)
            {
                return null;
            }
            else
            {
                request.Verb = partsOfRequest[0];
                request.Noun = partsOfRequest[1] + "/" + partsOfRequest[2];
            }

            if(partsOfRequest.Length == 4)
            {
                request.Query = partsOfRequest[3];
            }
            else if (partsOfRequest.Length == 5)
            {
                request.Query = partsOfRequest[3];
                request.Fields = partsOfRequest[4];
            }

            return request;
        }
    }
}
