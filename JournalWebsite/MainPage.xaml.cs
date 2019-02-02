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
using JournalWebsite.DataContext;
using JournalLibrary;

namespace JournalWebsite
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
            Header.Text = $"{UserInfo.Username}'s Journal";
            
            List<JournalList> mylist = ViewJournals.view(UserInfo.UserId);

            int total = mylist.Count();

            for (int count = 0; count < total; count++ )
            {
                string title = mylist[count].Title;
                string entry = mylist[count].Entry;


                Hyperlink link = new Hyperlink();

                link.Click += (object sender, RoutedEventArgs e) =>
                 {
       
                     NavigationService nav = NavigationService.GetNavigationService(this);
                     nav.Navigate(new ViewEntry(title, entry));
               
                 };

                link.Inlines.Add(title);
                TextBlock block = new TextBlock();
                block.Inlines.Add(link);
                stacker.Children.Add(block);

            }

        }

        private void EditProfile_Click(object sender, RoutedEventArgs e)
        {
            NavigationService navMP = NavigationService.GetNavigationService(this);     
            navMP.Navigate(new Uri("EditProfile.xaml", UriKind.Relative));
        }

        private void AddEntry_Click(object sender, RoutedEventArgs e)
        {
            NavigationService add = NavigationService.GetNavigationService(this);
            add.Navigate(new Uri("AddEntry.xaml", UriKind.Relative));
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            NavigationService logoff = NavigationService.GetNavigationService(this);
            logoff.Navigate(new Uri("LogIn.xaml", UriKind.Relative));
        }



    }
}
