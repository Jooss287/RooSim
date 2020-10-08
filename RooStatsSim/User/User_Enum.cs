using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RooStatsSim.User
{
    enum LEVEL_ENUM : int
    {
        BASE = 0,
        BASE_POINT,
        JOB,
        JOB_POINT,
    }
    enum STATUS_ENUM : int
    {
        STR = 0,
        AGI,
        VIT,
        INT,
        DEX,
        LUK
    }
    enum MEDAL_ENUM : int
    {
        VALOR,
        GUARDIAN,
        WISDOM,
        CHARM,
        GALE,
    }
    enum MEDAL_ENUM_KOR : int
    {
        용맹훈장,
        수호훈장,
        지혜훈장,
        매력훈장,
        질풍훈장
    }
}
