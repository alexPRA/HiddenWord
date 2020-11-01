using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls.Primitives;

namespace TP_FINAL
{
    public class CustomRepeatButton : RepeatButton
    {
        public int buttonState = -1,btnROW,btnCOL;
        //buttonState: -1 -> has no significant impact on the program
        //buttonState: 0 -> when PreviewMouseDown(LeftClick) is activated, the mouse passes over
        //buttonState: 1 -> is part of a word when it mouse is released
        public CustomRepeatButton()
        {
            this.Style = new Style(GetType(), this.FindResource(typeof(System.Windows.Controls.Primitives.RepeatButton)) as Style);
        }
    }
}
