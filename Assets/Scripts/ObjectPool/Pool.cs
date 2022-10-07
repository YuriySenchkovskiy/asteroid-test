using System.Collections.Generic;
using UnityEngine;
using Utils;

namespace ObjectPool
{
    public class Pool : MonoBehaviour
    {
        private const string FolderName = "---MAIN POOL---";
        private readonly Dictionary<int, Queue<PoolItem>> _items = new Dictionary<int, Queue<PoolItem>>();
        private static Pool _instance;

        public static Pool Instance
        {
            get
            {
                if (_instance == null)
                {
                    var go = new GameObject(FolderName);
                    _instance = go.AddComponent<Pool>();
                }

                return _instance;
            }
        }

        public GameObject GetGameObject(GameObject go, Quaternion rotation, Vector3 position)
        {
            var id = go.GetInstanceID(); 
            var queue = RequireQueue(id);

            if (queue.Count > 0)
            {
                var pooledItem = queue.Dequeue();
                var itemTransform = pooledItem.transform;
                itemTransform.position = position;
                itemTransform.rotation = rotation;
                
                pooledItem.gameObject.SetActive(true);
                pooledItem.Restart();
                return pooledItem.gameObject;
            }
            
            var instance = SpawnUtils.Spawn(go, position, rotation,_instance.gameObject);
            var poolItem = instance.GetComponent<PoolItem>();
            poolItem.Retain(id, this);

            return instance;
        }
        
        public void Release(int id, PoolItem poolItem)
        {
            var queue = RequireQueue(id);
            queue.Enqueue(poolItem);
            
            poolItem.gameObject.SetActive(false);
        }
        
        private Queue<PoolItem> RequireQueue(int id)
        {
            if (!_items.TryGetValue(id, out var queue))
            {
                queue = new Queue<PoolItem>();
                _items.Add(id, queue);
            }

            return queue;
        }
    }
}