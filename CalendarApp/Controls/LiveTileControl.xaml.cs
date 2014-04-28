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
        public class Test
        {
            public int Day { get; set; }
        }

        public LiveTileControl()
        {
            InitializeComponent();

            if (DesignerProperties.GetIsInDesignMode(this))
            {
                var vm = Ioc.Get<LiveTileViewModel>();
                vm.TileWidth = LiveTileGenerator.FlipMediumWidth;
                vm.TileHeight = LiveTileGenerator.FlipMediumHeight;
                vm.ForegroundBrush = new SolidColorBrush(Colors.Black);
                vm.Day = 32;
                DataContext = vm;
            }
        }
    }
}
