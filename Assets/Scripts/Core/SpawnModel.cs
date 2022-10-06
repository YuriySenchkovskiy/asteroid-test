using System.Threading.Tasks;
using Random = System.Random;

namespace Core
{
    public class SpawnModel
    {
        private int _multiple;
        private int _lenght;
        private float _timeBetweenSpawn;
        private Random _random;
        private bool _isGameOn;

        public delegate void Number(int number);
        public event Number NumberSelected;

        public SpawnModel(int lenght, float timeBetweenSpawn)
        {
            _lenght = lenght;
            _timeBetweenSpawn = timeBetweenSpawn;
            _random = new Random();
            _multiple = 1000;

            _isGameOn = true;
        }

        public void ChangeGameStatus()
        {
            _isGameOn = false;
        }
        
        public async void StartSpawn()
        {
            while (_isGameOn)
            {
                
                NumberSelected?.Invoke(_random.Next(_lenght));
                await Task.Delay((int)_timeBetweenSpawn * _multiple);
            }
        }
    }
}