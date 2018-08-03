using RLNET;
using System.Windows.Forms;


public class Engine
{
    private RLRootConsole rootConsole;
    private int playerX;
    private int playerY;
    public static Keys ModifierKeys { get; }

    bool isFullscreen = false;

    public Engine(RLRootConsole console)
    {
        rootConsole = console;

        playerY = rootConsole.Height / 2;
        playerX = rootConsole.Width / 2;

        rootConsole.Render += Render;
        rootConsole.Update += Update;
    }

    public void Render(object sender, UpdateEventArgs e)
    {
        rootConsole.Clear();
        rootConsole.Set(playerX, playerY, RLColor.White, null, '@');
        rootConsole.Draw();
    }

    public void Update(object sender, UpdateEventArgs e)
    {
        RLKeyPress keyPress = rootConsole.Keyboard.GetKeyPress();
        RLMouse rLMouse = rootConsole.Mouse;


        if (keyPress != null)
        {
            switch (keyPress.Key)
            {
                case RLKey.Up: playerY--; break;
                case RLKey.Down: playerY++; break;
                case RLKey.Left: playerX--; break;
                case RLKey.Right: playerX++; break;

                case RLKey.Escape: rootConsole.Close(); break; 
            }

            if(keyPress.Alt)
            {
                switch (keyPress.Key)
                {
                    case RLKey.Enter: ToggleFullscreen(); break;
                }
            }

        }
    }
    public void ToggleFullscreen()
    {
        if (isFullscreen)
        {
            rootConsole.SetWindowState(RLWindowState.Normal);
        }
        else
        {
            rootConsole.SetWindowState(RLWindowState.Fullscreen);
        }
        isFullscreen = !isFullscreen;
    }
}
