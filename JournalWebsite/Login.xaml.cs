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
 
    public partial class Login : Page
    {
        public Login()
        {
            InitializeComponent();
        }

        private void LogButton_Click(object sender, RoutedEventArgs e)
        {
            User user1 = new User();
            user1.UserName = Ubox.Text.Trim();
            user1.Password = Pbox.Text.Trim();
            User LogIn = Access.login(user1);

            if (LogIn != null)
            {
                UserInfo.UserId = LogIn.LoginId;
                UserInfo.Username = LogIn.UserName;

                NavigationService log = NavigationService.GetNavigationService(this);
                log.Navigate(new Uri("MainPage.xaml", UriKind.Relative));
             
            }
            else
            {
                Invalid.Foreground.Opacity = 100;
            }
        }
        private void RegButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService reg = NavigationService.GetNavigationService(this);

            reg.Navigate(new Uri("Register.xaml", UriKind.Relative));
        }
    }
}
