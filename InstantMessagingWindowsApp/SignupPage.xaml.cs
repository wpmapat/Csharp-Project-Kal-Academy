using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace InstantMessagingWindowsApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SignupPage : Page
    {
        public SignupPage()
        {
            this.InitializeComponent();
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            ActionManager ac1 = new ActionManager();
            User user1 = new User(tName.Text, tbPhoneno.Text, tbEmailAddress.Text, tbPassword.Text);
            bool value=ac1.CreateAccount(user1);
            if (value == true)
            {
                var dialog = new MessageDialog("User creation succeeded");
                dialog.ShowAsync();
                this.Frame.Navigate(typeof(LoginPage), null);
            }
            else
            {
                var dialog = new MessageDialog("User creation failed.");
                dialog.ShowAsync();
            }
                   
        }
    }
}
