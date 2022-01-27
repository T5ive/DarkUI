﻿using DarkUI.Controls;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace DarkUI.Config;

public static class Controller
{
    public static void ThemeUpdate(Form form, bool changed = false)
    {
        if (changed) return;
        form.BackColor = ThemeProvider.Theme.Colors.GreyBackground;
        GetControls(form);
        form.Refresh();
    }

    private static void GetControls(Form form)
    {
        foreach (var obj in form.Controls)
        {
            var control = (Control)obj;
            string[] ctrl = { "Button", "CheckBox", "ComboBox", "DataGridView", "Label", "LinkLabel", "ListBox", "ListView", "RadioButton", "RichTextBox", "TextBox", "StatusStrip", "MenuStrip" };
            string[] ctrlChild = { "GroupBox", "Panel", "TabPage", "Region", "DockGroup", "DockDocument" };
            var ctrlName = control.GetType().Name;
            if (CheckController(control, ctrl))
            {
                UpdateColor(control, ctrlName);
            }

            if (CheckController(control, ctrlChild))
            {
                GetChildControls(control);
            }
        }

    }

    private static void GetChildControls(Control control)
    {
        foreach (var obj in control.Controls)
        {
            var control2 = (Control)obj;
            string[] ctrl = { "Button", "CheckBox", "ComboBox", "DataGridView", "Label", "LinkLabel", "ListBox", "ListView", "RadioButton", "RichTextBox", "TextBox", "StatusStrip", "MenuStrip" };
            string[] ctrlChild = { "GroupBox", "Panel", "TabPage", "Region", "DockGroup", "DockDocument" };
            var ctrlName = control2.GetType().Name;
            if (CheckController(control2, ctrl))
            {
                UpdateColor(control2, ctrlName);
            }
            if (CheckController(control2, ctrlChild))
            {
                GetChildControls(control2);
            }
        }
    }

    private static void UpdateColor(Control control, string name)
    {
        if (name.IsEndsWith("DataGridView"))
        {
            UpdateDataGridView(control);
            return;
        }

        if (name.IsEndsWith("StatusStrip"))
        {
            UpdateStatusStrip(control);
            return;
        }

        if (name.IsEndsWith("MenuStrip"))
        {
            UpdateMenuStrip(control);
            return;

        }

        control.BackColor = ThemeProvider.Theme.Colors.GreyBackground;
        control.ForeColor = ThemeProvider.Theme.Colors.LightText;
    }

    #region Special Controls

    private static void UpdateDataGridView(Control control)
    {
        var obj = (DataGridView)control;
        obj.BackgroundColor = ThemeProvider.Theme.Colors.GreyBackground;
        obj.DefaultCellStyle.BackColor = ThemeProvider.Theme.Colors.GreyBackground;
        obj.DefaultCellStyle.ForeColor = ThemeProvider.Theme.Colors.LightText;
        obj.DefaultCellStyle.SelectionForeColor = ThemeProvider.Theme.Colors.LightText;
    }

    private static void UpdateStatusStrip(Control control)
    {
        var obj = (DarkStatusStrip)control;
        for (var i = 0; i < obj.Items.Count; i++)
        {
            obj.BackColor = ThemeProvider.Theme.Colors.GreyBackground;
            obj.ForeColor = ThemeProvider.Theme.Colors.LightText;
        }
    }

    private static void UpdateMenuStrip(Control control)
    {
        var obj = (MenuStrip)control;
        foreach (ToolStripMenuItem obj2 in obj.Items)
        {
            obj2.BackColor = ThemeProvider.Theme.Colors.GreyBackground;
            obj2.ForeColor = ThemeProvider.Theme.Colors.LightText;
            UpdateMenuStripChild(obj2);
        }
    }

    private static void UpdateMenuStripChild(ToolStripMenuItem obj)
    {
        for (var j = 0; j < obj.DropDownItems.Count; j++)
        {
            var obj2 = obj.DropDownItems[j];
            obj2.BackColor = ThemeProvider.Theme.Colors.GreyBackground;
            obj2.ForeColor = ThemeProvider.Theme.Colors.LightText;
            if (obj2.GetType().Name.IsEndsWith("MenuItem"))
            {
                var obj3 = (ToolStripMenuItem)obj2;
                UpdateMenuStripChild(obj3);
            }
        }
    }

    #endregion

    #region Utility

    private static bool CheckController(Control control, IEnumerable<string> ends)
    {
        return ends.Any(t => control.GetType().Name.EndsWith(t, StringComparison.OrdinalIgnoreCase));
    }
    private static bool IsEndsWith(this string value, string name)
    {
        return value.EndsWith(name, StringComparison.OrdinalIgnoreCase);
    }

    #endregion

}