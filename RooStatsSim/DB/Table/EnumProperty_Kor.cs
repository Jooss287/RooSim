using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RooStatsSim.DB;
using RooStatsSim.User;

namespace RooStatsSim.DB.Table
{
    class EnumProperty_Kor
    {
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
            {ITYPE.CRI,"CIR" },
            {ITYPE.CDEF,"CDEF" },
        };
        public static Dictionary<DTYPE, string> DTYPE_KOR = new Dictionary<DTYPE, string>()
        {
            {DTYPE.ATK_P, "ATK %" },
            {DTYPE.MATK_P, "MATK %" },
            {DTYPE.PHYSICAL_DAMAGE, "물리 데미지(%)" },
            {DTYPE.MAGICAL_DAMAGE, "마법 데미지(%)" },
            {DTYPE.PHYSICAL_DEC_DAMAGE, "물리 데미지 감소(%)" },
            {DTYPE.MAGICAL_DEC_DAMAGE, "마법 데미지 감소(%)" },
            {DTYPE.DEF_P, "DEF %" },
            {DTYPE.MDEF_P, "MDEF %" },
            {DTYPE.MAX_HP_P, "HP %" },
            {DTYPE.MAX_SP_P, "SP %" },
            {DTYPE.ASPD, "ASPD" },
            {DTYPE.MOVING_SPEED,"이동속도" },
        };
        public static Dictionary<STATUS_EFFECT_TYPE, string> STATUS_EFFECT_TYPE_KOR = new Dictionary<STATUS_EFFECT_TYPE, string>()
        {
            {STATUS_EFFECT_TYPE.STERN, "스턴" },
            {STATUS_EFFECT_TYPE.FEAR, "공포" },
            {STATUS_EFFECT_TYPE.SILENCE, "침묵" },
            {STATUS_EFFECT_TYPE.FROZEN, "동빙" },
            {STATUS_EFFECT_TYPE.CURSE, "저주" },
            {STATUS_EFFECT_TYPE.PETRIFICATION, "석화" },
        };
        
        public static Dictionary<ELEMENT_TYPE, string> ELEMENT_TYPE_KOR = new Dictionary<ELEMENT_TYPE, string>()
        {
            {ELEMENT_TYPE.NORMAL, "무속성" },
            {ELEMENT_TYPE.WIND, "풍속성" },
            {ELEMENT_TYPE.EARTH, "지속성" },
            {ELEMENT_TYPE.FIRE, "지속성" },
            {ELEMENT_TYPE.WATER, "수속성" },
            {ELEMENT_TYPE.POISON, "독속성" },
            {ELEMENT_TYPE.HOLY, "성속성" },
            {ELEMENT_TYPE.DARK, "암속성" },
            {ELEMENT_TYPE.ASTRAL, "염속성" },
            {ELEMENT_TYPE.UNDEAD, "불사속성" },
        };
        public static Dictionary<TRIBE_TYPE, string> TRIBE_TYPE_KOR = new Dictionary<TRIBE_TYPE, string>()
        {
            {TRIBE_TYPE.ANIMAL, "동물형" },
            {TRIBE_TYPE.PLANT, "식물형" },
            {TRIBE_TYPE.INSECT, "곤충형" },
            {TRIBE_TYPE.HUMAN, "인간형" },
            {TRIBE_TYPE.SEAFOOD, "어패형" },
            {TRIBE_TYPE.DEVIL, "악마형" },
            {TRIBE_TYPE.DRAGON, "용족" },
            {TRIBE_TYPE.NONE, "무형" },
            {TRIBE_TYPE.ANGEL, "천사형" },
            {TRIBE_TYPE.UNDEAD, "불사형" },
        };
        public static Dictionary<MONSTER_SIZE, string> MONSTER_SIZE_KOR = new Dictionary<MONSTER_SIZE, string>()
        {
            {MONSTER_SIZE.SMALL, "소형" },
            {MONSTER_SIZE.MIDDLE, "중형" },
            {MONSTER_SIZE.LARGE, "대형" },
        };
        public static Dictionary<MONSTER_TYPE, string> MONSTER_TYPE_KOR = new Dictionary<MONSTER_TYPE, string>()
        {
            {MONSTER_TYPE.NORMAL, "일반" },
            {MONSTER_TYPE.MINI, "MINI" },
            {MONSTER_TYPE.MVP, "MVP" },
        };

        public static Dictionary<MEDAL_ENUM, string> MEDAL_ENUM_KOR = new Dictionary<MEDAL_ENUM, string>()
        {
            {MEDAL_ENUM.VALOR, "용맹훈장" },
            {MEDAL_ENUM.GUARDIAN, "수호훈장" },
            {MEDAL_ENUM.WISDOM, "지혜훈장" },
            {MEDAL_ENUM.CHARM, "매력훈장" },
            {MEDAL_ENUM.GALE, "질풍훈장" },
        };

        public static Dictionary<RIDING_ENUM, string> RIDING_ENUM_KOR = new Dictionary<RIDING_ENUM, string>()
        {
            {RIDING_ENUM.ATK_MATK, "ATK/MATK" },
            {RIDING_ENUM.MAX_HP, "MAX_HP" },
            {RIDING_ENUM.ATK_MATK_PERCENT, "ATK%/MATK%" },
        };
    }
}
