using UnityEngine;

namespace Component
{
    public class AudioPlayer : MonoBehaviour
    {
        [Header("Shooting")]
        [SerializeField] private AudioClip _shootingClip;
        [SerializeField] [Range(0f, 1f)] private float _shootingVolume = 0.8f;
        
        [Header("Damage")] 
        [SerializeField] private AudioClip _damageClip;
        [SerializeField] [Range(0f, 1f)] private float _damageVolume = 0.8f;
        
        [Header("Click")] 
        [SerializeField] private AudioClip _clickClip;
        [SerializeField] [Range(0f, 1f)] private float _clickVolume = 1f;
        
        private static AudioPlayer _instance;
        
        private void Awake()
        {
            if (_instance == null)
            {
                _instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else if (_instance != this)
            {
                Destroy(gameObject);
            }
        }
        
        public void PlayShootingClip()
        {
            PlayClip(_shootingClip, _shootingVolume);
        }
        
        public void PlayDamageClip()
        {
            PlayClip(_damageClip, _damageVolume);
        }
        
        public void PlayClickClip()
        {
            PlayClip(_clickClip, _clickVolume);
        }
        
        private void PlayClip(AudioClip clip, float volume)
        {
            if (clip != null)
            {
                var cameraPosition = Camera.main.transform.position;
                AudioSource.PlayClipAtPoint(clip, cameraPosition, volume);
            }
        }
    }
}