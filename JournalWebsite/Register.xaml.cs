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
    public partial class Register : Page
    {
        public Register()
        {
            InitializeComponent();
        }

        private void RegButton_Click(object sender, RoutedEventArgs e)
        {
            User user = new User();
            user.UserName = Ubox.Text.Trim();
            user.Password = Pbox.Text.Trim();

            User reg = Access.register(user);

            if (reg == null)
            {
                TAKEN.Foreground.Opacity = 100;
            }

            else if (reg.Password == "" || reg.Password.Length < 1)
            {
                NoPass.Foreground.Opacity = 100;
            }
            else
            {
                UserInfo.UserId = reg.LoginId;
                UserInfo.Username = reg.UserName;

                NavigationService regbutton = NavigationService.GetNavigationService(this);

               
                regbutton.Navigate(new Uri("MainPage.xaml", UriKind.Relative));
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService back = NavigationService.GetNavigationService(this);
            back.Navigate(new Uri("Login.xaml", UriKind.Relative));
        }
    }
}
