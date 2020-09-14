using Common.WebClientAdapter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Helper
{
    public static class Validations
    {
        static public bool UrlValid(String url)
        {
            string[] urlSplited = url.Split('/');
            //if (Enum.IsDefined(typeof(ERequest), urlSplited[0])) { return true; }
            if (ERequest.GET.ToString() == urlSplited[0]) { return GetValidation(urlSplited); }
            else if (ERequest.POST.ToString() == urlSplited[0]) { return PostValidation(urlSplited); }
            else if (ERequest.PATCH.ToString() == urlSplited[0]) { return PatchValidation(urlSplited); }
            else if (ERequest.DELETE.ToString() == urlSplited[0]) { return DeleteValidation(urlSplited); }

            return false;
        }
        static private bool GetValidation(string[] urlSplited)
        {
            return true;
        }
        static private bool PostValidation(string[] urlSplited)
        {
            return true;
        }
        static private bool PatchValidation(string[] urlSplited)
        {
            return true;
        }
        static private bool DeleteValidation(string[] urlSplited)
        {
            return true;
        }
    }
}
