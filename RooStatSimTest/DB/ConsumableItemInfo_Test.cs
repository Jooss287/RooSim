using NUnit.Framework;
using RooStatsSim.DB;


namespace RooStatSimTest.DB
{
    [TestFixture]
    class ConsumableItemInfo_Test
    {
        private ConsumableItemInfo _conItemInfo;
        [SetUp]
        public void SetUp()
        {
            _conItemInfo = new ConsumableItemInfo();
        }
        [Test]
        public void LevelTest()
        {

            //Assert.Greater(_conItemInfo.BaseLevel, 0);
            //Assert.Greater(_conItemInfo.JobLevel, 0);
        }
        
    }
}
