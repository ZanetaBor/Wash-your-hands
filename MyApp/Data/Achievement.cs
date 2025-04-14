namespace MyApp.Data
{
    public class Achievement
    {
        public string Name { get; set; }
        public string Color { get; set; }
        public int Points { get; set; }
        public string Sound { get; set; } 
        public AchievementType Type { get; set; }

        public void Trigger()
        {
            PlaySound();           
        }

        private void PlaySound()
        {
            Console.WriteLine($"🔊 Playing sound: {Sound}");
            // albo JSInterop w Blazorze do uruchomienia audio w przeglądarce
        }
    }
}
