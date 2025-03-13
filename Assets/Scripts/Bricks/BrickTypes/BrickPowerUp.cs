using UnityEngine;
using Zenject;

namespace Arkanoid.Bricks
{
    public class BrickPowerUp : Brick
    {
        [SerializeField] private GameObject powerUpPrefab;
        [Inject] DiContainer diContainer;

        public override void Break()
        {
            base.Break();
            var powerup = diContainer.InstantiatePrefab(powerUpPrefab);
            powerup.transform.position = transform.position;
            powerup.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-1, 1), 1).normalized);
            powerup.GetComponent<SpriteRenderer>().color = GetComponent<SpriteRenderer>().color;
        }
    }
}