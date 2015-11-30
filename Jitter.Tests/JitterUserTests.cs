using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Jitter.Models;
using System.Collections.Generic;

namespace Jitter.Tests
{
    [TestClass]
    public class JitterUserTests
    {
        [TestMethod]
        public void JitterUserEnsureICanCreateInstance()
        {
            JitterUser user = new JitterUser();
            Assert.IsInstanceOfType(user, typeof(JitterUser));
        }

        [TestMethod]
        public void JitterUserEnsureJitterUserHasAllTheThings()
        {
            JitterUser a_user = new JitterUser();
            a_user.Handle = "adam1";
            a_user.FirstName = "Adam";
            a_user.LastName = "Sandler";
            a_user.Picture = "https://google.com";
            a_user.Description = "I am awesome!";
            //Act
            //Assert
            Assert.AreEqual("adam1", a_user.Handle);
            Assert.AreEqual("Adam", a_user.FirstName);
            Assert.AreEqual("Sandler", a_user.LastName);
            Assert.AreEqual("I am awesome!", a_user.Description);
            Assert.AreEqual("https://google.com", a_user.Picture);

        }

        [TestMethod]
        public void JitterUserEnsureUserHasJots()
        {
            List<Jot> list_of_jots = new List<Jot>
            {
                new Jot { Content = "blah" },
                new Jot { Content = "blah 2" }
            };
            JitterUser a_user = new JitterUser { Handle = "adam1", Jots = list_of_jots };
            List<Jot> actual_jots = a_user.Jots;
            CollectionAssert.AreEqual(list_of_jots, actual_jots);
        }

        [TestMethod]
        public void JitterUserEnsureUserFollowOthers()
        {
            List<JitterUser> list_of_users = new List<JitterUser>
            {
                new JitterUser {Handle="blah" },
                new JitterUser {Handle="blah2" }
            };
            JitterUser a_user = new JitterUser
            {
                Handle = "adam1",
                Following = list_of_users
            };
            List<JitterUser> actual = a_user.Following;
            CollectionAssert.AreEqual(actual, list_of_users);
        }
    }
}
