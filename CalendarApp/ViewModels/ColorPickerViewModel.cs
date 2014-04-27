using CalendarApp.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;
using Media = System.Windows.Media;

namespace CalendarApp.Models
{
    public class ColorItem
    {
        public ColorItem(Color color)
        {
            Color = color;
            Brush = new SolidColorBrush(color);
        }

        public Color Color { get; private set; }

        public string Name { get; set; }

        public Brush Brush { get; private set; }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is ColorItem))
                return false;

            return Color.Equals((obj as ColorItem).Color);
        }

        public override int GetHashCode()
        {
            return Color.GetHashCode();
        }
    }

    public class ColorPickerViewModel
    {
        public string Header { get; set; }

        public List<ColorItem> Colors { get; private set; }

        ColorItem selectedColor;

        public ColorItem SelectedColor
        {
            get { return selectedColor; }
            set
            {
                if (!Colors.Contains(value))
                    Colors.Add(value);

                selectedColor = value;
            }
        }

        public ColorPickerViewModel()
        {
            Colors = new List<ColorItem>();

            foreach (var property in typeof(PhoneThemeColors).GetProperties())
            {
                var color = (Color)property.GetValue(null, null);

                Colors.Add(new ColorItem(color) { Name = property.Name });
            }

            Colors.Add(new ColorItem(System.Windows.Media.Colors.Black) { Name = "Black" });
            Colors.Add(new ColorItem(Media.Colors.White) { Name = "White" });
        }
    }
}
