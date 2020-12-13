using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using RooStatsSim.Extension;
using RooStatsSim.DB.Table;
using RooStatsSim.Equation;
using RooStatsSim.Equation.Job;
using RooStatsSim.User;



namespace RooStatsSim.User
{
    [Serializable]
    public sealed class UserData
    {
        public UserData() { Initializor(); }

        public BASE_LEVEL Base_Level { get; set; }
        public JOB_LEVEL Job_Level { get; set; }
        public STATUS Status { get; set; }
        public JOB_SELECT_LIST Job { get; set; }
        [JsonIgnore]public JobSelect JobSelect { get; set; }

        public EQUIP Equip { get; set; }
        public GEAR Gear { get; set; }

        public MEDAL Medal { get; set; }
        public MONSTER_RESEARCH Monster_Research { get; set; }
        public DRESS_STYLE Dress_Style { get; set; }
        public STICKER Sticker { get; set; }
        public RIDING Riding_ability { get; set; }
        public RIDING Riding_personality { get; set; }
        
        public UserItem User_Item { get; set; }
        public UserSkill User_Skill { get; set; }
        public int SelectedEnemy { get; set; }

        public void Initializor()
        {
            Base_Level = new BASE_LEVEL();
            Job_Level = new JOB_LEVEL();
            Status = new STATUS();
            Job = JOB_SELECT_LIST.NOVICE;
            Equip = new EQUIP();
            Gear = new GEAR();
            Medal = new MEDAL();
            Monster_Research = new MONSTER_RESEARCH();
            Dress_Style = new DRESS_STYLE();
            Sticker = new STICKER();
            Riding_ability = new RIDING();
            Riding_personality = new RIDING();
            User_Item = new UserItem(true);
            User_Skill = new UserSkill();
            SelectedEnemy = 0;
        }
    }
}
