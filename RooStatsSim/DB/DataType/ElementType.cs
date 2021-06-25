﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RooStatsSim.DB.DataType
{
    public enum ElementList : byte
    {
        Natural,
        Wind,
        Earth,
        Fire,
        Water,
        Poison,
        Holy,
        Shadow,
        Ghost,
        Undead,
    }
    enum ElementKorList : byte
    {
        무속성,
        풍속성,
        지속성,
        화속성,
        수속성,
        독속성,
        성속성,
        암속성,
        염속성,
        언데드,
    }

    public class ElementType
    {
        public ElementType(ElementList type)
        {
            Type = type;
        }
        public ElementType(string name)
        {
            //한글 영어 구분
            byte[] byteArray = Encoding.Default.GetBytes(name);
            int value = Convert.ToInt32(byteArray[0].ToString());

            if (value > 127)
            {   // 한글 Constructor
                foreach (var typeKor in Enum.GetNames(typeof(ElementKorList)))
                {
                    if (typeKor.Equals(name))
                    {
                        Type = (ElementList)Enum.Parse(typeof(ElementKorList), name);
                        return;
                    }
                }
            }
            else
            {   // 영어 Constructor
                foreach (var typeEng in Enum.GetNames(typeof(ElementList)))
                {
                    if (typeEng.Equals(name))
                    {
                        Type = (ElementList)Enum.Parse(typeof(ElementList), name);
                        return;
                    }
                }
            }
        }

        public string Name_en => Enum.GetName(typeof(ElementList), Type);
        public string Name_ko => Enum.GetName(typeof(ElementKorList), Type);
        public ElementList Type { get; }
        public int TypeNum => (int)Type;

        public static bool operator ==(ElementType lhs, ElementType rhs)
        {
            return lhs.Type == rhs.Type;
        }

        public static bool operator !=(ElementType lhs, ElementType rhs)
        {
            return lhs.Type != rhs.Type;
        }

        public override bool Equals(object obj)
        {
            return Type == ((ElementType)obj).Type;
        }

        public override int GetHashCode()
        {
            return (int)Type;
        }
    }
}