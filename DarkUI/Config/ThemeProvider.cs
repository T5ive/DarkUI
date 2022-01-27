using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

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

        public static void ThemeUpdate(Form form)
        {
            form.BackColor = Theme.Colors.GreyBackground;
            UpdateForm(form);
        }

        private static void UpdateForm(Form form)
        {
            foreach (var obj in form.Controls)
            {
                var control = (Control)obj;
                string[] ctrl = { "Button", "CheckBox", "ComboBox", "DataGridView", "Label", "LinkLabel", "ListBox", "ListView", "RadioButton", "RichTextBox", "TextBox" };
                string[] ctrlChild = { "GroupBox", "Panel", "TabPage", "Region", "DockGroup", "DockDocument" };

                if (CheckController(control, ctrl))
                {
                    UpdateColor(control);
                }

                if (CheckController(control, ctrlChild))
                {
                    UpdateChildControls(control);
                }
            }
        }

        private static void UpdateChildControls(Control control)
        {
            foreach (var obj in control.Controls)
            {
                var control2 = (Control)obj;
                string[] ctrl = { "Button", "CheckBox", "ComboBox", "DataGridView", "Label", "LinkLabel", "ListBox", "ListView", "RadioButton", "RichTextBox", "TextBox" };
                string[] ctrlChild = { "GroupBox", "Panel", "TabPage", "Region", "DockGroup", "DockDocument" };
                var a = control2.GetType().Name;
                if (CheckController(control2, ctrl))
                {
                    UpdateColor(control2);
                }
                if (CheckController(control2, ctrlChild))
                {
                    UpdateChildControls(control2);
                }
            }
        }

        private static bool CheckController(Control control, IEnumerable<string> ends)
        {
            return ends.Any(t => control.GetType().Name.EndsWith(t, StringComparison.OrdinalIgnoreCase));
        }

        private static void UpdateColor(Control control)
        {
            control.BackColor = Theme.Colors.GreyBackground;
            control.ForeColor = Theme.Colors.LightText;
        }
    }
}