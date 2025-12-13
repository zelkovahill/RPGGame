using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

namespace RPGGame
{
    public class PlayerStateManager : MonoBehaviour
    {
        public enum EState
        {
            None = -1,
            Idle,
            Move,
            Length,
        }

        [SerializeField] private EState _state = EState.None;
        [SerializeField] private PlayerStateBase[] _states;
        [SerializeField] private UnityEvent<EState> _OnStateChanged;

        private void OnEnable()
        {
            SetState(EState.Idle);
        }

        private void Update()
        {
            if (InputManager.Movement == Vector2.zero)
            {
                SetState(EState.Idle);
            }
            else
            {
                SetState(EState.Move);
            }
        }

        public void SetState(EState newState)
        {
            if (_state == newState)
            {
                return;
            }

            if (_state != EState.None)
            {
                _states[(int)_state].enabled = false;
            }

            _states[(int)newState].enabled = true;
            _state = newState;
            _OnStateChanged?.Invoke(_state);
        }
    }
}