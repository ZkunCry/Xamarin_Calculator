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
        private  Parser _parser = new Parser();

        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand AddNumber { get; set; }
        public ICommand Calculate { get; set; }
        public ICommand AddOperation { get; set; }
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
        public string ResultParsing
        {
            get => _calcModel.ResultParse;
            set 
            {
                if(_calcModel.ResultParse!= value)
                {
                    _calcModel.ResultParse = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ResultParsing)));
                }
            }
        }
      
        public CalcViewModel()
        {
            _calcModel = new CalcModel 
            { 
                ResultParse = "0", 
                StringParse = "" 
            };
            AddNumber = new Command<string>(AddNumbers);
            Calculate = new Command(DoCalculte);
            AddOperation = new Command<string>(AddOper);
        }
        private void AddNumbers(string number)
        {
            ParseStr += number;
        }
        private void AddOper(string Operation)
        {
            if ("+-/*".Contains(ParseStr[ParseStr.Length - 1].ToString()))
                return;
            ParseStr += Operation;
        }
        private void DoCalculte()
        {
            ParseStr = _parser.StartParsing(ParseStr).ToString();
            Console.WriteLine("fdsfd");
        }
    }
}
