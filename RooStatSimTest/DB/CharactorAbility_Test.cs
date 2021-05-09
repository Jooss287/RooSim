using NUnit.Framework;
using RooStatsSim.DB;


namespace RooStatSimTest.DB
{
    [TestFixture]
    class CharactorAbility_Test
    {
        private CharactorAbility _charAbility;
        [SetUp]
        public void SetUp()
        {
            _charAbility = new CharactorAbility();
        }
        [Test]
        public void LevelTest()
        {

            Assert.Greater(_charAbility.BaseLevel, 0);
            Assert.Greater(_charAbility.JobLevel, 0);
        }
        
    }
}
