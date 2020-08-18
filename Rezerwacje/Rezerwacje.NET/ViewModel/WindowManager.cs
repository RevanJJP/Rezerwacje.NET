using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace Rezerwacje.NET.ViewModel
{
    class WindowManager
    {
        public static void ShowPopupMessage(string message)
        {
            MessageBox.Show(message);
        }
    }
}
