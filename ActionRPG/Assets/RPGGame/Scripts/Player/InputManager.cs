using UnityEngine;
using UnityEngine.InputSystem;


namespace RPGGame
{
    [DefaultExecutionOrder(-1)]
    public class InputManager : MonoBehaviour
    {
        public static Vector2 Movement { get; private set; } = Vector2.zero;
        private InputAction _moveAction;

        private void Awake()
        {
            if (_moveAction == null)
            {
                _moveAction = InputSystem.actions.FindAction("Move");
            }
        }

        private void Update()
        {
            Movement = _moveAction.ReadValue<Vector2>();
        }
    }
}