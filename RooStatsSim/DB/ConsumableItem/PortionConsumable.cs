using System;
using System.Collections.Generic;
using RooStatsSim.DB.Table;

namespace RooStatsSim.DB.ConsumableItem
{
    public enum BASIC_PORTION_CONSUMABLE_ITEM
    {
        STR,
        AGI,
        VIT,
        INT,
        DEX,
        LUK,
    }
    public enum ADVANCED_PORTION_CONSUMABLE_ITEM
    {
        STR_INT,
        STR_AGI,
        STR_DEX,
        STR_VIT,
        STR_LUK,
        INT_AGI,
        INT_DEX,
        INT_VIT,
        INT_LUK,
        AGI_DEX,
        AGI_VIT,
        AGI_LUK,
        DEX_VIT,
        DEX_LUK,
        LUK_VIT,
    }
    class PortionConsumable
    {
        public static Dictionary<string, string> BASIC_PORTION_CONSUMABLE_ITEM_KOR = new Dictionary<string, string>()
        {
            {Enum.GetName(typeof(BASIC_PORTION_CONSUMABLE_ITEM),BASIC_PORTION_CONSUMABLE_ITEM.STR), "힘 포션" },
            {Enum.GetName(typeof(BASIC_PORTION_CONSUMABLE_ITEM),BASIC_PORTION_CONSUMABLE_ITEM.AGI), "민첩 포션" },
            {Enum.GetName(typeof(BASIC_PORTION_CONSUMABLE_ITEM),BASIC_PORTION_CONSUMABLE_ITEM.VIT), "체력 포션" },
            {Enum.GetName(typeof(BASIC_PORTION_CONSUMABLE_ITEM),BASIC_PORTION_CONSUMABLE_ITEM.INT), "지능 포션" },
            {Enum.GetName(typeof(BASIC_PORTION_CONSUMABLE_ITEM),BASIC_PORTION_CONSUMABLE_ITEM.DEX), "손재주 포션" },
            {Enum.GetName(typeof(BASIC_PORTION_CONSUMABLE_ITEM),BASIC_PORTION_CONSUMABLE_ITEM.LUK), "행운 포션" },
        };
        public static Dictionary<string, string> ADVANCED_PORTION_CONSUMABLE_ITEM_KOR = new Dictionary<string, string>()
        {
            {Enum.GetName(typeof(ADVANCED_PORTION_CONSUMABLE_ITEM),ADVANCED_PORTION_CONSUMABLE_ITEM.STR_INT), "힘과 지능포션" },
            {Enum.GetName(typeof(ADVANCED_PORTION_CONSUMABLE_ITEM),ADVANCED_PORTION_CONSUMABLE_ITEM.STR_AGI), "힘과 민첩포션" },
            {Enum.GetName(typeof(ADVANCED_PORTION_CONSUMABLE_ITEM),ADVANCED_PORTION_CONSUMABLE_ITEM.STR_DEX), "힘과 손재주포션" },
            {Enum.GetName(typeof(ADVANCED_PORTION_CONSUMABLE_ITEM),ADVANCED_PORTION_CONSUMABLE_ITEM.STR_VIT), "힘과 체력포션" },
            {Enum.GetName(typeof(ADVANCED_PORTION_CONSUMABLE_ITEM),ADVANCED_PORTION_CONSUMABLE_ITEM.STR_LUK), "힘과 운포션" },
            {Enum.GetName(typeof(ADVANCED_PORTION_CONSUMABLE_ITEM),ADVANCED_PORTION_CONSUMABLE_ITEM.INT_AGI), "지능과 민첩포션" },
            {Enum.GetName(typeof(ADVANCED_PORTION_CONSUMABLE_ITEM),ADVANCED_PORTION_CONSUMABLE_ITEM.INT_DEX), "지능과 손재주포션" },
            {Enum.GetName(typeof(ADVANCED_PORTION_CONSUMABLE_ITEM),ADVANCED_PORTION_CONSUMABLE_ITEM.INT_VIT), "지능과 체력포션" },
            {Enum.GetName(typeof(ADVANCED_PORTION_CONSUMABLE_ITEM),ADVANCED_PORTION_CONSUMABLE_ITEM.INT_LUK), "지능과 운포션" },
            {Enum.GetName(typeof(ADVANCED_PORTION_CONSUMABLE_ITEM),ADVANCED_PORTION_CONSUMABLE_ITEM.AGI_DEX), "민첩과 손재주포션" },
            {Enum.GetName(typeof(ADVANCED_PORTION_CONSUMABLE_ITEM),ADVANCED_PORTION_CONSUMABLE_ITEM.AGI_VIT), "민첩과 체력포션" },
            {Enum.GetName(typeof(ADVANCED_PORTION_CONSUMABLE_ITEM),ADVANCED_PORTION_CONSUMABLE_ITEM.AGI_LUK), "민첩과 운포션" },
            {Enum.GetName(typeof(ADVANCED_PORTION_CONSUMABLE_ITEM),ADVANCED_PORTION_CONSUMABLE_ITEM.DEX_VIT), "손재주와 체력포션" },
            {Enum.GetName(typeof(ADVANCED_PORTION_CONSUMABLE_ITEM),ADVANCED_PORTION_CONSUMABLE_ITEM.DEX_LUK), "손재주와 운포션" },
            {Enum.GetName(typeof(ADVANCED_PORTION_CONSUMABLE_ITEM),ADVANCED_PORTION_CONSUMABLE_ITEM.LUK_VIT), "운과 체력포션" },
        };
        public Dictionary<string, ConsumableBuffInfo> Buff { get; set; }

        public PortionConsumable()
        {
            int max_lvl = 3;
            Buff = new Dictionary<string, ConsumableBuffInfo>();
            foreach (string name in Enum.GetNames(typeof(BASIC_PORTION_CONSUMABLE_ITEM)))
            {
                Buff.Add(name, new ConsumableBuffInfo(name, BASIC_PORTION_CONSUMABLE_ITEM_KOR[name], max_lvl));
                for (int i = 0; i < max_lvl; i++)
                {
                    ItemDB opt = new ItemDB();
                    opt.Option_ITYPE[name] = (i + 1) * 5;
                    Buff[name].OPTION.Add(opt);
                }
            }

            max_lvl = 1;
            foreach (string name in Enum.GetNames(typeof(ADVANCED_PORTION_CONSUMABLE_ITEM)))
            {
                Buff.Add(name, new ConsumableBuffInfo(name, ADVANCED_PORTION_CONSUMABLE_ITEM_KOR[name], max_lvl));
                string main_opt = name.Substring(0, 3);
                string sub_opt = name.Substring(4, 3);
                for (int i = 0; i < max_lvl; i++)
                {
                    ItemDB opt = new ItemDB();
                    opt.Option_ITYPE[main_opt] = 15;
                    opt.Option_ITYPE[sub_opt] = 7;
                    Buff[name].OPTION.Add(opt);
                }
            }
        }
    }
}
