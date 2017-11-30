using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace InstantMessagingWindowsApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Chat : Page
    {
        ActionManager ac1 = new ActionManager();
        private ObservableCollection<Message> Messages;
        public Chat()
        {
            Messages = new ObservableCollection<Message>();
            this.InitializeComponent();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            User user = (User)e.Parameter;
            if(user!=null)
            {
                tbTo.Text = user.PhoneNo;
                string phNumber = tbTo.Text;
                tbTo.IsReadOnly =true;
                List<Message> listMessages = ac1.getMessages(SharedData.LoggedInUser.PhoneNo, phNumber);
                Messages.Clear();
                foreach (Message m in listMessages)
                {
                    Messages.Add(m);
                }
            }
            else
            {
                tbTo.Text = "";
                tbTo.IsReadOnly = false;
                Messages.Clear();
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            tbTo.IsReadOnly = true;
            string messageText = tbmesgtx.Text;
            string phNumber =tbTo.Text;
            ac1.SendMessage(SharedData.LoggedInUser,phNumber,messageText);

            List<Message> listMessages = ac1.getMessages(SharedData.LoggedInUser.PhoneNo, phNumber);
            Messages.Clear();
            foreach(Message m in listMessages)
            {
                Messages.Add(m);
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.GoBack();
        }

    }
}
