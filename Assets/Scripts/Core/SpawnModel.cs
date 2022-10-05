using System;
using System.Threading.Tasks;

namespace Core
{
    public class SpawnModel
    {
        private int _multiple;
        private int _lenght;
        private float _timeBetweenSpawn;
        private Random _random;

        public Action<int> NumberSelected;

        public SpawnModel(int lenght, float timeBetweenSpawn)
        {
            _lenght = lenght;
            _timeBetweenSpawn = timeBetweenSpawn;
            _random = new Random();
            _multiple = 1000;
            
            GetSpawnNumber();
        }
        
        private async void GetSpawnNumber()
        {
            while (true)
            {
                NumberSelected?.Invoke(_random.Next(_lenght));
                await Task.Delay((int)_timeBetweenSpawn * _multiple);
            }
        }
    }
}