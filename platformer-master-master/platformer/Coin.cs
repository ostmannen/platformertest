using System;
using SFML.System;
using SFML.Window;
using SFML.Graphics;

namespace platformer
{
    public class Coin : Entity
    {
        public static int coins;
         public Coin() : base("tileset")
        {
            sprite.TextureRect = new IntRect(200, 127, 16, 16);
            sprite.Origin = new Vector2f(8, 8);          
        } 
        public override void Update(Scene scene, float deltaTime){
            if (scene.FindByType<Hero>(out Hero hero)){
                if(Collision.RectangleRectangle(Bounds, hero.Bounds, out _)){
                    if (scene.FindByType<Gui>(out Gui gui)){
                        gui.coins++;
                    }
                    Dead = true;
                }
            }
        }
    }
}
