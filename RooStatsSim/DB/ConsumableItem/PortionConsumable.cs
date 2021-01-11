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
        }
    }
}
