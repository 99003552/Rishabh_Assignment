using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Rishabh_Assignment.CustomControls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BusyView : ContentView
    {
        public string Message
        {
            get => (string)GetValue(MessageProperty);
            set => SetValue(MessageProperty, value);
        }
        public static readonly BindableProperty MessageProperty=
            BindableProperty.Create(
               "Message",typeof(string),
               typeof(BusyView),
               "Connecting...",
               BindingMode.OneWay,
               null,
               messageChanged
                );
        public BusyView()
        {
            InitializeComponent();
        }

        private static void messageChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = bindable as BusyView;
            control.messageLabel.Text = newValue.ToString();
        }
    }
}