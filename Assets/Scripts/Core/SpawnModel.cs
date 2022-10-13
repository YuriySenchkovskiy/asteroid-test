using Random = System.Random;

namespace Core
{
    public class SpawnModel
    {
        private int _lenght;
        private Random _random;

        public delegate void Number(int number);
        public event Number NumberSelected;

        public SpawnModel(int lenght)
        {
            _lenght = lenght;
            _random = new Random();
        }

        public void StartSpawn()
        {
            NumberSelected?.Invoke(_random.Next(_lenght));
        }
    }
}