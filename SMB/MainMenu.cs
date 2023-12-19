using Raylib_CsLo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMB
{
    internal class MainMenu
    {
        public event EventHandler StartButton;
        public event EventHandler SettingsButton;
        public event EventHandler QuitButton;
        public void Draw()
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Raylib.BLACK);
            Raylib.DrawText("SMB", 150, 100, 50, Raylib.RED);
            if (RayGui.GuiButton(new Rectangle(240, 300, 200, 100), "start"))
            {
                StartButton.Invoke(this, EventArgs.Empty);
            }
            if (RayGui.GuiButton(new Rectangle(240, 500, 200, 100), "settings"))
            {
                SettingsButton.Invoke(this, EventArgs.Empty);
            }
            if (RayGui.GuiButton(new Rectangle(240, 700, 200, 100), "quit"))
            {
                QuitButton.Invoke(this, EventArgs.Empty);

            }
            Raylib.EndDrawing();
        }
    }
}
