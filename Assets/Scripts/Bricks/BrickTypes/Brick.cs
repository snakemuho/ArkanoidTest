using System;
using UnityEngine;

namespace Arkanoid.Bricks
{
    public abstract class Brick : MonoBehaviour
    {
        private IBrickTracker brickTracker;

        public Action OnBreak;
        
        public void Initialize(IBrickTracker tracker)
        {
            brickTracker = tracker;
        }
        public virtual void Break()
        {
            OnBreak?.Invoke();
            brickTracker.RemoveBrick(gameObject);
            Destroy(gameObject);
        }
    }
}
