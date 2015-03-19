using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace DevSuperPowersDemo.Views
{
    public partial class DemoView : ContentPage
    {
        public DemoView()
        {
            InitializeComponent();
        }

        private void SayHellloButton_OnClicked(object sender, EventArgs e)
        {
            var name = NameEntry.Text;
            var greeting = "Hello " + name;
            GreetingLabel.Text = greeting;
        }
    }
}
