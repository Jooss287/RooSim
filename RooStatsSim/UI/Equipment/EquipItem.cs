using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Windows.Media.Imaging;
using System.Windows.Controls;

using RooStatsSim.DB;

namespace RooStatsSim.UI.Equipment
{
    public class EquipTreeViewBinding : EquipId
    {
        public EquipTreeViewBinding(string name)
        {
            Name = name;
            SubList = new List<EquipTreeViewBinding>();
        }
        public EquipTreeViewBinding(ItemDB item)
        {
            Id = item.Id;
            Name = item.Name;
            Refine = 0;

            SubList = new List<EquipTreeViewBinding>();
        }
        public List<EquipTreeViewBinding> SubList { get; set; }

    }

    public class EquipId : INotifyPropertyChanged
    {
        string _name;
        int _id;
        int _refine;
        string _image_name;
        BitmapImage _image;

        public string Name
        {
            get { return _name; }
            set { _name = value; OnPropertyChanged("Name"); }
        }
        public int Id
        {
            get { return _id; }
            set { _id = value; OnPropertyChanged("Id"); }
        }
        public int Refine
        {
            get { return _refine; }
            set { 
                if ( ( value > 0) && ( value <= 15) )
                {
                    _refine = value;
                    OnPropertyChanged("Refine");
                }
            }   
        }
        public string ImageRoot
        {
            get { return _image_name; }
            set { _image_name = value; OnPropertyChanged("ImageRoot"); GetImage(); }
        }
        public BitmapImage ImageFile
        {
            get { return _image; }
        }
        void GetImage()
        {
            if (_image_name == null)
                return;

            var path = System.IO.Path.Combine(Environment.CurrentDirectory, "Img", _image_name);
            _image = new BitmapImage(new Uri(path));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public override string ToString() => _name;

        protected void OnPropertyChanged(string info)
        {
            var handler = PropertyChanged;
            handler?.Invoke(this, new PropertyChangedEventArgs(info));
        }
    }
}
