using System;
using UnityEngine;

namespace Arkanoid.Powerups
{
    public abstract class Powerup : MonoBehaviour
    {
        public Action OnPickedUp;
    }
}