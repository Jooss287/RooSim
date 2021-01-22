using System;
using System.Collections.Generic;
using RooStatsSim.DB.Table;

namespace RooStatsSim.DB.Enchant
{
    public enum ADVANCED_ENCHANT_ITEM
    {
        FIGHTING_SPIRIT,
        SHARP,
        EXPERT_ARCHER,
        MAGIC,
        SPELL,
        BLESSING,
        PETRIFIED_SKIN,
        WILL,
        SHINING,
        TRANQUILITY,
    }

    public class AdvancedEnchant
    {
        public static Dictionary<string, string> ADVANCED_ENCHANT_ITEM_KOR = new Dictionary<string, string>()
        {
            {Enum.GetName(typeof(ADVANCED_ENCHANT_ITEM),ADVANCED_ENCHANT_ITEM.FIGHTING_SPIRIT), "투지" },
            {Enum.GetName(typeof(ADVANCED_ENCHANT_ITEM),ADVANCED_ENCHANT_ITEM.SHARP), "첨예" },
            {Enum.GetName(typeof(ADVANCED_ENCHANT_ITEM),ADVANCED_ENCHANT_ITEM.EXPERT_ARCHER), "명궁" },
            {Enum.GetName(typeof(ADVANCED_ENCHANT_ITEM),ADVANCED_ENCHANT_ITEM.MAGIC), "마력" },
            {Enum.GetName(typeof(ADVANCED_ENCHANT_ITEM),ADVANCED_ENCHANT_ITEM.SPELL), "마공" },
            {Enum.GetName(typeof(ADVANCED_ENCHANT_ITEM),ADVANCED_ENCHANT_ITEM.BLESSING), "축복" },
            {Enum.GetName(typeof(ADVANCED_ENCHANT_ITEM),ADVANCED_ENCHANT_ITEM.PETRIFIED_SKIN), "석화 피부" },
            {Enum.GetName(typeof(ADVANCED_ENCHANT_ITEM),ADVANCED_ENCHANT_ITEM.WILL), "의지" },
            {Enum.GetName(typeof(ADVANCED_ENCHANT_ITEM),ADVANCED_ENCHANT_ITEM.SHINING), "샤이닝" },
            {Enum.GetName(typeof(ADVANCED_ENCHANT_ITEM),ADVANCED_ENCHANT_ITEM.TRANQUILITY), "평온" },
        };

        public Dictionary<string, EnchantInfo> Dic { get; set; }

        public AdvancedEnchant()
        {
            int max_lvl = 4;
            Dic = new Dictionary<string, EnchantInfo>();
            foreach (string name in Enum.GetNames(typeof(ADVANCED_ENCHANT_ITEM)))
            {
                Dic.Add(name, new EnchantInfo(name, ADVANCED_ENCHANT_ITEM_KOR[name], max_lvl));
                for (int i = 0; i < max_lvl; i++)
                    Dic[name].OPTION.Add(new ItemDB());
                Dic[name].IsAdvanced = true;
            }


            ADVANCED_ENCHANT_ITEM item;
            for ( int i = 0; i < 4; i++)
            {
                //투지
                item = ADVANCED_ENCHANT_ITEM.FIGHTING_SPIRIT;
                Dic[Enum.GetName(typeof(ADVANCED_ENCHANT_ITEM), item)].MAX_LV = 4;
                Dic[Enum.GetName(typeof(ADVANCED_ENCHANT_ITEM), item)].OPTION[0].Option_ITYPE[Enum.GetName(typeof(ITYPE), ITYPE.ATK)] = 20;
                Dic[Enum.GetName(typeof(ADVANCED_ENCHANT_ITEM), item)].OPTION[0].Option_DTYPE[Enum.GetName(typeof(DTYPE), DTYPE.MELEE_PHYSICAL_DAMAGE)] = 2 * (i + 1);
                //명궁
                item = ADVANCED_ENCHANT_ITEM.EXPERT_ARCHER;
                Dic[Enum.GetName(typeof(ADVANCED_ENCHANT_ITEM), item)].OPTION[0].Option_ITYPE[Enum.GetName(typeof(ITYPE), ITYPE.ATK)] = 20;
                Dic[Enum.GetName(typeof(ADVANCED_ENCHANT_ITEM), item)].OPTION[0].Option_DTYPE[Enum.GetName(typeof(DTYPE), DTYPE.RANGE_PHYSICAL_DAMAGE)] = 2 * (i + 1);
                //마력
                item = ADVANCED_ENCHANT_ITEM.MAGIC;
                Dic[Enum.GetName(typeof(ADVANCED_ENCHANT_ITEM), item)].OPTION[0].Option_DTYPE[Enum.GetName(typeof(DTYPE), DTYPE.VARIABLE_CASTING)] = 2 * (i + 1) + 4;
                //마공
                item = ADVANCED_ENCHANT_ITEM.SPELL;
                Dic[Enum.GetName(typeof(ADVANCED_ENCHANT_ITEM), item)].OPTION[0].Option_ITYPE[Enum.GetName(typeof(ITYPE), ITYPE.MATK)] = 20;
                Dic[Enum.GetName(typeof(ADVANCED_ENCHANT_ITEM), item)].OPTION[0].Option_DTYPE[Enum.GetName(typeof(DTYPE), DTYPE.MAGICAL_DAMAGE)] = 2 * (i + 1);
                //축복
                item = ADVANCED_ENCHANT_ITEM.BLESSING;
                Dic[Enum.GetName(typeof(ADVANCED_ENCHANT_ITEM), item)].OPTION[0].Option_DTYPE[Enum.GetName(typeof(DTYPE), DTYPE.MAGICAL_DEC_DAMAGE)] = 2 * (i + 1);
                Dic[Enum.GetName(typeof(ADVANCED_ENCHANT_ITEM), item)].OPTION[0].Option_DTYPE[Enum.GetName(typeof(DTYPE), DTYPE.HEALING_RECERIVED)] = (i + 1);
                //석화 피부
                item = ADVANCED_ENCHANT_ITEM.PETRIFIED_SKIN;
                Dic[Enum.GetName(typeof(ADVANCED_ENCHANT_ITEM), item)].OPTION[0].Option_DTYPE[Enum.GetName(typeof(DTYPE), DTYPE.PHYSICAL_DEC_DAMAGE)] = 2 * (i + 1);
                Dic[Enum.GetName(typeof(ADVANCED_ENCHANT_ITEM), item)].OPTION[0].Option_DTYPE[Enum.GetName(typeof(DTYPE), DTYPE.HEALING_RECERIVED)] = (i + 1);
                //의지
                item = ADVANCED_ENCHANT_ITEM.WILL;
                Dic[Enum.GetName(typeof(ADVANCED_ENCHANT_ITEM), item)].OPTION[0].Option_DTYPE[Enum.GetName(typeof(STATUS_EFFECT_TYPE), STATUS_EFFECT_TYPE.STERN)] = 2 * (i + 1);
                Dic[Enum.GetName(typeof(ADVANCED_ENCHANT_ITEM), item)].OPTION[0].Option_DTYPE[Enum.GetName(typeof(STATUS_EFFECT_TYPE), STATUS_EFFECT_TYPE.FROZEN)] = 2 * (i + 1);
                Dic[Enum.GetName(typeof(ADVANCED_ENCHANT_ITEM), item)].OPTION[0].Option_DTYPE[Enum.GetName(typeof(STATUS_EFFECT_TYPE), STATUS_EFFECT_TYPE.DARK)] = 2 * (i + 1);
                Dic[Enum.GetName(typeof(ADVANCED_ENCHANT_ITEM), item)].OPTION[0].Option_DTYPE[Enum.GetName(typeof(STATUS_EFFECT_TYPE), STATUS_EFFECT_TYPE.PETRIFICATION)] = 2 * (i + 1);
                //샤이닝
                item = ADVANCED_ENCHANT_ITEM.SHINING;
                Dic[Enum.GetName(typeof(ADVANCED_ENCHANT_ITEM), item)].OPTION[0].Option_DTYPE[Enum.GetName(typeof(DTYPE), DTYPE.MAX_HP_P)] = (i + 1) + 2;
                Dic[Enum.GetName(typeof(ADVANCED_ENCHANT_ITEM), item)].OPTION[0].Option_DTYPE[Enum.GetName(typeof(ITYPE), ITYPE.HP_RECOVERY)] = i + 6;

                //평온
                item = ADVANCED_ENCHANT_ITEM.TRANQUILITY;
                Dic[Enum.GetName(typeof(ADVANCED_ENCHANT_ITEM), item)].OPTION[0].Option_DTYPE[Enum.GetName(typeof(DTYPE), DTYPE.CRI_DEF)] = 1 + 2 * i;
                Dic[Enum.GetName(typeof(ADVANCED_ENCHANT_ITEM), item)].OPTION[0].Option_DTYPE[Enum.GetName(typeof(ITYPE), ITYPE.CDEF)] = 3 * i + 6;
            }

            //첨예
            item = ADVANCED_ENCHANT_ITEM.SHARP;
            Dic[Enum.GetName(typeof(ADVANCED_ENCHANT_ITEM), item)].OPTION[0].Option_ITYPE[Enum.GetName(typeof(ITYPE), ITYPE.CRI)] = 6;
            Dic[Enum.GetName(typeof(ADVANCED_ENCHANT_ITEM), item)].OPTION[0].Option_DTYPE[Enum.GetName(typeof(DTYPE), DTYPE.CRI_DAMAGE)] = 1;
            Dic[Enum.GetName(typeof(ADVANCED_ENCHANT_ITEM), item)].OPTION[1].Option_ITYPE[Enum.GetName(typeof(ITYPE), ITYPE.CRI)] = 9;
            Dic[Enum.GetName(typeof(ADVANCED_ENCHANT_ITEM), item)].OPTION[1].Option_DTYPE[Enum.GetName(typeof(DTYPE), DTYPE.CRI_DAMAGE)] = 3;
            Dic[Enum.GetName(typeof(ADVANCED_ENCHANT_ITEM), item)].OPTION[2].Option_ITYPE[Enum.GetName(typeof(ITYPE), ITYPE.CRI)] = 12;
            Dic[Enum.GetName(typeof(ADVANCED_ENCHANT_ITEM), item)].OPTION[2].Option_DTYPE[Enum.GetName(typeof(DTYPE), DTYPE.CRI_DAMAGE)] = 5;
            Dic[Enum.GetName(typeof(ADVANCED_ENCHANT_ITEM), item)].OPTION[3].Option_ITYPE[Enum.GetName(typeof(ITYPE), ITYPE.CRI)] = 15;
            Dic[Enum.GetName(typeof(ADVANCED_ENCHANT_ITEM), item)].OPTION[3].Option_DTYPE[Enum.GetName(typeof(DTYPE), DTYPE.CRI_DAMAGE)] = 7;
        }
    }
}

