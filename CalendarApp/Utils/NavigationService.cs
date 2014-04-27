using Microsoft.Phone.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Navigation;

namespace CalendarApp.Util
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>http://blog.galasoft.ch/posts/2011/01/navigation-in-a-wp7-application-with-mvvm-light/</remarks>
    public class NavigationService
    {
        private PhoneApplicationFrame mainFrame;

        void CheckMainFrame()
        {
            if (mainFrame == null)
                mainFrame = App.Current.RootVisual as PhoneApplicationFrame;
        }

        public void Navigate(string uri)
        {
            CheckMainFrame();

            if (mainFrame != null)
                mainFrame.Navigate(new Uri(uri, UriKind.Relative));
        }

        public JournalEntry RemoveBackEntry()
        {
            CheckMainFrame();

            if (mainFrame != null)
                return mainFrame.RemoveBackEntry();

            return null;
        }
    }
}
