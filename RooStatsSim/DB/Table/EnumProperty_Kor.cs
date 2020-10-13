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
        public static Dictionary<DTYPE, string> DTYPE_KOR = new Dictionary<DTYPE, string>()
        {
            {DTYPE.ATK_P, "ATK %" },
            {DTYPE.MATK_P, "MATK %" },
            {DTYPE.PHYSICAL_DAMAGE, "물리 데미지" },
            {DTYPE.MAGICAL_DAMAGE, "마법 데미지" },
            {DTYPE.PHYSICAL_DEC_DAMAGE, "물리 데미지 감소" },
            {DTYPE.MAGICAL_DEC_DAMAGE, "마법 데미지 감소" },
            {DTYPE.DEF_P, "DEF %" },
            {DTYPE.MDEF_P, "MDEF %" },
            {DTYPE.MAX_HP_P, "HP %" },
            {DTYPE.MAX_SP_P, "SP %" },
            {DTYPE.ASPD, "ASPD" },
            {DTYPE.MOVING_SPEED,"이동속도" },
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
