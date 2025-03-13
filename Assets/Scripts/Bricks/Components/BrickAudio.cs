using Arkanoid.Audio;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace Arkanoid.Bricks
{
    public class BrickAudio : MonoBehaviour
    {
        [Inject] private AudioClipPlayer audioClipPlayer;
        [SerializeField] private AudioClip[] breakClips;
        private Brick brick;
        
        private void Awake()
        {
            brick = GetComponent<Brick>();
        }

        private void OnEnable()
        {
            brick.OnBreak += PlayBreakSound;
        }

        private void OnDisable()
        {
            brick.OnBreak -= PlayBreakSound;
        }

        private void PlayBreakSound()
        {
            audioClipPlayer.Play(breakClips[Random.Range(0, breakClips.Length)], 1, 0.9f, 1.1f);
        }
    }
}