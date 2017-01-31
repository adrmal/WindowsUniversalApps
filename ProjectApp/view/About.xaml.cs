using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace ProjectApp
{
    public sealed partial class About : Page
    {
        public About()
        {
            InitializeComponent();
        }

        private async void ContactWithMe_Click(object sender, RoutedEventArgs e)
        {
            Uri mailUri = new Uri("mailto:adr_mal@wp.pl");
            await Windows.System.Launcher.LaunchUriAsync(mailUri);
        }
    }
}
