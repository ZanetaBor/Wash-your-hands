namespace MyApp.Data
{
    public class Bacteria : GameObject
    {
        public int Health { get; set; }
        int CountOfBacteria { get; set; }
        public Bacteria() 
        {
            Random rnd = new Random();
            PositionX = rnd.Next(0, 800);
            PositionY = 0;
            Health = 100;
            Speed = 1;
            CountOfBacteria = 1;  
        }

        public override void Move()
        {
            PositionY += Speed;
        }
    }
}
