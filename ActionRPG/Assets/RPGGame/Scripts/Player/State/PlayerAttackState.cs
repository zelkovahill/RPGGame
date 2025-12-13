using UnityEngine;
using UnityEngine.Events;


namespace RPGGame
{
    public class PlayerAttackState : PlayerStateBase
    {
        [SerializeField] private UnityEvent OnAttackBegin;
        [SerializeField] private UnityEvent OnAttackCheckEnd;
        [SerializeField] private UnityEvent OnAttackEnd;

        private void AttackStart()
        {
            OnAttackBegin?.Invoke();
        }

        public void SubscribeOnAttackBegin(UnityAction listener)
        {
            OnAttackBegin?.AddListener(listener);
        }

        private void AttackCheckEnd()
        {
            OnAttackCheckEnd?.Invoke();
        }

        public void SubscribeOnAttackCheckEnd(UnityAction listener)
        {
            OnAttackCheckEnd?.AddListener(listener);
        }

        private void ComboCheck()
        {
            _animationController.SetAttackComboState((int)_manager.NextAttackCombo);
        }

        private void AttackEnd()
        {
            OnAttackEnd?.Invoke();

            _manager.SetState(PlayerStateManager.EState.Idle);
        }

        public void SubscribeOnAttackEnd(UnityAction listener)
        {
            OnAttackEnd?.AddListener(listener);
        }
    }
}