using UnityEngine;

namespace Arkanoid.Audio
{
    public class AudioClipPlayer : MonoBehaviour
    {
        private AudioSource _audioSource;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        public void Play(AudioClip clip, float volume = 1, float pitchMin = 1, float pitchMax = 1)
        {
            _audioSource.pitch = Random.Range(pitchMin, pitchMax);
            _audioSource.PlayOneShot(clip, volume);
        }
    }
}