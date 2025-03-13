using UnityEngine;

namespace Arkanoid.Powerups
{
    public class PowerupWidth : Powerup
    {
        [SerializeField] private float addedWidth;
        private void OnTriggerEnter2D(Collider2D other)
        {

            if (other.CompareTag("GameOverTrigger"))
            {
                gameObject.SetActive(false);
                return;
            }
            
            if (other.CompareTag("Platform"))
            {
                OnPickedUp?.Invoke();
                other.transform.localScale = new Vector2(other.transform.localScale.x + addedWidth, other.transform.localScale.y);
                gameObject.SetActive(false);
            }
        }
    }
}