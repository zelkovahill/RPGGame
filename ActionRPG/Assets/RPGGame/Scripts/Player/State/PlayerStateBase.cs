using UnityEngine;


namespace RPGGame
{
    public class PlayerStateBase : MonoBehaviour
    {
        protected Transform _refTransform;
        protected CharacterController _characterController;
        protected Animator _refAnimator;

        protected virtual void OnEnable()
        {
            if (_refTransform == null)
            {
                _refTransform = transform;
            }

            if (_characterController == null)
            {
                _characterController = GetComponent<CharacterController>();
            }

            if (_refAnimator == null)
            {
                _refAnimator = GetComponent<Animator>();
            }
        }


        protected virtual void Update()
        {
            // 중력
            _characterController.Move(Physics.gravity * Time.deltaTime);
        }

        protected virtual void OnDiable()
        {

        }

        protected virtual void OnAnimatorMove()
        {
            _characterController.Move(_refAnimator.deltaPosition);
        }
    }
}