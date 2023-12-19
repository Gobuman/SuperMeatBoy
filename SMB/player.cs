using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using MiNET;
using MiNET.Effects;
using Raylib_CsLo;


namespace SMB
{
    class Player
    {
        public Rectangle Rectangle { get; private set; }
        public Vector2 position;
        public Vector2 velocity;
        private float xSpeed;
        private float ySpeed = 100;
        private float gravity = 200f;

        public float jumpForce = -200f;
        public bool isJumping = false;


        public Player(Vector2 position, float xSpeed)
        {
            Rectangle = new Rectangle(400, 200, 50, 50);
            this.position = position;
            this.xSpeed = xSpeed / 50;
        }

        public void Update()
        {
            float deltaTime = Raylib.GetFrameTime();

            
            
            if (isJumping) 
            {
                velocity.Y += gravity * deltaTime;
                
            }

            else 
            {
                velocity.Y = 0;
            }

            //deltaTime doesnt work
            if (Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT) && position.X < Raylib.GetScreenWidth() - 50)
            {
                velocity.X += xSpeed;
            }

            if (Raylib.IsKeyDown(KeyboardKey.KEY_LEFT) && position.X > 0)
            {
                velocity.X -= xSpeed;
            }

            if (velocity.X > 0 && position.X > Raylib.GetScreenWidth() - 50)
            {
                velocity.X = 0;
            }
            if (velocity.X < 0 && position.X < 0)
            {
                velocity.X = 0;
            }





            if (Raylib.IsKeyPressed(KeyboardKey.KEY_SPACE)) 
            {

                velocity.Y += jumpForce;
                isJumping = true;
            }

            if (position.Y > Raylib.GetScreenHeight() - 50)
            {
                position.Y = Raylib.GetScreenHeight() - 50;
                isJumping = false;
                velocity.Y = 0;
            }


            position += velocity * deltaTime;
            // Handle input, collisions, etc.
        }

        public void Draw()
        {
            Raylib.DrawRectangle((int)position.X, (int)position.Y, 50, 50, Raylib.RED);
        }
    }
}
