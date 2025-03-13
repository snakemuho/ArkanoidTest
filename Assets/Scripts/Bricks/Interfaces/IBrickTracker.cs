using System;
using UnityEngine;

namespace Arkanoid.Bricks
{
    public interface IBrickTracker
    {
        public int GetCount();
        public Action OnNoBricksLeft { get; set; }
        public void AddBrick(GameObject brick);
        public void RemoveBrick(GameObject brick);
    }
}