using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RooStatsSim.DB.Table
{
    public enum ITEM_OPTION_TYPE
    {
        ITYPE,
        DTYPE,
        SE_ATK_RATE_TYPE,
        SE_REG_RATE_TYPE,
        TRIBE_DMG_TYPE,
        TRIBE_REG_TYPE,
        MONSTER_KINDS_DMG_TYPE,
        MONSTER_KINDS_REG_TYPE,
        MONSTER_SIZE_DMG_TYPE,
        MONSTER_SIZE_REG_TYPE,
        MONSTER_ELEMENT_DMG_TYPE,
        ELEMENT_DMG_TYPE,
        ELEMENT_REG_TYPE,
        ETC_TYPE,
        ETC_DMG_TYPE,
    }

    public enum ITYPE
    {
        STR = 0000,     //스테이터스 관련 스텟
        AGI,
        VIT,
        INT,
        DEX,
        LUK,
        ATK = 1000,     //공격력 관련 스텟
        MATK,
        SMELTING_ATK,
        SMELTING_MATK,
        WEAPON_ATK,
        WEAPON_MATK,
        STATUS_ATK,
        STATUS_MATK,
        MASTERY_ATK,
        MASTERY_MATK,
        PHYSICAL_DAMAGE_ADDITIONAL,
        MAGICAL_DAMAGE_ADDITIONAL,
        DEF = 2000,     //방어력 관련 스텟
        MDEF,
        SMELTING_DEF,
        SMELTING_MDEF,
        HP = 3000,      //HP,SP 관련 스텟
        SP,
        HP_RECOVERY,
        SP_RECOVERY,
        FLEE = 4000,    //회피명중 관련 스텟
        HIT,
        CRI = 5000,     //크리율 관련 스텟
        CDEF,
    }
    public enum DTYPE
    {
        ATK_P = 1000,
        MATK_P,
        PHYSICAL_DAMAGE,
        MAGICAL_DAMAGE,
        IGNORE_PHYSICAL_DEFENSE,
        IGNORE_MAGICAL_DEFENSE,
        MELEE_PHYSICAL_DAMAGE,
        RANGE_PHYSICAL_DAMAGE,
        DEF_P = 2000,
        MDEF_P,
        PHYSICAL_DEC_DAMAGE,
        MAGICAL_DEC_DAMAGE,
        MELEE_PHYSICAL_DEC_DAMAGE,
        RANGE_PHYSICAL_DEC_DAMAGE,
        MAX_HP_P = 3000,
        MAX_SP_P,
        SP_WASTE,
        ASPD = 6000,    //기타 관련 스텟
        MOVING_SPEED,
        HEALING,
        HEALING_RECERIVED,
        VERIABLE_CASTING,
        FIXED_CASTING,
        COMMON_SKILL_DELAY,
    }
    public enum SE_ATK_RATE_TYPE
    {
        STERN_ATK_RATE,
        FEAR_ATK_RATE,
        SILENCE_ATK_RATE,
        FROZEN_ATK_RATE,
        CURSE_ATK_RATE,
        PETRIFICATION_ATK_RATE,
        DARK_ATK_RATE,
        POISON_ATK_RATE,
        SLEEP_ATK_RATE,
        BLEEDING_ATK_RATE,
    }
    public enum SE_REG_RATE_TYPE
    {
        STERN_REG_RATE,
        FEAR_REG_RATE,
        SILENCE_REG_RATE,
        FROZEN_REG_RATE,
        CURSE_REG_RATE,
        PETRIFICATION_REG_RATE,
        DARK_REG_RATE,
        POISON_REG_RATE,
        SLEEP_REG_RATE,
        BLEEDING_REG_RATE,
    }
    public enum TRIBE_DMG_TYPE
    {
        ANIMAL_DMG,
        PLANT_DMG,
        INSECT_DMG,
        HUMAN_DMG,
        SEAFOOD_DMG,
        DEVIL_DMG,
        DRAGON_DMG,
        NONE_DMG,
        ANGEL_DMG,
        UNDEAD_DMG,
    }
    public enum TRIBE_REG_TYPE
    {
        ANIMAL_REG,
        PLANT_REG,
        INSECT_REG,
        HUMAN_REG,
        SEAFOOD_REG,
        DEVIL_REG,
        DRAGON_REG,
        NONE_REG,
        ANGEL_REG,
        UNDEAD_REG,
    }
    public enum MONSTER_KINDS_DMG_TYPE
    {
        NORMAL_DMG,
        MINI_DMG,
        MVP_DMG
    }
    public enum MONSTER_KINDS_REG_TYPE
    {
        NORMAL_REG,
        MINI_REG,
        MVP_REG
    }
    public enum MONSTER_SIZE_DMG_TYPE
    {
        SMALL_DMG,
        MIDDLE_DMG,
        LARGE_DMG,
    }
    public enum MONSTER_SIZE_REG_SIZE
    {
        SMALL_REG,
        MIDDLE_REG,
        LARGE_REG,
    }
    public enum MONSTER_ELEMENT_DMG_TYPE
    {
        NORMAL_MONSTER_DMG,
        WIND_MONSTER_DMG,
        EARTH_MONSTER_DMG,
        FIRE_MONSTER_DMG,
        WATER_MONSTER_DMG,
        POISON_MONSTER_DMG,
        HOLY_MONSTER_DMG,
        DARK_MONSTER_DMG,
        ASTRAL_MONSTER_DMG,
        UNDEAD_MONSTER_DMG,
    }
    public enum ELEMENT_DMG_TYPE
    {
        NORMAL_DMG,
        WIND_DMG,
        EARTH_DMG,
        FIRE_DMG,
        WATER_DMG,
        POISON_DMG,
        HOLY_DMG,
        DARK_DMG,
        ASTRAL_DMG,
        UNDEAD_DMG,
    }
    public enum ELEMENT_REG_TYPE
    {
        NORMAL_REG,
        WIND_REG,
        EARTH_REG,
        FIRE_REG,
        WATER_REG,
        POISON_REG,
        HOLY_REG,
        DARK_REG,
        ASTRAL_REG,
        UNDEAD_REG,
    }
    public enum ETC_TYPE
    {
        NO_SIZE_PANELTY,
        NO_BREAK,
    }
    public enum ETC_DMG_TYPE
    {
        OAK_DMG,
        KOBOLD_DMG,
        GOBLIN_DMG,
        ALL_DMG,
    }

    public enum IFTYPE
    {
        ATK_PER_STR,
        ATK_PER_AGI,
        HP_PER_VIT,
        MATK_PER_INT,
        ASPD_PER_AGI,
        PHYSICAL_DAMAGE_PER_HIT,
        ADDITIONAL_PHYSICAL_DAMAGE_PER_FIXED,

        //REFINE 관련
        HP_PER_REFINE = 1000,

        //TRIBE 관련
        CRI_TO_TRIBE = 2000,

        //SIMPLE IF
        ATK_MORETHAN_STR,
    }
}
