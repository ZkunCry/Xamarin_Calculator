using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CalculatorTest
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            BindingContext = new CalcViewModel();
            InitializeComponent();
        }
    }
}
