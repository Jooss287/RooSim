using System;
using NUnit.Framework;
using RooStatsSim.DB.DataType;

namespace RooStatSimTest.DB.DataType
{
    [TestFixture]
    class MonsterKindType_Test
    {
        [Test]
        public void ConstructorEnum()
        {
            var type = new MonsterKindType(MonsterKindList.Mini);

            Assert.IsTrue(type.Name_en.Equals("Mini"));
            Assert.IsTrue(type.Name_ko.Equals("중보스"));
        }
        [Test]
        public void ConstructorEngName()
        {
            var type = new MonsterKindType("Mini");

            Assert.IsTrue(type.Name_en.Equals("Mini"));
            Assert.IsTrue(type.Name_ko.Equals("중보스"));
        }
        [Test]
        public void ConstructorKorName()
        {
            var type = new MonsterKindType("중보스");

            Assert.IsTrue(type.Name_en.Equals("Mini"));
            Assert.IsTrue(type.Name_ko.Equals("중보스"));
        }
    }
}