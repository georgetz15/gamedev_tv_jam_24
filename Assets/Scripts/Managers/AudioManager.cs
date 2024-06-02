using UnityEngine;

namespace Managers
{
    public class AudioManager : MonoBehaviour
    {
        [SerializeField] private AudioSource audioSource;
        [SerializeField] private AudioClip backgroundMusic;
        [SerializeField] private AudioClip playerFire;
        [SerializeField] private AudioClip enemyFire;
        [SerializeField] private AudioClip playerDestroyed;
        [SerializeField] private AudioClip enemyDestroyed;
        [SerializeField] private AudioClip powerupReceived;
        [SerializeField] private AudioClip powerupDropped;

        public static AudioManager instance { get; private set; }

        private void Awake()
        {
            // If there is an instance, and it's not me, delete myself.
            if (instance && instance != this)
            {
                Destroy(this);
            }
            else
            {
                instance = this;
            }
        }

        public void PlayPlayerFire()
        {
            audioSource.PlayOneShot(playerFire);
        }

        public void PlayEnemyFire()
        {
            audioSource.PlayOneShot(enemyFire);
        }

        public void PlayEnemyDestroyed()
        {
            audioSource.PlayOneShot(enemyDestroyed);
        }

        public void PlayPlayerDestroyed()
        {
            audioSource.PlayOneShot(playerDestroyed);
        }

        public void PlayPowerupReceived()
        {
            audioSource.PlayOneShot(powerupReceived);
        }

        public void PlayPowerupDropped()
        {
            audioSource.PlayOneShot(powerupDropped);
        }

        public void StartBackingTrack()
        {
            audioSource.Play();
        }
    }
}