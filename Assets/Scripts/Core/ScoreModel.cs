namespace Core
{
    public class ScoreModel
    {
        public static int NumberOfDefeatedEnemies { get; private set; }

        public static void AddScore()
        {
            NumberOfDefeatedEnemies++;
        }

        public static void ClearResult()
        {
            NumberOfDefeatedEnemies = 0;
        }
    }
}