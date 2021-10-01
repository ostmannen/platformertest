using System;
using SFML.System;
using SFML.Window;
using SFML.Graphics;

namespace platformer
{
    public class Door : Entity
    {
        public string NextRoom;
        public bool Unlocked;
        public Door() : base("tileset")
        {
            sprite.TextureRect = new IntRect(180, 103, 18, 23);
            sprite.Origin = new Vector2f(9, 9);
            

        }
        public override void Update(Scene scene, float deltaTime)
        {
            if(Unlocked == true) 
            {
                sprite.Color = Color.Black;
                if (scene.FindByType<Hero>(out Hero hero)){
                    if (Collision.RectangleRectangle(Bounds, hero.Bounds, out _)){
                        scene.Load("level1");
                        
                    }
                }
            }                          
        }
        public override void render(RenderTarget target){
            base.render(target);
        }
    }
}
