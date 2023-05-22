using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
namespace CalculatorTest
{
    class CalcViewModel:INotifyPropertyChanged
    {
        private CalcModel _calcModel;

        public event PropertyChangedEventHandler PropertyChanged;

        public string ParseStr { get=>_calcModel.StringParse; 
            set 
            { 
                if(_calcModel.StringParse!=value)
                {
                    _calcModel.StringParse = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ParseStr)));
                }
            }
        }
        public ICommand AddNumber { get; set; }
        public CalcViewModel()
        {
            _calcModel = new CalcModel 
            { 
                ResultParse = "0", 
                StringParse = "" 
            };
            AddNumber = new Command<string>(AddNumbers);
        }
        private void AddNumbers(string number)
        {
            ParseStr += number;
        }
    }
}
