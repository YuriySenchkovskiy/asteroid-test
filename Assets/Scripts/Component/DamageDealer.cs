using ObjectPool;
using UnityEngine;

namespace Component
{
    public class DamageDealer : MonoBehaviour
    {
        [SerializeField] private GameObject _hitEffect;
        private ParticleSystem _effect;
        
        public void PlayHitEffect()
        {
            if (_hitEffect == null)
            {
                return;
            }
            
            var instance = Pool.Instance.GetGameObject(_hitEffect, Quaternion.identity, transform.position);

            _effect = instance.GetComponent<ParticleSystem>();
            Invoke(nameof(SetHitEffectToPool), _effect.main.duration + _effect.main.startLifetime.constantMax);
        }

        private void SetHitEffectToPool()
        {
            _effect.GetComponent<PoolItem>().Release();
        }
    }
}