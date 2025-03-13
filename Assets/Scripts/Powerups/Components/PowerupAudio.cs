using Arkanoid.Audio;
using UnityEngine;
using Zenject;

namespace Arkanoid.Powerups
{
    public class PowerupAudio : MonoBehaviour
    {
        [Inject] private AudioClipPlayer audioClipPlayer;
        [SerializeField] private AudioClip[] pickupClips;
        private Powerup powerup;

        private void Awake()
        {
            powerup = GetComponent<Powerup>();
        }

        private void OnEnable()
        {
            powerup.OnPickedUp += PlayPickupSound;
        }

        private void OnDisable()
        {
            powerup.OnPickedUp -= PlayPickupSound;
        }

        private void PlayPickupSound()
        {
            audioClipPlayer.Play(pickupClips[Random.Range(0, pickupClips.Length)], 0.5f);
        }
    }
}