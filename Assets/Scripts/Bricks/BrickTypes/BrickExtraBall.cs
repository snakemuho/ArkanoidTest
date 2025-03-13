using Arkanoid.Ball;
using UnityEngine;
using Zenject;

namespace Arkanoid.Bricks
{
    public class BrickExtraBall : Brick
    {
        [SerializeField] private GameObject ball;
        [Inject] DiContainer diContainer;
        public override void Break()
        {
            base.Break();
            GameObject newBall = diContainer.InstantiatePrefab(ball);
            newBall.transform.position = transform.position;
            newBall.GetComponent<BallMovement>().Launch();
        }
    }
}