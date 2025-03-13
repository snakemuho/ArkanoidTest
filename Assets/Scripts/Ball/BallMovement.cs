using System;
using Arkanoid.Bricks;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace Arkanoid.Ball
{
    public class BallMovement : MonoBehaviour
    {
        [SerializeField] private float speed = 5f;
        [SerializeField] private float maxBounceAngle = 60f;
        [Inject] private IBallTracker ballTracker;
        private SpriteRenderer spriteRenderer;
        private Vector2 direction;
        private Vector2 lastPosition;

        public Action<Vector3> OnBounce;

        public void Launch()
        {
            direction = new Vector2(Random.Range(-0.5f, 0.5f), 1).normalized;
            lastPosition = transform.position;
        }
        
        private void Awake()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            ballTracker.AddBall(gameObject);
        }

        private void Update()
        {
            lastPosition = transform.position;
            transform.position += (Vector3)direction * speed * Time.deltaTime;
        }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("GameOverTrigger"))
            {
                ballTracker.RemoveBall(gameObject);
                gameObject.SetActive(false);
                return;
            }
            Vector2 prevPos = lastPosition;
            Bounds bounds = other.bounds;

            bool cameFromLeft = prevPos.x < bounds.min.x;
            bool cameFromRight = prevPos.x > bounds.max.x;
            bool cameFromBottom = prevPos.y < bounds.min.y;
            bool cameFromTop = prevPos.y > bounds.max.y;

            bool bouncedX = false;
            bool bouncedY = false;

            if (cameFromLeft && direction.x > 0 || cameFromRight && direction.x < 0)
            {
                direction.x *= -1;
                bouncedX = true;
            }

            if (cameFromBottom && direction.y > 0 || cameFromTop && direction.y < 0)
            {
                direction.y *= -1;
                bouncedY = true;
            }

            if (other.CompareTag("Platform"))
            {
                BounceOffPlatform(other);
            }

            if (other.CompareTag("Brick") && (bouncedX || bouncedY))
            {
                spriteRenderer.color = other.GetComponent<SpriteRenderer>().color;
                other.GetComponent<Brick>().Break();
            }
        
            OnBounce?.Invoke(direction);
        }

        private void BounceOffPlatform(Collider2D platform)
        {
            float platformWidth = platform.bounds.size.x;
            float hitFactor = (transform.position.x - platform.transform.position.x) / (platformWidth / 2);
            hitFactor = Mathf.Clamp(hitFactor, -1f, 1f);

            float bounceAngle = hitFactor * maxBounceAngle * Mathf.Deg2Rad;
            direction = new Vector2(Mathf.Sin(bounceAngle), Mathf.Cos(bounceAngle)).normalized;
        }
    }
}
