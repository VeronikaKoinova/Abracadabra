using Microsoft.VisualStudio.TestTools.UnitTesting;
using WPFFlowerShop.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFFlowerShop;
using WPFFlowerShop.ApplicationData;

namespace WPFFlowerShop.Authorization.Tests
{
    [TestClass()]
    public class AutorizationTests
    {
        [TestMethod()]
        public void check_userTest()
        {
            Assert.AreEqual(true, Authorization.Autorization.check_user("Admin","1"));
        }
    }
}