using System;
using UnityEngine;

namespace Arkanoid.Ball
{
    public interface IBallTracker
    {
        public int GetCount();
        public Action OnNoBallsLeft { get; set; }

        public void AddBall(GameObject ball);
        public void RemoveBall(GameObject ball);
    }
}