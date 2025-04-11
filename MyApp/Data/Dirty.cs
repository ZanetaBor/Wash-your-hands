namespace MyApp.Data
{
    public class Dirty: Obstacle
    {
        public Dirty()
        {
            Random rnd = new Random();
            PositionX = rnd.Next(0, 800);
            PositionY = rnd.Next(0, 600);
            IsExist = true;
            TimeExist = 30f;
        }

        public override void Move()
        {
            _ = RunAsync();
        }

        private async Task RunAsync()
        {
            while (TimeExist > 0)
            {
                await Task.Delay(100);
                TimeExist -= 0.1f;
            }

            IsExist = false;
        }
    }
}
