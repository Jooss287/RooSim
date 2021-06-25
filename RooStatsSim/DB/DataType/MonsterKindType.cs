using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RooStatsSim.DB.DataType
{
    public enum MonsterKindList : byte
    {
        Normal,
        Mini,
        Mvp,
    }
    public enum MonsterKindKorList : byte
    {
        일반,
        중보스,
        보스
    }

    public class MonsterKindType
    {
        public MonsterKindType(MonsterKindList type)
        {
            Type = type;
        }
        public MonsterKindType(string name)
        {
            //한글 영어 구분
            byte[] byteArray = Encoding.Default.GetBytes(name);
            int value = Convert.ToInt32(byteArray[0].ToString());

            if (value > 127)
            {   // 한글 Constructor
                foreach (string typeKor in Enum.GetNames(typeof(MonsterKindKorList)))
                {
                    if (typeKor.Equals(name))
                    {
                        Type = (MonsterKindList)Enum.Parse(typeof(MonsterKindKorList), name);
                        return;
                    }
                }
            }
            else
            {   // 영어 Constructor
                foreach (string typeEng in Enum.GetNames(typeof(MonsterKindList)))
                {
                    if (typeEng.Equals(name))
                    {
                        Type = (MonsterKindList)Enum.Parse(typeof(MonsterKindList), name);
                        return;
                    }
                }
            }
        }

        public string Name_en => Enum.GetName(typeof(MonsterKindList), Type);
        public string Name_ko => Enum.GetName(typeof(MonsterKindKorList), Type);
        public MonsterKindList Type { get; }
        public int TypeNum => (int)Type;

        public static bool operator ==(MonsterKindType lhs, MonsterKindType rhs)
        {
            return lhs.Type == rhs.Type;
        }

        public static bool operator !=(MonsterKindType lhs, MonsterKindType rhs)
        {
            return lhs.Type != rhs.Type;
        }

        public override bool Equals(object obj)
        {
            return Type == ((MonsterKindType)obj).Type;
        }

        public override int GetHashCode()
        {
            return (int)Type;
        }
    }
}
