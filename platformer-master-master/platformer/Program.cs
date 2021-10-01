using System;
using SFML.System;
using SFML.Window;
using SFML.Graphics;

namespace platformer
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var Window = new RenderWindow(
                new VideoMode(800, 600), "Platformer"))
            {
                Window.Closed += (o, e) => Window.Close();
                Clock clock = new Clock();

                Scene scene = new Scene();

            

                scene.Load("level0");

                Window.SetView(new View(
                    new Vector2f(200, 150),
                    new Vector2f(400, 300)));

                while (Window.IsOpen)
                {
                    Window.DispatchEvents();
                    float deltaTime = clock.Restart().AsSeconds();
                    Window.Clear();
                    
                    scene.UpdateAll(deltaTime);
                    scene.renderAll(Window);
                    
                    Window.Display();
                    
                }
            }
        }
    }
}
