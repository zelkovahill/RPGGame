using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace RPGGame
{
    public class PlayerContoller : MonoBehaviour
    {
        [Header("--- [ Stat ]")]
        [SerializeField, Tooltip("이동 속도")] private float _moveSpeed = 8f;
        [SerializeField, Tooltip("회전 속도")] private float _rotationSpeed = 720f;

        [SerializeField] private Animator _refAnimator;

        private Transform _refTransform;
        private InputAction _moveAction;

        private void Awake()
        {
            if (_refTransform == null)
            {
                _refTransform = transform;
            }

            if (_moveAction == null)
            {
                _moveAction = InputSystem.actions.FindAction("Move");
            }

            if (_refAnimator == null)
            {
                _refAnimator = GetComponentInChildren<Animator>();
            }
        }


        private void Update()
        {
            Vector2 moveValue = _moveAction.ReadValue<Vector2>();
            Vector3 direction = new Vector3(moveValue.x, 0f, moveValue.y);
            direction.Normalize();

            _refTransform.position = _refTransform.position + direction * _moveSpeed * Time.deltaTime;

            // 회전
            if (direction != Vector3.zero)
            {
                Quaternion targetRotation = Quaternion.LookRotation(direction);
                _refTransform.rotation = Quaternion.RotateTowards(_refTransform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);
            }


            // 애니메이션
            if (moveValue == Vector2.zero)
            {
                _refAnimator.SetInteger("State", 0);
            }
            else
            {
                _refAnimator.SetInteger("State", 1);
            }
        }

        private void PlayStep()
        {

        }
    }
}