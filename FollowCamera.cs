using Microsoft.Xna.Framework;


namespace ShootEmUp
{
    public class FollowCamera
    {
        public Vector2 Position;

        public FollowCamera(Vector2 position)
        {
            this.Position = position;
        }

        public void Follow(Rectangle target, Vector2 screenSize)
        {
            Position = new Vector2 (
                -target.X + (screenSize.X / 2 - target.Width / 2), 
                -target.Y + (screenSize.Y / 2 - target.Height / 2)
            );
        }
    }
}
