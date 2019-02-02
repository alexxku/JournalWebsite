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
    /// Interaction logic for EditProfile.xaml
    /// </summary>
    public partial class EditProfile : Page
    {
        public EditProfile()
        {
            InitializeComponent();
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            User UpdateProfile = new User();
            UpdateProfile.UserName = Ubox.Text.Trim();
            UpdateProfile.Password = Pbox.Text.Trim();

            User updatedProfile = Profile.editProfile(UpdateProfile, UserInfo.UserId);

            if (updatedProfile == null)
            {
              
                Taken.Foreground.Opacity = 100;
            }
            else if (updatedProfile.Password == "" || updatedProfile.Password.Length < 1)
            {
                Taken.Foreground.Opacity = 0;
                Invalid.Foreground.Opacity = 100;
            }
            else
            {
                UserInfo.Username = updatedProfile.UserName;

                NavigationService B = NavigationService.GetNavigationService(this);

                B.Navigate(new Uri("MainPage.xaml", UriKind.Relative));
            }
           
        }

        private void B_Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService B = NavigationService.GetNavigationService(this);

            B.Navigate(new Uri("MainPage.xaml", UriKind.Relative));

        }
    }
}
