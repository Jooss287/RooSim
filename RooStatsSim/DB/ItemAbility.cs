using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace RooStatsSim.DB
{
    public enum EQU_TYPE
    {
        HEAD_TOP,
        HEAD_MID,
        HEAD_BOTTOM,
        WEAPON_MAIN,
        WEAPON_SUB,
        CLOCK,
        SHOSE,
        ACCESSAIES1,
        ACCESSAIES2
    }
    
    class ItemAbility
    {
        

        public ItemAbility(EQU_TYPE equ_type, int card_slot, WEAPON_TYPE weapon_type = WEAPON_TYPE.HAND)
        {
            EQU_type = equ_type;
            CardSlot = card_slot;
            EQU_weapon_type = weapon_type;
        }
        
        //Equipment Type
        public readonly EQU_TYPE EQU_type;
        public readonly WEAPON_TYPE EQU_weapon_type;
        public readonly int CardSlot;


        //ATK
        public ATK atk;

        public int Pdamage_add;
        //public int Pdamage_

        
    }
}
