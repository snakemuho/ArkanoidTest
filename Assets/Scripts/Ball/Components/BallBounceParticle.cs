using UnityEngine;

namespace Arkanoid.Ball
{
    public class BallBounceParticle : MonoBehaviour
    {
        [SerializeField] private BallMovement ballMovement;
        private ParticleSystem particle;
        private SpriteRenderer spriteRenderer;

        private void Awake()
        {
            particle = GetComponent<ParticleSystem>();
            spriteRenderer = ballMovement.GetComponent<SpriteRenderer>();
        }

        private void OnEnable()
        {
            ballMovement.OnBounce += PlayParticleInDirection;
        }
        private void OnDisable()
        {
            ballMovement.OnBounce -= PlayParticleInDirection;
        }

        private void PlayParticleInDirection(Vector3 direction)
        {
            var main = particle.main;
            main.startColor = spriteRenderer.color;

            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        
            particle.transform.rotation = Quaternion.Euler(-angle, 90, 0);
        
            particle.Play();
        }
    }
}