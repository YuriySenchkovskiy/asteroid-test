namespace Core
{
    public class Score
    {
        public static int NumberOfDefeatedEnemies { get; private set; }

        public static void AddScore()
        {
            NumberOfDefeatedEnemies++;
        }
    }
}