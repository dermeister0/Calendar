//Copyright (c) 2012 Marco Franssen
//Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), 
//to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, 
//and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:
//The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
//THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, 
//FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, 
//DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE
//OR OTHER DEALINGS IN THE SOFTWARE.
using System;
using System.Windows.Media;

namespace CalendarApp.Util
{
    public static class PhoneThemeColors
    {
        private static Color _lime;
        public static Color Lime
        {
            get
            {
                return _lime;
            }
        }

        private static Color _green;
        public static Color Green
        {
            get
            {
                return _green;
            }
        }

        private static Color _emerald;
        public static Color Emerald
        {
            get
            {
                return _emerald;
            }
        }

        private static Color _teal;
        public static Color Teal
        {
            get
            {
                return _teal;
            }
        }

        private static Color _cyan;
        public static Color Cyan
        {
            get
            {
                return _cyan;
            }
        }

        private static Color _cobalt;
        public static Color Cobalt
        {
            get
            {
                return _cobalt;
            }
        }

        private static Color _indigo;
        public static Color Indigo
        {
            get
            {
                return _indigo;
            }
        }

        private static Color _violet;
        public static Color Violet
        {
            get
            {
                return _violet;
            }
        }

        private static Color _pink;
        public static Color Pink
        {
            get
            {
                return _pink;
            }
        }

        private static Color _magenta;
        public static Color Magenta
        {
            get
            {
                return _magenta;
            }
        }

        private static Color _crimson;
        public static Color Crimson
        {
            get
            {
                return _crimson;
            }
        }

        private static Color _red;
        public static Color Red
        {
            get
            {
                return _red;
            }
        }

        private static Color _orange;
        public static Color Orange
        {
            get
            {
                return _orange;
            }
        }

        private static Color _amber;
        public static Color Amber
        {
            get
            {
                return _amber;
            }
        }

        private static Color _yellow;
        public static Color Yellow
        {
            get
            {
                return _yellow;
            }
        }

        private static Color _brown;
        public static Color Brown
        {
            get
            {
                return _brown;
            }
        }

        private static Color _olive;
        public static Color Olive
        {
            get
            {
                return _olive;
            }
        }

        private static Color _steel;
        public static Color Steel
        {
            get
            {
                return _steel;
            }
        }

        private static Color _mauve;
        public static Color Mauve
        {
            get
            {
                return _mauve;
            }
        }

        private static Color _sienna;
        public static Color Sienna
        {
            get
            {
                return _sienna;
            }
        }

        public static Color FromHexa(string hexaColor)
        {
            return Color.FromArgb(
                Convert.ToByte(hexaColor.Substring(1, 2), 16),
                Convert.ToByte(hexaColor.Substring(3, 2), 16),
                Convert.ToByte(hexaColor.Substring(5, 2), 16),
                Convert.ToByte(hexaColor.Substring(7, 2), 16)
                );
        }

        static PhoneThemeColors()
        {
            _lime = FromHexa("#FFA4CC00");
            _green = FromHexa("#FF60A917");
            _emerald = FromHexa("#FF008A00");
            _teal = FromHexa("#FF00ABA9");
            _cyan = FromHexa("#FF1BA1E2");
            _cobalt = FromHexa("#FF0050EF");
            _indigo = FromHexa("#FF6A00FF");
            _violet = FromHexa("#FFAA00FF");
            _pink = FromHexa("#FFF47D02");
            _magenta = FromHexa("#FFD80073");
            _crimson = FromHexa("#FFA20025");
            _red = FromHexa("#FFE51400");
            _orange = FromHexa("#FFFA6800");
            _amber = FromHexa("#FFF0A30A");
            _yellow = FromHexa("#FFD8C100");
            _brown = FromHexa("#FF825A2C");
            _olive = FromHexa("#FF6D8764");
            _steel = FromHexa("#FF647687");
            _mauve = FromHexa("#FF76608A");
            _sienna = FromHexa("#FF7A3B3F");
        }
    }
}
