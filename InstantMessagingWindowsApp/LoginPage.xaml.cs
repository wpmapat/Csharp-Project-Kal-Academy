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
using Windows.UI.Popups;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace InstantMessagingWindowsApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LoginPage : Page
    {
        public LoginPage()
        {
            this.InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            ActionManager ac1 = new ActionManager();
            User u1 = ac1.LoginUser(tbUserName.Text, tbPassword.Text);

            //{
            //var dialog = new MessageDialog("User creation succeeded");
            //dialog.ShowAsync();
            //this.Frame.Navigate(typeof(LoginPage), null);
            //}

            if (u1 == null)
            {
                var dialog = new MessageDialog("User creation failed.");
                dialog.ShowAsync();
            }
            else
            {
                this.Frame.Navigate(typeof(ConversationsPage), null);
            }
        }

        /// <summary>
        /// This code will navigate to Signup page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSignup_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(SignupPage), null);
        }

    }
}
