using System;
using NUnit.Framework;
using RooStatsSim.DB.DataType;

namespace RooStatSimTest.DB.DataType
{
    [TestFixture]
    class ElementType_Test
    {
        [Test]
        public void ConstructorEnum()
        {
            var type = new ElementType(ElementList.Holy);

            Assert.IsTrue(type.Name_en.Equals("Holy"));
            Assert.IsTrue(type.Name_ko.Equals("성속성"));
        }
        [Test]
        public void ConstructorEngName()
        {
            var type = new ElementType("Holy");

            Assert.IsTrue(type.Name_en.Equals("Holy"));
            Assert.IsTrue(type.Name_ko.Equals("성속성"));
        }
        [Test]
        public void ConstructorKorName()
        {
            var type = new ElementType("성속성");

            Assert.IsTrue(type.Name_en.Equals("Holy"));
            Assert.IsTrue(type.Name_ko.Equals("성속성"));
        }
    }
}