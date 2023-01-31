using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Input;

class App {
    [DllImport("user32.dll")]
    internal static extern void keybd_event(
        byte bVk,
        byte bScan,
        uint dwFlags,
        uint dwExtraInfo
    );

    private static void Larnab()
    {
        bool isLarnabOn = false;

        while (true)
        {
            if (Keyboard.IsKeyDown(Key.Space))
            {
                if (!isLarnabOn)
                    isLarnabOn = true;
            }

            if (isLarnabOn)
            {
                App.keybd_event(0x43, MapVirtualKey(0x43, 0), KEYEVENTF_EXTENDEDKEY, 0);
            }


            if (!Keyboard.IsKeyDown(Key.Space))
                isLarnabOn = false;

            Thread.Sleep(30);
        }
    }

    [STAThread]
    static void Main(string[] args) {
        Larnab();
    }
}