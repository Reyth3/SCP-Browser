using SCP_Browser.Models.Sources;
using SCP_Browser.ViewModel;
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
        List<SCPObject> listing;

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            source = e.Parameter as SCPSourceBase;
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if (source == null)
                Frame.GoBack();
            listing = await source.ListObjects();
            databaseListing.ItemsSource = listing;
            pw.IsActive = false;
        }

        private async void filterBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var d = this.Dispatcher;
            var query = (sender as TextBox).Text.ToLower().Trim();
            if (query.Length == 0)
                databaseListing.ItemsSource = listing;
            else
            {
                var filtered = await Task.Run(() => listing.Where(o => o.Id.ToLower().Contains(query) || o.Name.ToLower().Contains(query)));
                databaseListing.ItemsSource = filtered;
            }
        }

        private void ReadContent(object sender, ItemClickEventArgs e)
        {
            Frame.Navigate(typeof(Reader), e.ClickedItem);
        }
    }
}
