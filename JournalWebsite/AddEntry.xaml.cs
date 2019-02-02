using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using JournalLibrary;
using JournalWebsite.DataContext;

namespace JournalWebsite
{
    /// <summary>
    /// Interaction logic for AddEntry.xaml
    /// </summary>
    public partial class AddEntry : Page
    {
        public AddEntry()
        {
            InitializeComponent();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            JournalList newentry = new JournalList();
            newentry.LogID = UserInfo.UserId;
            newentry.Title = Titlebox.Text.Trim();
            newentry.Entry = Entrybox.Text.Trim();

            JournalList newentry2 = Entry.entry(newentry);

            if (newentry2 == null)
            {
                NoEntry.Foreground.Opacity = 100;
            }
            else
            {

                NavigationService main = NavigationService.GetNavigationService(this);
                main.Navigate(new Uri("MainPage.xaml", UriKind.Relative));
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {

            NavigationService main = NavigationService.GetNavigationService(this);
            main.Navigate(new Uri("MainPage.xaml", UriKind.Relative));

        }
    }
}
