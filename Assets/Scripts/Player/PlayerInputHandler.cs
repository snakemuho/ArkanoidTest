using UnityEngine;
using UnityEngine.InputSystem;

namespace Arkanoid.Player
{
    public class PlayerInputHandler : MonoBehaviour
    {
        public Vector2 MovementInput { get; private set; }
    
        public void OnMoveInput(InputAction.CallbackContext context)
        {
            MovementInput = context.ReadValue<Vector2>();
        }
    
        public void MoveLeft() => MovementInput = Vector2.left;
        public void MoveRight() => MovementInput = Vector2.right;
        public void StopMoving() => MovementInput = Vector2.zero;
    }
}