using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using app356.pages;
using Xamarin.Essentials;

namespace app356
{
    public partial class MainPage : TabbedPage
    {
        

        public MainPage()
        {
            InitializeComponent();

            this.Children.Add(new Page1());
            this.Children.Add(new Page2());
            this.Children.Add(new Page3());

        }
    }
}
