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
        private readonly MonsterKindList _type;
        public MonsterKindType(MonsterKindList type)
        {
            this._type = type;
        }
        public MonsterKindType(string name)
        {
            //한글 영어 구분
            byte[] byteArray = Encoding.Default.GetBytes(name);
            int value = Convert.ToInt32(byteArray[0].ToString());

            if (value > 127)
            {   // 한글 Constructor
                foreach (var typeKor in Enum.GetNames(typeof(MonsterKindKorList)))
                {
                    if (typeKor.Equals(name))
                    {
                        _type = (MonsterKindList)Enum.Parse(typeof(MonsterKindKorList), name);
                        return;
                    }
                }
            }
            else
            {   // 영어 Constructor
                foreach (var typeEng in Enum.GetNames(typeof(MonsterKindList)))
                {
                    if (typeEng.Equals(name))
                    {
                        _type = (MonsterKindList)Enum.Parse(typeof(MonsterKindList), name);
                        return;
                    }
                }
            }
        }

        public string Name_en
        {
            get { return Enum.GetName(typeof(MonsterKindList), _type); }
        }
        public string Name_ko
        {
            get { return Enum.GetName(typeof(MonsterKindKorList), _type); }
        }
    }
}
