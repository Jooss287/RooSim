using NUnit.Framework;
using RooStatsSim.DB;
using RooStatsSim.DB.Abilitys;


namespace RooStatSimTest.DB
{
    [TestFixture]
    class MonsterInfo_Test
    {
        private MonsterInfo _monsterInfo;
        [SetUp]
        public void SetUp()
        {
            _monsterInfo = new MonsterInfo(0)
            {
                Name = "bigben",
                NameKor = "빅벤",
                Ability = new BasicAbility()
                {
                    Status = new StatusPoint()
                    {
                        Str = 102,
                        Agi = 58,
                        Vit = 69,
                        Int = 75,
                        Dex = 131,
                        Luk = 49,
                    },
                    Hp = 620546,
                    Atk = 6987,
                    Matk = 4039,
                    DefEquip = 58,
                    MdefEquip = 131,
                    Hit = 456,
                    Flee = 203,
                },
                Tribe = new RooStatsSim.DB.DataType.TribeType(RooStatsSim.DB.DataType.TribeList.Formless),
                Element = new RooStatsSim.DB.DataType.ElementType(RooStatsSim.DB.DataType.ElementList.Earth),
                Size = new RooStatsSim.DB.DataType.SizeType(RooStatsSim.DB.DataType.SizeList.Middle),
                MonsterKind = new RooStatsSim.DB.DataType.MonsterKindType(RooStatsSim.DB.DataType.MonsterKindList.Normal),
            };
        }
        [Test]
        public void MonsterTribeGetTest()
        {
            Assert.True(_monsterInfo.Tribe.Name_ko.Equals("무형"));
            Assert.True(_monsterInfo.Element.Name_ko.Equals("지속성"));
            Assert.True(_monsterInfo.Size.Name_ko.Equals("중형"));
            Assert.True(_monsterInfo.MonsterKind.Name_ko.Equals("일반"));
        }
        
    }
}
