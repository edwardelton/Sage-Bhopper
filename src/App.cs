using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Input;

class App {
    [DllImport("user32.dll")]
    public static extern void keybd_event(uint bVk, uint bScan, uint dwFlags, uint dwExtraInfo);

    private static void Bhop()
    {
        Console.WriteLine("Bhop has started.");
        bool isToggled = false;
        bool isBhopOn = false;

        while (true)
        {
            if (Keyboard.IsKeyDown(Key.Insert))
            {
                isToggled = !isToggled;
                Thread.Sleep(500);
            }

            if (isToggled)
            {
                if (Keyboard.IsKeyDown(Key.Space))
                {
                    isBhopOn = true;
                }

                if (isBhopOn)
                {
                    keybd_event(0x43, 0, 0x0001, 0); // SENDING THE KEY C (My Key To Jump In VAL - Check this if you change it : http://www.kbdedit.com/manual/low_level_vk_list.html)
                } 


                if (isBhopOn && Keyboard.IsKeyUp(Key.Space))
                {
                    isBhopOn = false;
                }
            }
                
            Thread.Sleep(30);
        }
    }

    [STAThread]
    static void Main(string[] args) {
        Bhop();
    }
}
