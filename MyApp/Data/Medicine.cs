namespace MyApp.Data
{
    public class Medicine : GameObject
    {

        public Medicine()
        {
            Random rnd = new Random();
            PositionX = rnd.Next(0, 800);
            PositionY = 600;
            Speed = 3;
        }
        public override void Move()
        {
            PositionY -= Speed;
        }
    }
}
