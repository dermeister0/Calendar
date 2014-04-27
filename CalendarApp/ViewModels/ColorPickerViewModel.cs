using CalendarApp.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;

namespace CalendarApp.Models
{
    public class ColorItem
    {
        public string Name { get; set; }

        public Brush Brush { get; set; }
    }

    public class ColorPickerViewModel
    {
        public string Header { get; set; }

        public List<ColorItem> Colors { get; private set; }

        public ColorPickerViewModel()
        {
            Colors = new List<ColorItem>();

            foreach (var property in typeof(PhoneThemeColors).GetProperties())
            {
                var color = (Color)property.GetValue(null, null);

                Colors.Add(new ColorItem { Name = property.Name, Brush = new SolidColorBrush(color) });
            }
        }
    }
}
