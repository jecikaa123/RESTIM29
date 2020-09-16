using System;
using Common.CommunicationModel;
using Common.JsonToXmlAdapter;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CommunicationBusTests
{
    [TestClass]
    public class RequestFactoryTests
    {
        [TestMethod]
        [DataRow("GET/resurs/1")]
        [DataRow("GET/Resources//Name='Petar';Description='opis'/Name;Description")]
        [DataRow("GET/Resources//Name='Petar';Description='opis'")]
        //GET/Resources//Name='Petar';Description='opis'/Name;Description
        //GET/Resources//Name='Petar';Description='opis'"
        public void ConvertStringToRequest_MakingRequest_ReturnNotNullValue(string stringRequest)
        {
            UrlToRequest urlToRequest = new UrlToRequest();
            Request request = urlToRequest.ConvertUrl(stringRequest);

            Assert.IsNotNull(request);
        }
       
    } 
}
