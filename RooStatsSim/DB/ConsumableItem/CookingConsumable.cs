using System;
using System.Collections.Generic;
using RooStatsSim.DB.Table;

namespace RooStatsSim.DB.ConsumableItem
{
    public enum BASIC_COOKING_CONSUMABLE_ITEM
    {
        RICE_BALLS,
        STEAMED_CRAB,
        CAVIAR,
        NOODLE,
        SCALLOP,
        CRAB_MEAT,
        SHRIMP,
        TUNNY,
        CLAM_PORRIDGE,
    }
    class CookingConsumable
    {
        public static Dictionary<string, string> BASIC_COOKING_CONSUMABLE_ITEM_KOR = new Dictionary<string, string>()
        {
            {Enum.GetName(typeof(BASIC_COOKING_CONSUMABLE_ITEM),BASIC_COOKING_CONSUMABLE_ITEM.RICE_BALLS), "주먹밥" },
            {Enum.GetName(typeof(BASIC_COOKING_CONSUMABLE_ITEM),BASIC_COOKING_CONSUMABLE_ITEM.STEAMED_CRAB), "게 집게발 찜" },
            {Enum.GetName(typeof(BASIC_COOKING_CONSUMABLE_ITEM),BASIC_COOKING_CONSUMABLE_ITEM.CAVIAR), "캐비어" },
            {Enum.GetName(typeof(BASIC_COOKING_CONSUMABLE_ITEM),BASIC_COOKING_CONSUMABLE_ITEM.NOODLE), "깔끔한 국수" },
            {Enum.GetName(typeof(BASIC_COOKING_CONSUMABLE_ITEM),BASIC_COOKING_CONSUMABLE_ITEM.SCALLOP), "가리비볶음" },
            {Enum.GetName(typeof(BASIC_COOKING_CONSUMABLE_ITEM),BASIC_COOKING_CONSUMABLE_ITEM.CRAB_MEAT), "게맛살" },
            {Enum.GetName(typeof(BASIC_COOKING_CONSUMABLE_ITEM),BASIC_COOKING_CONSUMABLE_ITEM.SHRIMP), "쉬림프소스" },
            {Enum.GetName(typeof(BASIC_COOKING_CONSUMABLE_ITEM),BASIC_COOKING_CONSUMABLE_ITEM.TUNNY), "다랑어꼬치구이" },
            {Enum.GetName(typeof(BASIC_COOKING_CONSUMABLE_ITEM),BASIC_COOKING_CONSUMABLE_ITEM.CLAM_PORRIDGE), "조개죽" },
        };
        public Dictionary<string, ConsumableBuffInfo> Buff { get; set; }

        public CookingConsumable()
        {
            int max_lvl = 3;
            Buff = new Dictionary<string, ConsumableBuffInfo>();
            foreach (string name in Enum.GetNames(typeof(BASIC_COOKING_CONSUMABLE_ITEM)))
            {
                Buff.Add(name, new ConsumableBuffInfo(name, BASIC_COOKING_CONSUMABLE_ITEM_KOR[name], max_lvl));
                for (int i = 0; i < max_lvl; i++)
                    Buff[name].OPTION.Add(new ItemDB());
            }

            //주먹밥 
            for (int i = 0; i < max_lvl; i++)
                Buff[Enum.GetName(typeof(BASIC_COOKING_CONSUMABLE_ITEM), BASIC_COOKING_CONSUMABLE_ITEM.RICE_BALLS)].OPTION[i].Option_ITYPE[Enum.GetName(typeof(ITYPE), ITYPE.HP)] = (i + 1) * 400;
            //캐비어
            for (int i = 0; i < max_lvl; i++)
            {
                Buff[Enum.GetName(typeof(BASIC_COOKING_CONSUMABLE_ITEM), BASIC_COOKING_CONSUMABLE_ITEM.CAVIAR)].OPTION[i].Option_ITYPE[Enum.GetName(typeof(ITYPE), ITYPE.HIT)] = (i + 1) * 5;
                Buff[Enum.GetName(typeof(BASIC_COOKING_CONSUMABLE_ITEM), BASIC_COOKING_CONSUMABLE_ITEM.CAVIAR)].OPTION[i].Option_ITYPE[Enum.GetName(typeof(ITYPE), ITYPE.FLEE)] = (i + 1) * 5;
            }
            //깔끔한 국수 근물
            for (int i = 0; i < max_lvl; i++)
                Buff[Enum.GetName(typeof(BASIC_COOKING_CONSUMABLE_ITEM), BASIC_COOKING_CONSUMABLE_ITEM.NOODLE)].OPTION[i].Option_DTYPE[Enum.GetName(typeof(DTYPE), DTYPE.MELEE_PHYSICAL_DAMAGE)] = (i + 1) * 5;
            //가리비볶음 원물
            for (int i = 0; i < max_lvl; i++)
                Buff[Enum.GetName(typeof(BASIC_COOKING_CONSUMABLE_ITEM), BASIC_COOKING_CONSUMABLE_ITEM.SCALLOP)].OPTION[i].Option_DTYPE[Enum.GetName(typeof(DTYPE), DTYPE.RANGE_PHYSICAL_DAMAGE)] = (i + 1) * 5;
            //게맛살 마뎀
            for (int i = 0; i < max_lvl; i++)
                Buff[Enum.GetName(typeof(BASIC_COOKING_CONSUMABLE_ITEM), BASIC_COOKING_CONSUMABLE_ITEM.CRAB_MEAT)].OPTION[i].Option_DTYPE[Enum.GetName(typeof(DTYPE), DTYPE.MAGICAL_DAMAGE)] = (i + 1) * 5;
            //쉬림프소스 공속
            Buff[Enum.GetName(typeof(BASIC_COOKING_CONSUMABLE_ITEM), BASIC_COOKING_CONSUMABLE_ITEM.SHRIMP)].OPTION[0].Option_DTYPE[Enum.GetName(typeof(DTYPE), DTYPE.ASPD)] = 5;
            Buff[Enum.GetName(typeof(BASIC_COOKING_CONSUMABLE_ITEM), BASIC_COOKING_CONSUMABLE_ITEM.SHRIMP)].OPTION[1].Option_DTYPE[Enum.GetName(typeof(DTYPE), DTYPE.ASPD)] = 8;
            Buff[Enum.GetName(typeof(BASIC_COOKING_CONSUMABLE_ITEM), BASIC_COOKING_CONSUMABLE_ITEM.SHRIMP)].OPTION[2].Option_DTYPE[Enum.GetName(typeof(DTYPE), DTYPE.ASPD)] = 10;
            //다랑어꼬치구이 크크뎀
            Buff[Enum.GetName(typeof(BASIC_COOKING_CONSUMABLE_ITEM), BASIC_COOKING_CONSUMABLE_ITEM.TUNNY)].OPTION[0].Option_ITYPE[Enum.GetName(typeof(ITYPE), ITYPE.CRI)] = 3;
            Buff[Enum.GetName(typeof(BASIC_COOKING_CONSUMABLE_ITEM), BASIC_COOKING_CONSUMABLE_ITEM.TUNNY)].OPTION[0].Option_DTYPE[Enum.GetName(typeof(DTYPE), DTYPE.CRI_DAMAGE)] = 4;
            Buff[Enum.GetName(typeof(BASIC_COOKING_CONSUMABLE_ITEM), BASIC_COOKING_CONSUMABLE_ITEM.TUNNY)].OPTION[1].Option_ITYPE[Enum.GetName(typeof(ITYPE), ITYPE.CRI)] = 5;
            Buff[Enum.GetName(typeof(BASIC_COOKING_CONSUMABLE_ITEM), BASIC_COOKING_CONSUMABLE_ITEM.TUNNY)].OPTION[1].Option_DTYPE[Enum.GetName(typeof(DTYPE), DTYPE.CRI_DAMAGE)] = 7;
            Buff[Enum.GetName(typeof(BASIC_COOKING_CONSUMABLE_ITEM), BASIC_COOKING_CONSUMABLE_ITEM.TUNNY)].OPTION[2].Option_ITYPE[Enum.GetName(typeof(ITYPE), ITYPE.CRI)] = 8;
            Buff[Enum.GetName(typeof(BASIC_COOKING_CONSUMABLE_ITEM), BASIC_COOKING_CONSUMABLE_ITEM.TUNNY)].OPTION[2].Option_DTYPE[Enum.GetName(typeof(DTYPE), DTYPE.CRI_DAMAGE)] = 10;
            //조개죽 캐스팅
            Buff[Enum.GetName(typeof(BASIC_COOKING_CONSUMABLE_ITEM), BASIC_COOKING_CONSUMABLE_ITEM.TUNNY)].OPTION[0].Option_DTYPE[Enum.GetName(typeof(DTYPE), DTYPE.VERIABLE_CASTING)] = 5;
            Buff[Enum.GetName(typeof(BASIC_COOKING_CONSUMABLE_ITEM), BASIC_COOKING_CONSUMABLE_ITEM.TUNNY)].OPTION[0].Option_DTYPE[Enum.GetName(typeof(DTYPE), DTYPE.FIXED_CASTING)] = 1;
            Buff[Enum.GetName(typeof(BASIC_COOKING_CONSUMABLE_ITEM), BASIC_COOKING_CONSUMABLE_ITEM.TUNNY)].OPTION[1].Option_DTYPE[Enum.GetName(typeof(DTYPE), DTYPE.VERIABLE_CASTING)] = 8;
            Buff[Enum.GetName(typeof(BASIC_COOKING_CONSUMABLE_ITEM), BASIC_COOKING_CONSUMABLE_ITEM.TUNNY)].OPTION[1].Option_DTYPE[Enum.GetName(typeof(DTYPE), DTYPE.FIXED_CASTING)] = 3;
            Buff[Enum.GetName(typeof(BASIC_COOKING_CONSUMABLE_ITEM), BASIC_COOKING_CONSUMABLE_ITEM.TUNNY)].OPTION[2].Option_DTYPE[Enum.GetName(typeof(DTYPE), DTYPE.VERIABLE_CASTING)] = 10;
            Buff[Enum.GetName(typeof(BASIC_COOKING_CONSUMABLE_ITEM), BASIC_COOKING_CONSUMABLE_ITEM.TUNNY)].OPTION[2].Option_DTYPE[Enum.GetName(typeof(DTYPE), DTYPE.FIXED_CASTING)] = 5;
        }
    }
}
