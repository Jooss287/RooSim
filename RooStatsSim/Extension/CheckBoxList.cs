using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Controls;

namespace RooStatsSim.Extension
{
    class CheckBoxList : CheckBox
    {
        public String DisplayMemberPath
        {
            get { return (String)GetValue(DisplayMemberPathProperty); }
            set { SetValue(DisplayMemberPathProperty, value); }
        }

        // Using a DependencyProperty as the backing store for DisplayMemberPath.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DisplayMemberPathProperty =
             DependencyProperty.Register("DisplayMemberPath",
             typeof(String),
             typeof(CheckBoxList),
             new UIPropertyMetadata(String.Empty, (sender, args) =>
             {
                 CheckBoxList item = (CheckBoxList)sender;
                 Binding contentBinding = new Binding((String)args.NewValue);
                 item.SetBinding(ContentProperty, contentBinding);
             }));
    }
}
