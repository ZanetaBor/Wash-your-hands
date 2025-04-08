namespace MyApp.Data
{
    public abstract class GameObject
    {
        public int PositionX { get; set; }
        public int PositionY { get; set; }
        public int Speed { get; set; }

        public abstract void Move();

    }
}
