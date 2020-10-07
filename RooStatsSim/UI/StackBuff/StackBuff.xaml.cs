using System.Windows;
using System.Collections.Generic;
using RooStatsSim.User;

namespace RooStatsSim.UI.StackBuff
{
    /// <summary>
    /// StackBuff.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class StackBuff : Window
    {
        UserData _user_data;
        List<StackBuffBinding> stack_buff;
        public StackBuff()
        {
            _user_data = UserData.GetInstance;

            InitializeComponent();

            stack_buff.Add(new StackBuffBinding("", _user_data.Monster_Research, 0));
            stack_buff.Add(new StackBuffBinding("", _user_data.Dress_Style, 0));
            stack_buff.Add(new StackBuffBinding("", _user_data.Sticker, 0));
            txt_monster_research.binding
            //txt_monster_research.Text = Convert.ToString(_user_data.)
        }
    }
}
