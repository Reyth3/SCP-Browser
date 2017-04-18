using SCP_Browser.Models.Sources;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace SCP_Browser.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SCPListing : Page
    {
        public SCPListing()
        {
            this.InitializeComponent();
        }

        SCPSourceBase source;

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            source = e.Parameter as SCPSourceBase;
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if (source == null)
                Frame.GoBack();
            var listing = await source.ListObjects();
            databaseListing.ItemsSource = listing;
            pw.IsActive = false;
        }
    }
}
