using RPGGame;
using UnityEngine;

namespace RPGGame
{
    public class PlayerAnimationController : MonoBehaviour
    {
        [SerializeField] private Animator _refAnimator;

        private void OnEnable()
        {
            if (_refAnimator == null)
            {
                _refAnimator = GetComponentInParent<Animator>();
            }
        }

        public void OnStateChanged(PlayerStateManager.EState newState)
        {
            if (_refAnimator == null)
            {
                return;
            }

            _refAnimator.SetInteger("State", (int)newState);
        }
    }
}