using System;
using SFML.System;
using SFML.Window;
using SFML.Graphics;

namespace platformer
{
    public class Hero : Entity
    {
        public const float WalkSpeed = 100.0f;
        public const float JumpForce = 250.0f;
        public const float GravityForce = 400.0f;
        private float vertocalSpeed;
        public bool isgrounded;
        public bool isUpPressed;
        private bool faceRight = false;
        public Hero() : base("characters")
        {
            sprite.TextureRect = new IntRect(0, 0, 24, 24);
            sprite.Origin = new Vector2f(12, 12);
        }
        public override void Update(Scene scene, float deltaTime)
        {

            if (Keyboard.IsKeyPressed(Keyboard.Key.Left))
            {
                scene.TryMove(this, new Vector2f(-WalkSpeed * deltaTime, 0));
                faceRight = false;
            }
            else if (Keyboard.IsKeyPressed(Keyboard.Key.Right))
            {
                scene.TryMove(this, new Vector2f(WalkSpeed * deltaTime, 0));
                faceRight = true;
            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.Up))
            {
                if (isgrounded && !isUpPressed)
                {
                    vertocalSpeed = -JumpForce;
                    isUpPressed = true;
                }
                else
                {
                    isUpPressed = false;
                }
            }
            vertocalSpeed += GravityForce * deltaTime;
            if (vertocalSpeed > 500.0f) vertocalSpeed = 500.0f;
            isgrounded = false;
            Vector2f velocity = new Vector2f(0, vertocalSpeed * deltaTime);
            if (scene.TryMove(this, velocity))
            {
                if (vertocalSpeed > 0.0f)
                {
                    isgrounded = true;
                    vertocalSpeed = 0.0f;
                }
                else {
                    vertocalSpeed = -0.5f * vertocalSpeed;
                }
            }
            if (Position.X < 0 || Position.X > 800 || Position.Y < 0 || Position.Y > 600)
            {
                //scene.nextScene = scene.currentScene;
                scene.Reload();
            } 
            
        }
        public override void render(RenderTarget target)
        {
            sprite.Scale = new Vector2f(faceRight ? -1 : 1, 1);
            base.render(target);
        }
        public override FloatRect Bounds {
            get {
                var bounds = base.Bounds;
                bounds.Left += 3;
                bounds.Width -= 6;
                bounds.Top += 3;
                bounds.Height -= 3;
                return bounds;
            }
        }
    }
}
