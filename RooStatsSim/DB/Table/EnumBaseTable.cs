using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RooStatsSim.DB.Table
{
    public enum ITEM_TYPE_ENUM
    {
        MONSTER_RESEARCH,
        STICKER,
        DRESS_STYLE,
        EQUIPMENT,
        CARD,
        ENCHANT,
        GEAR,
        SET_OPTION,
    }
    public enum EQUIP_TYPE_ENUM
    {
        HEAD_TOP,
        HEAD_MID,
        HEAD_BOT,
        WEAPON,
        ARMOR,
        SUB_WEAPON,
        CLOAK,
        SHOES,
        ACCESSORIES1,
        ACCESSORIES2,
        COSTUME,
        BACK_DECORATION,
    }
    public enum JOB_SELECT_LIST
    {
        NOVICE = 0,
        SWORDMAN = 100,
        KNIGHT = 110,
        CRUSADER = 120,
        MARCHANT = 200,
        BLACKSMITH = 210,
        ALCHEMIST = 220,
        THIEF = 300,
        ASSASSIN = 310,
        ROGUE = 320,
        ARCHER = 400,
        HUNTER = 410,
        BARD = 420,
        DANCER = 430,
        MAGICIAN = 500,
        WIZARD = 510,
        SAGE = 520,
        ACOLYTE = 600,
        PRIEST = 610,
        MONK = 620,
    }
    public enum STATUS_EFFECT_TYPE
    {
        STUN,
        FEAR,
        SILENCE,
        FROZEN,
        CURSE,
        PETRIFICATION,
        DARKNESS,
        POISON,
        SLEEP,
        BLEEDING
    }
    public enum TRIBE_TYPE
    {
        ANIMAL,
        PLANT,
        INSECT,
        HUMAN,
        FISH,
        DEVIL,
        DRAGON,
        FORMLESS,
        ANGEL,
        UNDEAD
    }
    public enum MONSTER_KINDS_TYPE
    {
        NORMAL,
        MINI,
        MVP
    }
    public enum MONSTER_SIZE
    {
        SMALL,
        MIDDLE,
        LARGE
    }
    public enum WEAPON_TYPE_ENUM
    {
        HAND,
        DAGGER,
        SWORD,
        TWOHAND_SWORD,
        BLUNT,
        SPEAR,
        TWOHAND_SPEAR,
        AXE,
        TWOHAND_AXE,
        WAND,
        TWOHAND_WAND,
        BOW,
        JAMADHAR
    }
    public enum ELEMENT_TYPE
    {
        NORMAL,
        WIND,
        EARTH,
        FIRE,
        WATER,
        POISON,
        HOLY,
        DARK,
        ASTRAL,
        UNDEAD
    }
    public enum EQUIP_DB_ENUM
    {
        HEAD,
        WEAPON,
        ARMOR,
        SUB_WEAPON,
        CLOAK,
        SHOES,
        ACC,
        COSTUME,
        BACK_DECO,
    }
    public enum EQUIP_REFINE_TYPE_ENUM
    {
        PHYSICAL_WEAPON,
        MAGICAL_WEAPON,
        ARMOR,
        HEAD,
        BACK_DECO
    }
}
