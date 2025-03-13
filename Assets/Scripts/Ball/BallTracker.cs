using System;
using System.Collections.Generic;
using UnityEngine;

namespace Arkanoid.Ball
{
    public class BallTracker : IBallTracker
    {
        private List<GameObject> balls = new List<GameObject>();

        public Action OnNoBallsLeft { get; set; }

        public int GetCount() => balls.Count;
        
        public void AddBall(GameObject ball)
        {
            balls.Add(ball);
        }

        public void RemoveBall(GameObject ball)
        {
            balls.Remove(ball);
            if (balls.Count <= 0)
            {
                OnNoBallsLeft?.Invoke();
                Debug.Log("Lost");
            }
        }
    }
}