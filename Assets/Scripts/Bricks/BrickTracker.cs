using System;
using System.Collections.Generic;
using UnityEngine;

namespace Arkanoid.Bricks
{
    public class BrickTracker : IBrickTracker
    {
        private List<GameObject> bricks = new List<GameObject>();

        public int GetCount() => bricks.Count;
        
        public Action OnNoBricksLeft { get; set; }
        
        public void AddBrick(GameObject brick)
        {
            bricks.Add(brick);
        }

        public void RemoveBrick(GameObject brick)
        {
            bricks.Remove(brick);
            if (bricks.Count <= 0)
            {
                OnNoBricksLeft?.Invoke();
                Debug.Log("Win");
            }
        }
    }
}