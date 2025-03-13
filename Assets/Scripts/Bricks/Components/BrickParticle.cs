using UnityEngine;

namespace Arkanoid.Bricks
{
    public class BrickParticle : MonoBehaviour
    {
        [SerializeField] private ParticleSystem destroyParticle;
        private SpriteRenderer spriteRenderer;
        private Brick brick;

        private void Awake()
        {
            brick = GetComponent<Brick>();
            spriteRenderer = GetComponent<SpriteRenderer>();

            brick.OnBreak += SpawnDestroyParticle;
        }

        private void OnEnable()
        {
            brick.OnBreak += SpawnDestroyParticle;
        }

        private void OnDisable()
        {
            brick.OnBreak -= SpawnDestroyParticle;
        }

        private void SpawnDestroyParticle()
        {
            var particleInstance = Instantiate(destroyParticle, transform.position, Quaternion.identity);
            var particleMain = particleInstance.main;
            particleMain.startColor = spriteRenderer.color;
        }
    }
}