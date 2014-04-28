using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.ComponentModel;
using CalendarApp.Utils;
using System.Windows.Media;
using CalendarApp.ViewModels;

namespace CalendarApp.Controls
{
    public partial class LiveTileControl : UserControl
    {
        public LiveTileControl()
        {
            InitializeComponent();

            var vm = Ioc.Get<LiveTileViewModel>();

            if (DesignerProperties.GetIsInDesignMode(this))
            {
                vm.TileWidth = LiveTile.FlipMediumWidth * 653;
                vm.TileHeight = LiveTile.FlipMediumHeight;
                vm.ForegroundBrush = new SolidColorBrush(Colors.Black);
                vm.Day = 32;
            }
            else
            {
                vm.ForegroundBrush = App.Current.Resources["PhoneForegroundBrush"] as Brush;
            }
        }
    }
}
