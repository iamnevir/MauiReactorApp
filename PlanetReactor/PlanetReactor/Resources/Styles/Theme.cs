using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanetReactor.Resources.Styles;

public class Theme
{
    public static Color LightText = Color.FromArgb("#d5d5d5");
    public static Color Bg = Color.FromArgb("#191932");
    public static Color DarkText = Color.FromArgb("#252525");
    public static Color LightBorder = Color.FromArgb("#d5d5d5");
    public static Brush BgColor = new LinearGradientBrush(new GradientStopCollection
                {
                    new GradientStop(Color.FromArgb("#666666"),0.0f),
                    new GradientStop(Color.FromArgb("#000000"),1.0f),
                });
}
