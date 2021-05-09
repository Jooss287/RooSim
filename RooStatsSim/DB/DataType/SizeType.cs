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
        private readonly SizeList _type;
        public SizeType(SizeList type)
        {
            this._type = type;
        }
        public SizeType(string name)
        {
            //한글 영어 구분
            byte[] byteArray = Encoding.Default.GetBytes(name);
            int value = Convert.ToInt32(byteArray[0].ToString());

            if (value > 127)
            {   // 한글 Constructor
                foreach (var typeKor in Enum.GetNames(typeof(SizeKorList)))
                {
                    if (typeKor.Equals(name))
                    {
                        _type = (SizeList)Enum.Parse(typeof(SizeKorList), name);
                        return;
                    }
                }
            }
            else
            {   // 영어 Constructor
                foreach (var typeEng in Enum.GetNames(typeof(SizeList)))
                {
                    if (typeEng.Equals(name))
                    {
                        _type = (SizeList)Enum.Parse(typeof(SizeList), name);
                        return;
                    }
                }
            }
        }

        public string Name_en
        {
            get { return Enum.GetName(typeof(SizeList), _type); }
        }
        public string Name_ko
        {
            get { return Enum.GetName(typeof(SizeKorList), _type); }
        }
    }
}
