namespace MyApp.Data
{
    public class Soap : Obstacle
    {
        public Soap() 
        {
            Random rnd = new Random();
            PositionX = rnd.Next(0, 800);
            PositionY = rnd.Next(0, 800);
        }
        public override void Move()
        {
            IsExist = true;
            TimeExist = 20f;
        }
    }
}
