using Raylib_CsLo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMB
{
    class Platforms
    {
        public Rectangle Rectangle { get; private set; }

        public Platforms(float x, float y, float width, float height)
        {
            Rectangle = new Rectangle(x, y, width, height);
        }

        public bool CheckCollision(Player player)
        {
            return Raylib.CheckCollisionRecs(Rectangle, player.Rectangle);
        }

        public void Draw()
        {
            Raylib.DrawRectangleRec(Rectangle, Raylib.BLUE);
        }
    }
}
