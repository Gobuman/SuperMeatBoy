using MiNET.Effects;
using Raylib_CsLo;
using System.Numerics;

namespace SMB
{
    public class Program
    {
        private List<Platforms> platforms;
        MainMenu menu = new MainMenu();

        private const int screenWidth = 800;
        private const int screenHeight = 450;

        public bool GameRunning = true;

        private Player player;

        enum gamestate
        {
            mainmenu,
            gameplay,
            settings,
            pause
        }

        gamestate currentstate;
        void init()
        {
            //MainMenu Button
            menu.StartButton += OnStartButton;
            menu.SettingsButton += OnSettingsButton;
            menu.QuitButton += OnQuitButton;
        }

        void OnStartButton(Object sender, EventArgs e)
        {
            currentstate = gamestate.gameplay;
        }

        void OnSettingsButton(Object sender, EventArgs e)
        {
            currentstate = gamestate.settings;
        }

        void OnQuitButton(Object sender, EventArgs e)
        {
            GameRunning = false;
        }

        static void Main(string[] args)
        {
            Program game = new Program();
            game.Run();
        }

    


        public Program()
        {
            platforms = new List<Platforms>
            {
                new Platforms(100, 300, 200, 20),
                new Platforms(400, 250, 150, 20)
            };
            Raylib.InitWindow(screenWidth, screenHeight, "Super Meat Boy");
            player = new Player(new Vector2(screenWidth / 2, screenHeight - 50), 1);
        }



        public void Run()
        {
            init();

            while (!Raylib.WindowShouldClose() && GameRunning)
            {
                switch (currentstate)
                {
                    case gamestate.mainmenu:
                        menu.Draw();
                        break;
                    case gamestate.gameplay:
                        Update();
                        Draw();
                        break;
                }
            }


            Raylib.CloseWindow();
        }

        private void Update()
        {
            foreach (var platform in platforms)
            {
                if (platform.CheckCollision(player))
                {
                    // Adjust player position or behavior as needed when colliding with a platform
                    player.position.Y = platform.Rectangle.y - player.Rectangle.height;
                    player.isJumping = false; // Reset jump flag when colliding with a platform
                    player.jumpForce = 0; // Stop vertical movement when colliding with a platform
                }
            }

            player.Update();

            // Add other updates for game elements, levels, etc.
        }



        private void Draw()
        {

            Raylib.BeginDrawing();
            Raylib.ClearBackground(Raylib.WHITE);

            foreach (var platform in platforms)
            {
                platform.Draw();
            }

            player.Draw();

            // Add other draw calls for game elements, levels, etc.

            Raylib.EndDrawing();
        }
    }

    

}
