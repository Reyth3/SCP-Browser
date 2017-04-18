using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace SCP_Browser.UserControls
{
    public sealed partial class AccessVerification : UserControl
    {
        public AccessVerification()
        {
            this.InitializeComponent();
        }

        private void verificationProgress_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            if(sender != null)
            {
                var pitch = 1 + (verificationProgress.Value * 0.2);
                if(sfx.CurrentState == MediaElementState.Closed || sfx.CurrentState == MediaElementState.Paused || sfx.CurrentState == MediaElementState.Stopped)
                {
                    if (e.NewValue == 1)
                    {
                        sfx.Source = new Uri("ms-appx:///Assets/SFX/success.wav");
                    }
                    else sfx.Source = new Uri("ms-appx:///Assets/SFX/progressbar.wav");
                    sfx.Play();
                }
            }
        }

        private async void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            while(verificationProgress.Value < 1)
            {
                verificationProgress.Value += 0.1;
                await Task.Delay(100);
            }
            await Task.Delay(50);
            (this.Parent as Panel).Children.Clear();
        }
    }
}
