using System;
using NUnit.Framework;
using RooStatsSim.DB.DataType;

namespace RooStatSimTest.DB.DataType
{
    [TestFixture]
    class TribeType_Test
    {
        [Test]
        public void ConstructorEnum()
        {
            var type = new TribeType(TribeList.Human);

            Assert.IsTrue(type.Name_en.Equals("Human"));
            Assert.IsTrue(type.Name_ko.Equals("인간형"));
        }
        [Test]
        public void ConstructorEngName()
        {
            var type = new TribeType("Human");

            Assert.IsTrue(type.Name_en.Equals("Human"));
            Assert.IsTrue(type.Name_ko.Equals("인간형"));
        }
        [Test]
        public void ConstructorKorName()
        {
            var type = new TribeType("인간형");

            Assert.IsTrue(type.Name_en.Equals("Human"));
            Assert.IsTrue(type.Name_ko.Equals("인간형"));
        }
    }
}