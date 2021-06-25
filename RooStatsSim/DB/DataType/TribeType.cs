using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RooStatsSim.DB.DataType
{
    public enum TribeList : byte
    {
        Animal,
        Plant,
        Insect,
        Human,
        Fish,
        Dragon,
        Formless,
        Angel,
        Undead,
    }
    enum TribeKorList : byte
    {
        동물형,
        식물형,
        곤충형,
        인간형,
        어패류,
        용족,
        무형,
        천사형,
        불사형,
    }

    public class TribeType
    {
        public TribeType(TribeList type)
        {
            Type = type;
        }
        public TribeType(string name)
        {
            //한글 영어 구분
            byte[] byteArray = Encoding.Default.GetBytes(name);
            int value = Convert.ToInt32(byteArray[0].ToString());

            if (value > 127)
            {   // 한글 Constructor
                foreach (string typeKor in Enum.GetNames(typeof(TribeKorList)))
                {
                    if (typeKor.Equals(name))
                    {
                        Type = (TribeList)Enum.Parse(typeof(TribeKorList), name);
                        return;
                    }
                }
            }
            else
            {   // 영어 Constructor
                foreach (string typeEng in Enum.GetNames(typeof(TribeList)))
                {
                    if (typeEng.Equals(name))
                    {
                        Type = (TribeList)Enum.Parse(typeof(TribeList), name);
                        return;
                    }
                }
            }
        }

        public string Name_en => Enum.GetName(typeof(TribeList), Type);
        public string Name_ko => Enum.GetName(typeof(TribeKorList), Type);
        public TribeList Type { get; }
        public int TypeNum => (int)Type;

        public static bool operator ==(TribeType lhs, TribeType rhs)
        {
            return lhs.Type == rhs.Type;
        }

        public static bool operator !=(TribeType lhs, TribeType rhs)
        {
            return lhs.Type != rhs.Type;
        }

        public override bool Equals(object obj)
        {
            return Type == ((TribeType)obj).Type;
        }

        public override int GetHashCode()
        {
            return (int)Type;
        }
    }
}
