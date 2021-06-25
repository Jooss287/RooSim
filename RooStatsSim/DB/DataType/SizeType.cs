using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RooStatsSim.DB.DataType
{
    public enum SizeList : byte
    {
        Small,
        Middle,
        Large,
    }
    public enum SizeKorList : byte
    {
        소형,
        중형,
        대형,
    }

    public class SizeType
    {
        public SizeType(SizeList type)
        {
            Type = type;
        }
        public SizeType(string name)
        {
            //한글 영어 구분
            byte[] byteArray = Encoding.Default.GetBytes(name);
            int value = Convert.ToInt32(byteArray[0].ToString());

            if (value > 127)
            {   // 한글 Constructor
                foreach (string typeKor in Enum.GetNames(typeof(SizeKorList)))
                {
                    if (typeKor.Equals(name))
                    {
                        Type = (SizeList)Enum.Parse(typeof(SizeKorList), name);
                        return;
                    }
                }
            }
            else
            {   // 영어 Constructor
                foreach (string typeEng in Enum.GetNames(typeof(SizeList)))
                {
                    if (typeEng.Equals(name))
                    {
                        Type = (SizeList)Enum.Parse(typeof(SizeList), name);
                        return;
                    }
                }
            }
        }

        public string Name_en => Enum.GetName(typeof(SizeList), Type);
        public string Name_ko => Enum.GetName(typeof(SizeKorList), Type);
        public SizeList Type { get; }
        public int TypeNum => (int)Type;

        public static bool operator ==(SizeType lhs, SizeType rhs)
        {
            return lhs.Type == rhs.Type;
        }

        public static bool operator !=(SizeType lhs, SizeType rhs)
        {
            return lhs.Type != rhs.Type;
        }

        public override bool Equals(object obj)
        {
            return Type == ((SizeType)obj).Type;
        }

        public override int GetHashCode()
        {
            return (int)Type;
        }
    }
}
