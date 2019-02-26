using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;


namespace WpfTestApp.Models
{
    public partial class Inventory : IDataErrorInfo
    {
        Dictionary<string, List<string>> dct = new Dictionary<string, List<string>>();
        event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        private string _error;
        public string this[string columnName]
        {
            get
            {
                switch (columnName)
                {
                    case nameof(CarId):
                        break;
                    case nameof(Make):
                        if (Make == "ModelT")
                            return "Too Old";
                        return CheckMakeAndColor();
                    case nameof(Color):
                        return CheckMakeAndColor();
                    case nameof(PetName):
                        break;
                }
                return string.Empty;
            }
        }
        internal string CheckMakeAndColor()
        {
            if (Make == "Chevy" && Color == "Pink")
                return $"{Make}'s don't come in color {Color}";
            return string.Empty;
        }
        public string Error { get => _error; }


    }
}
