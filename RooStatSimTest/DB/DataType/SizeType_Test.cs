using System;
using NUnit.Framework;
using RooStatsSim.DB.DataType;

namespace RooStatSimTest.DB.DataType
{
    [TestFixture]
    class SizeType_Test
    {
        [Test]
        public void ConstructorEnum()
        {
            var type = new SizeType(SizeList.Middle);

            Assert.IsTrue(type.Name_en.Equals("Middle"));
            Assert.IsTrue(type.Name_ko.Equals("중형"));
        }
        [Test]
        public void ConstructorEngName()
        {
            var type = new SizeType("Middle");

            Assert.IsTrue(type.Name_en.Equals("Middle"));
            Assert.IsTrue(type.Name_ko.Equals("중형"));
        }
        [Test]
        public void ConstructorKorName()
        {
            var type = new SizeType("중형");

            Assert.IsTrue(type.Name_en.Equals("Middle"));
            Assert.IsTrue(type.Name_ko.Equals("중형"));
        }
    }
}