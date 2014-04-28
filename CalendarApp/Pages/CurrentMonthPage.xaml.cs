using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace CalendarApp.Pages
{
    public partial class CurrentMonthPage : PhoneApplicationPage
    {
        public CurrentMonthPage()
        {
            InitializeComponent();

            var content = Application.Current.Host.Content;
            var minSize = Math.Min(content.ActualWidth, content.ActualHeight);
            var weekDayFontSize = (double)App.Current.Resources["PhoneFontSizeMedium"];

            CurrentMonthGrid.Width = minSize - weekDayFontSize;
            CurrentMonthGrid.Height = minSize;            
        }

        protected override void OnOrientationChanged(OrientationChangedEventArgs e)
        {
            base.OnOrientationChanged(e);
        }

        private void SwipeContentControl_SwipeLeft(object sender, EventArgs e)
        {
            CurrentMonthGrid.NextMonth();
        }

        private void SwipeContentControl_SwipeRight(object sender, EventArgs e)
        {
            CurrentMonthGrid.PreviousMonth();
        }
    }
}