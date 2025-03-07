﻿using System.Drawing;

namespace DarkUI.Config
{
    public class LightTheme : ITheme
    {
        public Sizes Sizes { get; } = new Sizes();

        public Colors Colors { get; } = new Colors();

        public LightTheme()
        {
            Colors.GreyBackground = Color.FromArgb(220, 223, 225); //Color.FromArgb(180, 183, 185);
            Colors.HeaderBackground = Color.FromArgb(210, 213, 215); //Color.FromArgb(177, 180, 182);
            Colors.BlueBackground = Color.FromArgb(200, 203, 205); //Color.FromArgb(186, 197, 215);
            Colors.DarkBlueBackground = Color.FromArgb(190, 193, 195); //Color.FromArgb(172, 177, 186);
            Colors.DarkBackground = Color.FromArgb(225, 228, 231); //Color.FromArgb(160, 160, 160);
            Colors.MediumBackground = Color.FromArgb(215, 218, 221); //Color.FromArgb(169, 171, 173);
            Colors.LightBackground = Color.FromArgb(192, 193, 194); //Color.FromArgb(189, 193, 194);
            Colors.LighterBackground = Color.FromArgb(182, 183, 184); //Color.FromArgb(100, 101, 102);
            Colors.LightestBackground = Color.FromArgb(128, 128, 128); //Color.FromArgb(178, 178, 178);
            Colors.LightBorder = Color.FromArgb(201, 201, 201);
            Colors.DarkBorder = Color.FromArgb(171, 171, 171);
            Colors.LightText = Color.FromArgb(50, 50, 50); //Color.FromArgb(20, 20, 20);
            Colors.DisabledText = Color.FromArgb(113, 113, 113); //Color.FromArgb(103, 103, 103);
            Colors.BlueHighlight = Color.DodgerBlue; //Color.FromArgb(104, 151, 187);
            Colors.BlueSelection = Color.FromArgb(75, 110, 175);
            Colors.GreyHighlight = Color.FromArgb(182, 188, 182);
            Colors.GreySelection = Color.FromArgb(160, 160, 160);
            Colors.DarkGreySelection = Color.FromArgb(202, 202, 202);
            Colors.DarkBlueBorder = Color.FromArgb(171, 181, 198);
            Colors.LightBlueBorder = Color.FromArgb(206, 217, 114);
            Colors.ActiveControl = Color.FromArgb(159, 178, 196);

            Sizes.Padding = 10;
            Sizes.ScrollBarSize = 15;
            Sizes.ArrowButtonSize = 15;
            Sizes.MinimumThumbSize = 11;
            Sizes.CheckBoxSize = 12;
            Sizes.RadioButtonSize = 12;
            Sizes.ToolWindowHeaderSize = 25;
            Sizes.DocumentTabAreaSize = 24;
            Sizes.ToolWindowTabAreaSize = 21;

        }
    }
}
