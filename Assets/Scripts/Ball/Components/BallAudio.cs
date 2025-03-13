using Arkanoid.Audio;
using UnityEngine;
using Zenject;

namespace Arkanoid.Ball
{
    public class BallAudio : MonoBehaviour
    {
        [Inject] private AudioClipPlayer audioClipPlayer;
        [SerializeField] private AudioClip[] bounceClips;
        private BallMovement ballMovement;

        private void Awake()
        {
            ballMovement = GetComponent<BallMovement>();
        }

        private void OnEnable()
        {
            ballMovement.OnBounce += PlayBounceSound;
        }

        private void OnDisable()
        {
            ballMovement.OnBounce -= PlayBounceSound;
        }

        private void PlayBounceSound(Vector3 vector)
        {
            audioClipPlayer.Play(bounceClips[Random.Range(0, bounceClips.Length)], 0.5f);
        }
    }
}