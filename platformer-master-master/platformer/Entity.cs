using System;
using SFML.System;
using SFML.Window;
using SFML.Graphics;

namespace platformer
{
    public class Entity
    {
        private readonly string textureName;
        protected readonly Sprite sprite;
        public bool Dead;
        public virtual bool Solid => false;

        protected Entity(string textureName)
        {
            this.textureName = textureName;
            sprite = new Sprite();
        }
        public Vector2f Position
        {
            get => sprite.Position;
            set => sprite.Position = value;
        }
        public virtual FloatRect Bounds => sprite.GetGlobalBounds();
        public virtual void Create(Scene scene)
        {
            //vad ska vi skriva här? det står att man ska implementera positions, bounds, ypdate, render. 
            sprite.Texture = scene.LoadTexture(textureName);
        }
        public virtual void Update(Scene scene, float deltaTime)
        {

        }
        public virtual void render(RenderTarget target)
        {
            target.Draw(sprite);
        }


    }
}
