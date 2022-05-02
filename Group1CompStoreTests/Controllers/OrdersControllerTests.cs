using Microsoft.VisualStudio.TestTools.UnitTesting;
using Group1CompStore.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Group1CompStore.Controllers;

namespace Group1CompStore.Controllers.Tests
{
    [TestClass()]
    public class OrdersControllerTests
    {
        [TestMethod()]
        public void UnauthorizedUserDoesNotGainAccess()
        {
            JwtAuthentication jwtAuthentication = new JwtAuthentication("This certainly should not pass");

            User user = new User{
                username = "test",
                password = "test"
            };
            var ret = jwtAuthentication.Authenticate(user.username, user.password);
            Assert.IsNull(ret);
        }
        [TestMethod()]
        public void AuthorizedUserGainsAccess()
        {
            JwtAuthentication jwtAuthentication = new JwtAuthentication("This should pass");
            User user = new User
            {
                username = "user",
                password = "password"
            };
            var ret = jwtAuthentication.Authenticate(user.username, user.password);
            Assert.IsNotNull(ret);
        }
        [TestMethod()]
        public void PsychicSignaturesDontGainAccess()
        {
            JwtAuthentication jwtAuthentication = new JwtAuthentication("This certainly should not pass");

            User user = new User
            {
                username = null,
                password = null
            };
            var ret = jwtAuthentication.Authenticate(user.username, user.password);
            Assert.IsNull(ret);
        }

        public class User
        {
            public string username { get; set; }
            public string password { get; set; }
        }
    }
}