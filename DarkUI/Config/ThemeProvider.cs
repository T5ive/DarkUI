using System.ComponentModel;

namespace DarkUI.Config
{
    public class ThemeProvider
    {
        internal static ThemeProvider This = new ThemeProvider();

        internal static event PropertyChangedEventHandler PropertyChanged;

        internal static event PropertyChangedEventHandler PropertyChangedInstance;

        internal static void OnPropertyChangedInstance(string name)
        {
            PropertyChangedInstance?.Invoke(This, new PropertyChangedEventArgs(name));
        }

        internal static void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(null, new PropertyChangedEventArgs(name));
        }

        private static ITheme _theme;

        public static ITheme Theme
        {
            get => _theme ?? (_theme = new DarkTheme());
            set
            {
                if (value != _theme)
                {
                    _theme = value;
                    OnPropertyChanged("Theme");
                    OnPropertyChangedInstance("Theme");
                }
            }
        }
    }
}