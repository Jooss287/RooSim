using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RooStatsSim.DB.Abilitys;
using RooStatsSim.DB.DataType;

namespace RooStatsSim.DB
{
    public class MonsterInfo
    {
        public MonsterInfo(uint id)
        {
            Id = id;
            
        }

        public MonsterInfo(uint id, string name, ElementList element, TribeList tribe, SizeList size, MonsterKindList monsterKind)
        {
            Id = id;
            Name = name;
            Element = new ElementType(element);
            Tribe = new TribeType(tribe);
            Size = new SizeType(size);
            MonsterKind = new MonsterKindType(monsterKind);
        }

        public uint Id { get; set; }
        public string Name { get; set; }
        public string NameKor { get; set; }

        public StatusPoint Status { get; set; }
        public BasicAbility Ability { get; set; }

        public ElementType Element { get; set; }
        public TribeType Tribe { get; set; }
        public SizeType Size { get; set; }
        public MonsterKindType MonsterKind { get; set; }
    }
}
