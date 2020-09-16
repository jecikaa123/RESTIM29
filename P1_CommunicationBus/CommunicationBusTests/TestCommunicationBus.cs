using Common.CommunicationBus;
using Common.Interfaces;
using Common.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunicationBusTests
{
    [TestClass]
    public class TestCommunicationBus
    {
        [TestMethod]
        public void Test_get_OK()
        {
            IRepositoryComponent sql = new RepositoryMock();
            CommBus cbm = new CommBus(sql);
            string json = "{\"Verb\": \"GET\",\"Noun\": \"Resources/2\",\"Query\": null,\"Fields\": null}";
            string response = cbm.SendRequest(json);

            Assert.IsNotNull(response);
        }

        [TestMethod]
        public void Test_get2_OK()
        {
            IRepositoryComponent sql = new RepositoryMock();
            CommBus cbm = new CommBus(sql);
            string json = "{\"Verb\": \"GET\",\"Noun\": \"Resources/2\",\"Query\": \"name='pera'\",\"Fields\": \"*\"}";
            string response = cbm.SendRequest(json);

            Assert.IsNotNull(response);
        }

        [TestMethod]
        public void Test_Get3_OK()
        {
            IRepositoryComponent sql = new RepositoryMock();
            CommBus cbm = new CommBus(sql);
            string json = "{\"Verb\": \"GET\",\"Noun\": \"Resources/2\",\"Query\": null,\"Fields\": null}";
            string response = cbm.SendRequest(json);

            Assert.IsNotNull(response);
        }

        [TestMethod]
        public void Test_post_OK()
        {
            IRepositoryComponent sql = new RepositoryMock();
            CommBus cbm = new CommBus(sql);
            string json = "{\"Verb\": \"POST\",\"Noun\": \"Resources/2\",\"Query\": \"name='pera'\",\"Fields\": \"*\"}";
            string response = cbm.SendRequest(json);

            Assert.IsNotNull(response);
        }

        [TestMethod]
        public void Test_delete_OK()
        {
            IRepositoryComponent sql = new RepositoryMock();
            CommBus cbm = new CommBus(sql);
            string json = "{\"Verb\": \"DELETE\",\"Noun\": \"Resources/2\",\"Query\": \"name='pera'\",\"Fields\": \"*\"}";
            string response = cbm.SendRequest(json);

            Assert.IsNotNull(response);
        }

        [TestMethod]
        public void Test_patch_OK()
        {
            IRepositoryComponent sql = new RepositoryMock();
            CommBus cbm = new CommBus(sql);
            string json = "{\"Verb\": \"PATCH\",\"Noun\": \"Resources/2\",\"Query\": \"name='pera'\",\"Fields\": \"*\"}";
            string response = cbm.SendRequest(json);

            Assert.IsNotNull(response);
        }

        [TestMethod]
        public void Test()
        {
            CommBus cbm = new CommBus();

            Assert.IsNotNull(cbm);
        }
    }
}
