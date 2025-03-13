using UnityEngine;

namespace Arkanoid.Bricks
{ 
    [System.Serializable]
    public class BrickType
    {
        public GameObject prefab;
        [Range(0, 100)] public float percentage;
    }
}