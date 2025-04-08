namespace MyApp.Data
{
    public class Dirty: Obstacle
    {
        public Dirty() 
        {       
            Random rnd = new Random();
            PositionX = rnd.Next(0, 800);
            PositionY = rnd.Next(0, 800);
        }
        public override void Move()
        {
            IsExist = true;
            TimeExist = 30f;
        }
    }
}
