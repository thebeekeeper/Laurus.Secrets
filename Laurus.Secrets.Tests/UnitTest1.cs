using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;
using System.Linq;
using Laurus.Secrets.Models;

namespace Laurus.Secrets.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void EncryptDecrypt()
        {
            var data = "asdf";
            var password = "password";
            var e = new Encrypter();
            var encryptedData = e.Encrypt(data, password);
            Assert.AreNotEqual(data, encryptedData);
            var decryptedData = e.Decrypt(encryptedData, password);
            Assert.AreEqual(data, decryptedData);
        }

        [TestMethod]
        public void SaveEncryptedData()
        {
            var u = new User()
            {
                Email = "test2@test.com"
            };
            using (var db = new Database())
            {
                db.Users.Add(u);
                db.SaveChanges();
            }

            var data = "afpwaeifjaweiopfjawopfjaopwiiiiiiiiiiiiifjiawe";
            var password = "butts";
            var e = new Encrypter();
            var encryptedData = e.Encrypt(data, password);

            using (var db = new Database())
            {
                var user = db.Users.Single(x => x.UserId == u.UserId);
                user.Passwords.Add(new Password() { EncryptedData = encryptedData, Salt = "adsf" });
                db.SaveChanges();
            }
        }

        [TestMethod]
        public void CreateUser()
        {
            var e = new Encrypter();
            var u = new User() { Email = "test2@test.com" };
            var password = "blarf";
            u.MasterPassword = e.HashPassword(password);

            using (var db = new Database())
            {
                db.Users.Add(u);
                db.SaveChanges();
            }
        }

        [TestMethod]
        public void EncryptMasterPassword()
        {
            var e = new Encrypter();
            var pass = "asdf";
            var encrypted1 = e.HashPassword(pass);
            var encrypted2 = e.HashPassword(pass);
            Assert.AreEqual(encrypted1, encrypted2);
        }
    }
}
