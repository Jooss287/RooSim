using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RooStatsSim.DB.Table
{
    class EnumItemOptionTable_Kor
    {
        public static string STR_ATK_RATE = "발생 확률";
        public static string STR_REG_RATE = "저항 확률";
        public static string STR_DMG = "증가데미지";
        public static string STR_REG = "감소데미지";
        public static string STR_MONSTER = "몬스터에게 ";

        public static Dictionary<ITYPE, string> ITYPE_KOR = new Dictionary<ITYPE, string>()
        {
            {ITYPE.STR, "STR" },
            {ITYPE.AGI, "AGI" },
            {ITYPE.VIT, "VIT"},
            {ITYPE.INT, "INT"},
            {ITYPE.DEX, "DEX" },
            {ITYPE.LUK, "LUK" },
            {ITYPE.ATK, "ATK" },
            {ITYPE.MATK, "MATK" },
            {ITYPE.SMELTING_ATK, "제련 ATK" },
            {ITYPE.SMELTING_MATK, "제련 MATK" },
            {ITYPE.WEAPON_ATK, "무기 ATK" },
            {ITYPE.WEAPON_MATK, "무기 MATK" },
            {ITYPE.STATUS_ATK, "STAT ATK" },
            {ITYPE.STATUS_MATK, "STAT MATK" },
            {ITYPE.MASTERY_ATK, "마스터리 ATK" },
            {ITYPE.MASTERY_MATK, "마스터리 MATK" },
            {ITYPE.PHYSICAL_DAMAGE_ADDITIONAL, "추가 물리 데미지" },
            {ITYPE.MAGICAL_DAMAGE_ADDITIONAL, "추가 마법 데미지" },
            {ITYPE.DEF, "DEF" },
            {ITYPE.MDEF, "MDEF" },
            {ITYPE.SMELTING_DEF, "제련 DEF" },
            {ITYPE.SMELTING_MDEF,"제련 MDEF" },
            {ITYPE.HP,"HP" },
            {ITYPE.SP,"SP" },
            {ITYPE.HP_RECOVERY,"HP 자연 회복" },
            {ITYPE.SP_RECOVERY,"SP 자연 회복" },
            {ITYPE.FLEE,"FLEE" },
            {ITYPE.HIT,"HIT" },
            {ITYPE.CRI,"CRI" },
            {ITYPE.CDEF,"CDEF" },
        };
        public static Dictionary<DTYPE, string> DTYPE_KOR = new Dictionary<DTYPE, string>()
        {
            {DTYPE.ATK_P, "ATK %" },
            {DTYPE.MATK_P, "MATK %" },
            {DTYPE.PHYSICAL_DAMAGE, "물리 데미지(%)" },
            {DTYPE.MAGICAL_DAMAGE, "마법 데미지(%)" },
            {DTYPE.IGNORE_PHYSICAL_DEFENSE, "물리 방어 무시(%)" },
            {DTYPE.IGNORE_MAGICAL_DEFENSE, "마법 방어 무시(%)" },
            {DTYPE.MELEE_PHYSICAL_DAMAGE, "원거리 물리 데미지(%)" },
            {DTYPE.RANGE_PHYSICAL_DAMAGE, "원거리 물리 데미지(%)" },
            {DTYPE.PHYSICAL_DEC_DAMAGE, "물리 데미지 감소(%)" },
            {DTYPE.MAGICAL_DEC_DAMAGE, "마법 데미지 감소(%)" },
            {DTYPE.MELEE_PHYSICAL_DEC_DAMAGE, "근거리 물리 데미지 감소(%)" },
            {DTYPE.RANGE_PHYSICAL_DEC_DAMAGE, "원거리 물리 데미지 감소(%)" },
            {DTYPE.DEF_P, "DEF %" },
            {DTYPE.MDEF_P, "MDEF %" },
            {DTYPE.MAX_HP_P, "HP %" },
            {DTYPE.MAX_SP_P, "SP %" },
            {DTYPE.SP_WASTE, "SP 소모" },
            {DTYPE.ASPD, "ASPD" },
            {DTYPE.MOVING_SPEED,"이동속도" },
            {DTYPE.HEALING,"치유량 증가(%)" },
            {DTYPE.HEALING_RECERIVED,"받는 치유량(%)" },
            {DTYPE.VERIABLE_CASTING,"변동 캐스팅(%)" },
            {DTYPE.FIXED_CASTING,"고정 캐스팅(%)" },
            {DTYPE.COMMON_SKILL_DELAY,"스킬 후 딜레이(%)" },
        };
        public static Dictionary<SE_ATK_RATE_TYPE, string> SE_ATK_RATE_TYPE_KOR = new Dictionary<SE_ATK_RATE_TYPE, string>()
        {
            {SE_ATK_RATE_TYPE.STERN_ATK_RATE, EnumBaseTable_Kor.STATUS_EFFECT_TYPE_KOR[STATUS_EFFECT_TYPE.STERN] +STR_ATK_RATE },
            {SE_ATK_RATE_TYPE.FEAR_ATK_RATE, EnumBaseTable_Kor.STATUS_EFFECT_TYPE_KOR[STATUS_EFFECT_TYPE.FEAR] +STR_ATK_RATE },
            {SE_ATK_RATE_TYPE.SILENCE_ATK_RATE, EnumBaseTable_Kor.STATUS_EFFECT_TYPE_KOR[STATUS_EFFECT_TYPE.SILENCE] +STR_ATK_RATE },
            {SE_ATK_RATE_TYPE.FROZEN_ATK_RATE, EnumBaseTable_Kor.STATUS_EFFECT_TYPE_KOR[STATUS_EFFECT_TYPE.FROZEN] +STR_ATK_RATE },
            {SE_ATK_RATE_TYPE.CURSE_ATK_RATE, EnumBaseTable_Kor.STATUS_EFFECT_TYPE_KOR[STATUS_EFFECT_TYPE.CURSE] +STR_ATK_RATE },
            {SE_ATK_RATE_TYPE.PETRIFICATION_ATK_RATE, EnumBaseTable_Kor.STATUS_EFFECT_TYPE_KOR[STATUS_EFFECT_TYPE.PETRIFICATION] +STR_ATK_RATE },
            {SE_ATK_RATE_TYPE.DARK_ATK_RATE, EnumBaseTable_Kor.STATUS_EFFECT_TYPE_KOR[STATUS_EFFECT_TYPE.DARK] +STR_ATK_RATE },
            {SE_ATK_RATE_TYPE.POISON_ATK_RATE, EnumBaseTable_Kor.STATUS_EFFECT_TYPE_KOR[STATUS_EFFECT_TYPE.POISON] +STR_ATK_RATE },
            {SE_ATK_RATE_TYPE.SLEEP_ATK_RATE, EnumBaseTable_Kor.STATUS_EFFECT_TYPE_KOR[STATUS_EFFECT_TYPE.SLEEP] +STR_ATK_RATE },
            {SE_ATK_RATE_TYPE.BLEEDING_ATK_RATE, EnumBaseTable_Kor.STATUS_EFFECT_TYPE_KOR[STATUS_EFFECT_TYPE.BLEEDING] +STR_ATK_RATE },
        };
        public static Dictionary<SE_REG_RATE_TYPE, string> SE_REG_RATE_TYPE_KOR = new Dictionary<SE_REG_RATE_TYPE, string>()
        {
            {SE_REG_RATE_TYPE.STERN_REG_RATE, EnumBaseTable_Kor.STATUS_EFFECT_TYPE_KOR[STATUS_EFFECT_TYPE.STERN] + STR_REG_RATE },
            {SE_REG_RATE_TYPE.FEAR_REG_RATE, EnumBaseTable_Kor.STATUS_EFFECT_TYPE_KOR[STATUS_EFFECT_TYPE.FEAR] + STR_REG_RATE },
            {SE_REG_RATE_TYPE.SILENCE_REG_RATE, EnumBaseTable_Kor.STATUS_EFFECT_TYPE_KOR[STATUS_EFFECT_TYPE.SILENCE] + STR_REG_RATE },
            {SE_REG_RATE_TYPE.FROZEN_REG_RATE, EnumBaseTable_Kor.STATUS_EFFECT_TYPE_KOR[STATUS_EFFECT_TYPE.FROZEN] + STR_REG_RATE },
            {SE_REG_RATE_TYPE.CURSE_REG_RATE, EnumBaseTable_Kor.STATUS_EFFECT_TYPE_KOR[STATUS_EFFECT_TYPE.CURSE] + STR_REG_RATE },
            {SE_REG_RATE_TYPE.PETRIFICATION_REG_RATE, EnumBaseTable_Kor.STATUS_EFFECT_TYPE_KOR[STATUS_EFFECT_TYPE.PETRIFICATION] + STR_REG_RATE },
            {SE_REG_RATE_TYPE.DARK_REG_RATE, EnumBaseTable_Kor.STATUS_EFFECT_TYPE_KOR[STATUS_EFFECT_TYPE.DARK] + STR_REG_RATE },
            {SE_REG_RATE_TYPE.POISON_REG_RATE, EnumBaseTable_Kor.STATUS_EFFECT_TYPE_KOR[STATUS_EFFECT_TYPE.POISON] + STR_REG_RATE },
            {SE_REG_RATE_TYPE.SLEEP_REG_RATE, EnumBaseTable_Kor.STATUS_EFFECT_TYPE_KOR[STATUS_EFFECT_TYPE.SLEEP] + STR_REG_RATE },
            {SE_REG_RATE_TYPE.BLEEDING_REG_RATE, EnumBaseTable_Kor.STATUS_EFFECT_TYPE_KOR[STATUS_EFFECT_TYPE.BLEEDING] + STR_REG_RATE },
        };
        public static Dictionary<TRIBE_DMG_TYPE, string> TRIBE_DMG_TYPE_KOR = new Dictionary<TRIBE_DMG_TYPE, string>()
        {
            { TRIBE_DMG_TYPE.ANIMAL_DMG, EnumBaseTable_Kor.TRIBE_TYPE_KOR[TRIBE_TYPE.ANIMAL] + STR_DMG },
            { TRIBE_DMG_TYPE.PLANT_DMG, EnumBaseTable_Kor.TRIBE_TYPE_KOR[TRIBE_TYPE.PLANT] + STR_DMG },
            { TRIBE_DMG_TYPE.INSECT_DMG, EnumBaseTable_Kor.TRIBE_TYPE_KOR[TRIBE_TYPE.INSECT] + STR_DMG },
            { TRIBE_DMG_TYPE.HUMAN_DMG, EnumBaseTable_Kor.TRIBE_TYPE_KOR[TRIBE_TYPE.HUMAN] + STR_DMG },
            { TRIBE_DMG_TYPE.SEAFOOD_DMG, EnumBaseTable_Kor.TRIBE_TYPE_KOR[TRIBE_TYPE.SEAFOOD] + STR_DMG },
            { TRIBE_DMG_TYPE.DEVIL_DMG, EnumBaseTable_Kor.TRIBE_TYPE_KOR[TRIBE_TYPE.DEVIL] + STR_DMG },
            { TRIBE_DMG_TYPE.DRAGON_DMG, EnumBaseTable_Kor.TRIBE_TYPE_KOR[TRIBE_TYPE.DRAGON] + STR_DMG },
            { TRIBE_DMG_TYPE.NONE_DMG, EnumBaseTable_Kor.TRIBE_TYPE_KOR[TRIBE_TYPE.NONE] + STR_DMG },
            { TRIBE_DMG_TYPE.ANGEL_DMG, EnumBaseTable_Kor.TRIBE_TYPE_KOR[TRIBE_TYPE.ANGEL] + STR_DMG },
            { TRIBE_DMG_TYPE.UNDEAD_DMG, EnumBaseTable_Kor.TRIBE_TYPE_KOR[TRIBE_TYPE.UNDEAD] + STR_DMG },
        };
        public static Dictionary<TRIBE_REG_TYPE, string> TRIBE_REG_TYPE_KOR = new Dictionary<TRIBE_REG_TYPE, string>()
        {
            { TRIBE_REG_TYPE.ANIMAL_REG, EnumBaseTable_Kor.TRIBE_TYPE_KOR[TRIBE_TYPE.ANIMAL] + STR_REG },
            { TRIBE_REG_TYPE.PLANT_REG, EnumBaseTable_Kor.TRIBE_TYPE_KOR[TRIBE_TYPE.PLANT] + STR_REG },
            { TRIBE_REG_TYPE.INSECT_REG, EnumBaseTable_Kor.TRIBE_TYPE_KOR[TRIBE_TYPE.INSECT] + STR_REG },
            { TRIBE_REG_TYPE.HUMAN_REG, EnumBaseTable_Kor.TRIBE_TYPE_KOR[TRIBE_TYPE.HUMAN] + STR_REG },
            { TRIBE_REG_TYPE.SEAFOOD_REG, EnumBaseTable_Kor.TRIBE_TYPE_KOR[TRIBE_TYPE.SEAFOOD] + STR_REG },
            { TRIBE_REG_TYPE.DEVIL_REG, EnumBaseTable_Kor.TRIBE_TYPE_KOR[TRIBE_TYPE.DEVIL] + STR_REG },
            { TRIBE_REG_TYPE.DRAGON_REG, EnumBaseTable_Kor.TRIBE_TYPE_KOR[TRIBE_TYPE.DRAGON] + STR_REG },
            { TRIBE_REG_TYPE.NONE_REG, EnumBaseTable_Kor.TRIBE_TYPE_KOR[TRIBE_TYPE.NONE] + STR_REG },
            { TRIBE_REG_TYPE.ANGEL_REG, EnumBaseTable_Kor.TRIBE_TYPE_KOR[TRIBE_TYPE.ANGEL] + STR_REG },
            { TRIBE_REG_TYPE.UNDEAD_REG, EnumBaseTable_Kor.TRIBE_TYPE_KOR[TRIBE_TYPE.UNDEAD] + STR_REG },
        };
        public static Dictionary<MONSTER_KINDS_DMG_TYPE, string> MONSTER_KINDS_DMG_TYPE_KOR = new Dictionary<MONSTER_KINDS_DMG_TYPE, string>()
        {
            { MONSTER_KINDS_DMG_TYPE.NORMAL_DMG, EnumBaseTable_Kor.MONSTER_KINDS_TYPE_KOR[MONSTER_KINDS_TYPE.NORMAL] + STR_DMG },
            { MONSTER_KINDS_DMG_TYPE.MINI_DMG, EnumBaseTable_Kor.MONSTER_KINDS_TYPE_KOR[MONSTER_KINDS_TYPE.MINI] + STR_DMG },
            { MONSTER_KINDS_DMG_TYPE.MVP_DMG, EnumBaseTable_Kor.MONSTER_KINDS_TYPE_KOR[MONSTER_KINDS_TYPE.MVP] + STR_DMG },
        };
        public static Dictionary<MONSTER_KINDS_REG_TYPE, string> MONSTER_KINDS_REG_TYPE_KOR = new Dictionary<MONSTER_KINDS_REG_TYPE, string>()
        {
            { MONSTER_KINDS_REG_TYPE.NORMAL_REG, EnumBaseTable_Kor.MONSTER_KINDS_TYPE_KOR[MONSTER_KINDS_TYPE.NORMAL] + STR_REG },
            { MONSTER_KINDS_REG_TYPE.MINI_REG, EnumBaseTable_Kor.MONSTER_KINDS_TYPE_KOR[MONSTER_KINDS_TYPE.MINI] + STR_REG },
            { MONSTER_KINDS_REG_TYPE.MVP_REG, EnumBaseTable_Kor.MONSTER_KINDS_TYPE_KOR[MONSTER_KINDS_TYPE.MVP] + STR_REG },
        };
        public static Dictionary<MONSTER_SIZE_DMG_TYPE, string> MONSTER_SIZE_DMG_TYPE_KOR = new Dictionary<MONSTER_SIZE_DMG_TYPE, string>()
        {
            { MONSTER_SIZE_DMG_TYPE.SMALL_DMG, EnumBaseTable_Kor.MONSTER_SIZE_KOR[MONSTER_SIZE.SMALL] + STR_DMG },
            { MONSTER_SIZE_DMG_TYPE.MIDDLE_DMG, EnumBaseTable_Kor.MONSTER_SIZE_KOR[MONSTER_SIZE.MIDDLE] + STR_DMG },
            { MONSTER_SIZE_DMG_TYPE.LARGE_DMG, EnumBaseTable_Kor.MONSTER_SIZE_KOR[MONSTER_SIZE.LARGE] + STR_DMG },
        };
        public static Dictionary<MONSTER_SIZE_REG_TYPE, string> MONSTER_SIZE_REG_TYPE_KOR = new Dictionary<MONSTER_SIZE_REG_TYPE, string>()
        {
            { MONSTER_SIZE_REG_TYPE.SMALL_REG, EnumBaseTable_Kor.MONSTER_SIZE_KOR[MONSTER_SIZE.SMALL] + STR_REG },
            { MONSTER_SIZE_REG_TYPE.MIDDLE_REG, EnumBaseTable_Kor.MONSTER_SIZE_KOR[MONSTER_SIZE.MIDDLE] + STR_REG },
            { MONSTER_SIZE_REG_TYPE.LARGE_REG, EnumBaseTable_Kor.MONSTER_SIZE_KOR[MONSTER_SIZE.LARGE] + STR_REG },
        };
        public static Dictionary<MONSTER_ELEMENT_DMG_TYPE, string> MONSTER_ELEMENT_DMG_TYPE_KOR = new Dictionary<MONSTER_ELEMENT_DMG_TYPE, string>()
        {
            { MONSTER_ELEMENT_DMG_TYPE.NORMAL_MONSTER_DMG, EnumBaseTable_Kor.ELEMENT_TYPE_KOR[ELEMENT_TYPE.NORMAL] + STR_MONSTER + STR_DMG },
            { MONSTER_ELEMENT_DMG_TYPE.WIND_MONSTER_DMG, EnumBaseTable_Kor.ELEMENT_TYPE_KOR[ELEMENT_TYPE.WIND] + STR_MONSTER + STR_DMG },
            { MONSTER_ELEMENT_DMG_TYPE.EARTH_MONSTER_DMG, EnumBaseTable_Kor.ELEMENT_TYPE_KOR[ELEMENT_TYPE.EARTH] + STR_MONSTER + STR_DMG },
            { MONSTER_ELEMENT_DMG_TYPE.FIRE_MONSTER_DMG, EnumBaseTable_Kor.ELEMENT_TYPE_KOR[ELEMENT_TYPE.FIRE] + STR_MONSTER + STR_DMG },
            { MONSTER_ELEMENT_DMG_TYPE.WATER_MONSTER_DMG, EnumBaseTable_Kor.ELEMENT_TYPE_KOR[ELEMENT_TYPE.WATER] + STR_MONSTER + STR_DMG },
            { MONSTER_ELEMENT_DMG_TYPE.POISON_MONSTER_DMG, EnumBaseTable_Kor.ELEMENT_TYPE_KOR[ELEMENT_TYPE.POISON] + STR_MONSTER + STR_DMG },
            { MONSTER_ELEMENT_DMG_TYPE.HOLY_MONSTER_DMG, EnumBaseTable_Kor.ELEMENT_TYPE_KOR[ELEMENT_TYPE.HOLY] + STR_MONSTER + STR_DMG },
            { MONSTER_ELEMENT_DMG_TYPE.DARK_MONSTER_DMG, EnumBaseTable_Kor.ELEMENT_TYPE_KOR[ELEMENT_TYPE.DARK] + STR_MONSTER + STR_DMG },
            { MONSTER_ELEMENT_DMG_TYPE.ASTRAL_MONSTER_DMG, EnumBaseTable_Kor.ELEMENT_TYPE_KOR[ELEMENT_TYPE.ASTRAL] + STR_MONSTER + STR_DMG },
            { MONSTER_ELEMENT_DMG_TYPE.UNDEAD_MONSTER_DMG, EnumBaseTable_Kor.ELEMENT_TYPE_KOR[ELEMENT_TYPE.UNDEAD] + STR_MONSTER + STR_DMG },
        };
        public static Dictionary<ELEMENT_DMG_TYPE, string> ELEMENT_DMG_TYPE_KOR = new Dictionary<ELEMENT_DMG_TYPE, string>()
        {
            { ELEMENT_DMG_TYPE.NORMAL_DMG, EnumBaseTable_Kor.ELEMENT_TYPE_KOR[ELEMENT_TYPE.NORMAL] + STR_DMG },
            { ELEMENT_DMG_TYPE.WIND_DMG, EnumBaseTable_Kor.ELEMENT_TYPE_KOR[ELEMENT_TYPE.WIND] + STR_DMG },
            { ELEMENT_DMG_TYPE.EARTH_DMG, EnumBaseTable_Kor.ELEMENT_TYPE_KOR[ELEMENT_TYPE.EARTH] + STR_DMG },
            { ELEMENT_DMG_TYPE.FIRE_DMG, EnumBaseTable_Kor.ELEMENT_TYPE_KOR[ELEMENT_TYPE.FIRE] + STR_DMG },
            { ELEMENT_DMG_TYPE.WATER_DMG, EnumBaseTable_Kor.ELEMENT_TYPE_KOR[ELEMENT_TYPE.WATER] + STR_DMG },
            { ELEMENT_DMG_TYPE.POISON_DMG, EnumBaseTable_Kor.ELEMENT_TYPE_KOR[ELEMENT_TYPE.POISON] + STR_DMG },
            { ELEMENT_DMG_TYPE.HOLY_DMG, EnumBaseTable_Kor.ELEMENT_TYPE_KOR[ELEMENT_TYPE.HOLY] + STR_DMG },
            { ELEMENT_DMG_TYPE.DARK_DMG, EnumBaseTable_Kor.ELEMENT_TYPE_KOR[ELEMENT_TYPE.DARK] + STR_DMG },
            { ELEMENT_DMG_TYPE.ASTRAL_DMG, EnumBaseTable_Kor.ELEMENT_TYPE_KOR[ELEMENT_TYPE.ASTRAL] + STR_DMG },
            { ELEMENT_DMG_TYPE.UNDEAD_DMG, EnumBaseTable_Kor.ELEMENT_TYPE_KOR[ELEMENT_TYPE.UNDEAD] + STR_DMG },
        };
        public static Dictionary<ELEMENT_REG_TYPE, string> ELEMENT_REG_TYPE_KOR = new Dictionary<ELEMENT_REG_TYPE, string>()
        {
            { ELEMENT_REG_TYPE.NORMAL_REG, EnumBaseTable_Kor.ELEMENT_TYPE_KOR[ELEMENT_TYPE.NORMAL] + STR_REG },
            { ELEMENT_REG_TYPE.WIND_REG, EnumBaseTable_Kor.ELEMENT_TYPE_KOR[ELEMENT_TYPE.WIND] + STR_REG },
            { ELEMENT_REG_TYPE.EARTH_REG, EnumBaseTable_Kor.ELEMENT_TYPE_KOR[ELEMENT_TYPE.EARTH] + STR_REG },
            { ELEMENT_REG_TYPE.FIRE_REG, EnumBaseTable_Kor.ELEMENT_TYPE_KOR[ELEMENT_TYPE.FIRE] + STR_REG },
            { ELEMENT_REG_TYPE.WATER_REG, EnumBaseTable_Kor.ELEMENT_TYPE_KOR[ELEMENT_TYPE.WATER] + STR_REG },
            { ELEMENT_REG_TYPE.POISON_REG, EnumBaseTable_Kor.ELEMENT_TYPE_KOR[ELEMENT_TYPE.POISON] + STR_REG },
            { ELEMENT_REG_TYPE.HOLY_REG, EnumBaseTable_Kor.ELEMENT_TYPE_KOR[ELEMENT_TYPE.HOLY] + STR_REG },
            { ELEMENT_REG_TYPE.DARK_REG, EnumBaseTable_Kor.ELEMENT_TYPE_KOR[ELEMENT_TYPE.DARK] + STR_REG },
            { ELEMENT_REG_TYPE.ASTRAL_REG, EnumBaseTable_Kor.ELEMENT_TYPE_KOR[ELEMENT_TYPE.ASTRAL] + STR_REG },
            { ELEMENT_REG_TYPE.UNDEAD_REG, EnumBaseTable_Kor.ELEMENT_TYPE_KOR[ELEMENT_TYPE.UNDEAD] + STR_REG },
        };
        public static Dictionary<ETC_DMG_TYPE, string> ETC_DMG_TYPE_KOR = new Dictionary<ETC_DMG_TYPE, string>()
        {
            {ETC_DMG_TYPE.OAK_DMG, "오크" + STR_DMG },
            {ETC_DMG_TYPE.GOBLIN_DMG, "고블린" + STR_DMG },
            {ETC_DMG_TYPE.KOBOLD_DMG, "코볼트" + STR_DMG },
            {ETC_DMG_TYPE.ALL_DMG, "모든 몬스터" + STR_DMG },
        };
        public static Dictionary<ETC_TYPE, string> ETC_TYPE_KOR = new Dictionary<ETC_TYPE, string>()
        {
            { ETC_TYPE.NO_BREAK, "파괴 불가" },
            { ETC_TYPE.NO_SIZE_PANELTY, "체형 패널티 없음" },
        };

        public static ITEM_OPTION_TYPE GET_ITEM_OPTION_TYPE(ref string option_name)
        {
            string intput_name = option_name;
            if (ITYPE_KOR.ContainsValue(option_name))
            {
                ITYPE type = ITYPE_KOR.FirstOrDefault(x => x.Value == intput_name).Key;
                option_name = Enum.GetName(typeof(ITYPE), type);
                return ITEM_OPTION_TYPE.ITYPE;
            }
            if (DTYPE_KOR.ContainsValue(option_name))
            {
                DTYPE type = DTYPE_KOR.FirstOrDefault(x => x.Value == intput_name).Key;
                option_name = Enum.GetName(typeof(DTYPE), type);
                return ITEM_OPTION_TYPE.DTYPE;
            }
            if (SE_ATK_RATE_TYPE_KOR.ContainsValue(option_name))
            {
                SE_ATK_RATE_TYPE type = SE_ATK_RATE_TYPE_KOR.FirstOrDefault(x => x.Value == intput_name).Key;
                option_name = Enum.GetName(typeof(SE_ATK_RATE_TYPE), type);
                return ITEM_OPTION_TYPE.SE_ATK_RATE_TYPE;
            }
            if (SE_REG_RATE_TYPE_KOR.ContainsValue(option_name))
            {
                SE_REG_RATE_TYPE type = SE_REG_RATE_TYPE_KOR.FirstOrDefault(x => x.Value == intput_name).Key;
                option_name = Enum.GetName(typeof(SE_REG_RATE_TYPE), type);
                return ITEM_OPTION_TYPE.SE_REG_RATE_TYPE;
            }
            if (TRIBE_DMG_TYPE_KOR.ContainsValue(option_name))
            {
                TRIBE_DMG_TYPE type = TRIBE_DMG_TYPE_KOR.FirstOrDefault(x => x.Value == intput_name).Key;
                option_name = Enum.GetName(typeof(TRIBE_DMG_TYPE), type);
                return ITEM_OPTION_TYPE.TRIBE_DMG_TYPE;
            }
            if (TRIBE_REG_TYPE_KOR.ContainsValue(option_name))
            {
                TRIBE_REG_TYPE type = TRIBE_REG_TYPE_KOR.FirstOrDefault(x => x.Value == intput_name).Key;
                option_name = Enum.GetName(typeof(TRIBE_REG_TYPE), type);
                return ITEM_OPTION_TYPE.TRIBE_REG_TYPE;
            }
            if (MONSTER_KINDS_DMG_TYPE_KOR.ContainsValue(option_name))
            {
                MONSTER_KINDS_DMG_TYPE type = MONSTER_KINDS_DMG_TYPE_KOR.FirstOrDefault(x => x.Value == intput_name).Key;
                option_name = Enum.GetName(typeof(MONSTER_KINDS_DMG_TYPE), type);
                return ITEM_OPTION_TYPE.MONSTER_KINDS_DMG_TYPE;
            }
            if (MONSTER_KINDS_REG_TYPE_KOR.ContainsValue(option_name))
            {
                MONSTER_KINDS_REG_TYPE type = MONSTER_KINDS_REG_TYPE_KOR.FirstOrDefault(x => x.Value == intput_name).Key;
                option_name = Enum.GetName(typeof(MONSTER_KINDS_REG_TYPE), type);
                return ITEM_OPTION_TYPE.MONSTER_KINDS_REG_TYPE;
            }
            if (MONSTER_SIZE_DMG_TYPE_KOR.ContainsValue(option_name))
            {
                MONSTER_SIZE_DMG_TYPE type = MONSTER_SIZE_DMG_TYPE_KOR.FirstOrDefault(x => x.Value == intput_name).Key;
                option_name = Enum.GetName(typeof(MONSTER_SIZE_DMG_TYPE), type);
                return ITEM_OPTION_TYPE.MONSTER_SIZE_DMG_TYPE;
            }
            if (MONSTER_SIZE_REG_TYPE_KOR.ContainsValue(option_name))
            {
                MONSTER_SIZE_REG_TYPE type = MONSTER_SIZE_REG_TYPE_KOR.FirstOrDefault(x => x.Value == intput_name).Key;
                option_name = Enum.GetName(typeof(MONSTER_SIZE_REG_TYPE), type);
                return ITEM_OPTION_TYPE.MONSTER_SIZE_REG_TYPE;
            }
            if (MONSTER_ELEMENT_DMG_TYPE_KOR.ContainsValue(option_name))
            {
                MONSTER_ELEMENT_DMG_TYPE type = MONSTER_ELEMENT_DMG_TYPE_KOR.FirstOrDefault(x => x.Value == intput_name).Key;
                option_name = Enum.GetName(typeof(MONSTER_ELEMENT_DMG_TYPE), type);
                return ITEM_OPTION_TYPE.MONSTER_ELEMENT_DMG_TYPE;
            }
            if (ELEMENT_DMG_TYPE_KOR.ContainsValue(option_name))
            {
                ELEMENT_DMG_TYPE type = ELEMENT_DMG_TYPE_KOR.FirstOrDefault(x => x.Value == intput_name).Key;
                option_name = Enum.GetName(typeof(ELEMENT_DMG_TYPE), type);
                return ITEM_OPTION_TYPE.ELEMENT_DMG_TYPE;
            }
            if (ELEMENT_REG_TYPE_KOR.ContainsValue(option_name))
            {
                ELEMENT_REG_TYPE type = ELEMENT_REG_TYPE_KOR.FirstOrDefault(x => x.Value == intput_name).Key;
                option_name = Enum.GetName(typeof(ELEMENT_REG_TYPE), type);
                return ITEM_OPTION_TYPE.ELEMENT_REG_TYPE;
            }
            if (ETC_DMG_TYPE_KOR.ContainsValue(option_name))
            {
                ETC_DMG_TYPE type = ETC_DMG_TYPE_KOR.FirstOrDefault(x => x.Value == intput_name).Key;
                option_name = Enum.GetName(typeof(ETC_DMG_TYPE), type);
                return ITEM_OPTION_TYPE.ETC_DMG_TYPE;
            }
            if (ETC_TYPE_KOR.ContainsValue(option_name))
            {
                ETC_TYPE type = ETC_TYPE_KOR.FirstOrDefault(x => x.Value == intput_name).Key;
                option_name = Enum.GetName(typeof(ETC_TYPE), type);
                return ITEM_OPTION_TYPE.ETC_TYPE;
            }
            
            return ITEM_OPTION_TYPE.ETC_TYPE;
        }
    }
}
