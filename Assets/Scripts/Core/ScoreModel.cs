namespace Core
{
    public class ScoreModel
    {
        public static int NumberOfDefeatedEnemies { get; private set; }

        public static void AddScore()
        {
            NumberOfDefeatedEnemies++;
        }
    }
}