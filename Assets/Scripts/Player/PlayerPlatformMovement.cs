using UnityEngine;
using Zenject;

namespace Arkanoid.Player
{
    public class PlayerPlatformMovement : MonoBehaviour
    {
        [SerializeField] private float _moveSpeed;
        [Inject] private PlayerInputHandler _inputHandler;
        private Rigidbody2D _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        void FixedUpdate()
        {
            _rigidbody.velocity = new Vector2(_inputHandler.MovementInput.x * _moveSpeed, 0);
        }
    }
}