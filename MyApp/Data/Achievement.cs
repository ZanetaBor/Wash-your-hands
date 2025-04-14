namespace MyApp.Data
{
    public abstract class Achievement
    {
        public string SoundAchievement { get; protected set; }
        public string ColorAchievement { get; protected set; }
        public int ValueAchievement { get; protected set; }

        protected abstract void PlaySound();

        public void Trigger()
        {
            PlaySound();
            // In the futore: add color, music  changeand so on.
            Console.WriteLine($"Achievement triggered! +{ValueAchievement} points.");
        }
    }
}