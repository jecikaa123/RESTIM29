using Common.WebClientAdapter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Common.XMLToDBAdapter
{
    public static class XMLToDBAdapter
    {
        public static string XMLToSql(XNode xmlNode)
        {
            XElement element = xmlNode.Document.Element("JSONRequestModel");
            if (ERequest.GET.ToString() == element.Element("Verb").Value) { return GetToSql(element); }
            else if (ERequest.POST.ToString() == element.Element("Verb").Value) { return PostToSql(element); }
            else if (ERequest.PATCH.ToString() == element.Element("Verb").Value) { return PatchToSql(element); }
            else if (ERequest.DELETE.ToString() == element.Element("Verb").Value) { return DeleteToSql(element); }
            return null;
        }
        //FOR XML PATH('Student'), ROOT('Students')
        //https://docs.microsoft.com/en-us/sql/relational-databases/xml/examples-using-path-mode?view=sql-server-ver15
        //GET/resurs
        //GET/resurs/1
        //GET/resurs/1/name='pera';type=1
        //GET/resurs/1/name='pera';type=1/id;name;surname
        private static string GetToSql(XElement element)
        {
            string SQLRequest = "";
            string Noun = element.Element("Noun").Value;
            string Querry = element.Element("Query").Value;
            string Fields = element.Element("Fields").Value;
            Noun = Noun.Substring(1);
            string[] nounSplited = Noun.Split('/');
            SQLRequest = "SELECT ";
            if (!(Fields == null || Fields == ""))
            {
                Fields = Fields.Replace(";", ",");
                SQLRequest += Fields;  
            }
            SQLRequest += " FROM " + nounSplited[0]; //all resurs

            if (nounSplited.Length == 2) { SQLRequest += " WHERE Id=" + nounSplited[1]; }
            
            if (!(Querry == null || Querry == "")) 
            {
                Querry = Querry.Replace(";", " AND ");
                SQLRequest += " AND " + Querry;
            }
            SQLRequest += ";";
            return SQLRequest;
        }
        //POST/resource/Name='Pera';Description='opis'
        private static string PostToSql(XElement element)
        {
            string SQLRequest = "INSERT ";
            string Noun = element.Element("Noun").Value;
            Noun = Noun.Substring(1);
            string Columns = "", Values = "";
            int i = 0;
            string Querry = element.Element("Query").Value;
            string[] QuerrySplited = Querry.Split(';');
            string[] pair = new string[2];

            while (QuerrySplited.Length > i) 
            {
                if (Columns != "") 
                {
                    Columns += ",";
                    Values += ",";
                }
                pair = QuerrySplited[i].Split('=');
                Columns = Columns + pair[0];
                Values = Values + pair[1];
                i++;
            }

            SQLRequest = "INSERT INTO " + Noun + " (" + Columns + ") VALUES (" + Values + ");";
            return SQLRequest;
        }
        //PATCH/resource/1/Name='Pera';Description='opis'/Name='Jovan';Description='opis'
        private static string PatchToSql(XElement element)
        {
            //Query, fields koje je sta 
            string SQLRequest = "";
            string Noun = element.Element("Noun").Value;
            string Querry = element.Element("Query").Value;
            string Fields = element.Element("Fields").Value;

            Noun = Noun.Substring(1);
            string[] NounSplited = Noun.Split('/');

            Fields = Fields.Replace(";", ",");

            SQLRequest = "UPDATE " + NounSplited[0] + " SET " + Fields + " WHERE Id=" + NounSplited[1] + " ";
            if (Querry != null) 
            {
                Querry = Querry.Replace(";", " AND ");
                SQLRequest += " AND " + Querry;
            }
            SQLRequest += ";";
            return SQLRequest;
        }
        //DELETE/resource/1
        private static string DeleteToSql(XElement element)
        {
            //mozda napraviti kada je samo broj i kada su ostali uslovi
            string SQLRequest = "";
            string Noun = element.Element("Noun").Value;

            Noun = Noun.Substring(1);
            string[] NounSplited = Noun.Split('/');


            SQLRequest = "DELETE FROM " + NounSplited[0] + " WHERE Id=" + NounSplited[1] + ";";

            return SQLRequest;
        }
    }
}
