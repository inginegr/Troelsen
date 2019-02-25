using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;


namespace WpfTestApp.Models
{
    public class Inventory : INotifyPropertyChanged
    {
        private int carid;
        private string make;
        private string color;
        private string petname;
        private bool ischanged;


        public int CarId
        {
            get { return carid; }
            set
            {
                if (value == carid) return;
                carid = value;
                OnPropertyChanged();
            }
        }

        public string Make
        {
            get { return make; }
            set
            {
                if (value == make) return;
                make = value;
                OnPropertyChanged();
            }
        }

        public string Color
        {
            get { return color; }
            set
            {
                if (value == color) return;
                color = value;
                OnPropertyChanged();
            }
        }

        public string PetName
        {
            get { return petname; }
            set
            {
                if (value == petname) return;
                petname = value;
                OnPropertyChanged();
            }
        }

        public bool IsChanged
        {
            get { return ischanged; }
            set
            {
                if (value == ischanged) return;
                ischanged = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (propertyName != nameof(ischanged))
                ischanged = true;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
