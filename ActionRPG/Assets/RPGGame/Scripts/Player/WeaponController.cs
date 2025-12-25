using UnityEngine;

namespace RPGGame
{
    /// <summary>
    /// 무기 관련 기능을 담당하는 스크립트
    /// </summary>
    public class WeaponController : MonoBehaviour
    {
        [SerializeField, Tooltip("무기가 장작돼야 하는 위치(모델링의 특정 뼈대 위치를 저장)")] private Transform _weaponHolder;
        [SerializeField, Tooltip("장작된 무기 컴포넌트")] private Weapon _weapon;

        public bool IsWeaponAttached { get; private set; }  // 무기가 장작됐는지 확인하는 변수


        /// <summary>
        /// 플레이어가 무기를 획득할 때 무기를 장착하는 함수
        /// </summary>
        /// <param name="weapon"></param>
        public void AttachWeapon(Weapon weapon)
        {
            // 무기가 이미 장착됐으면 함수 종료
            if (IsWeaponAttached)
            {
                return;
            }

            weapon.Attach(_weaponHolder);  // 무기 장착
            this._weapon = weapon;  // 장착된 무기의 참조 설정
            IsWeaponAttached = true;    // 무기 장착 설정

            // 무기에서 전달받아야 하는 공격 관련 이벤트 등록
            PlayerAttackState playerAttackState = transform.root.GetComponentInChildren<PlayerAttackState>();

            if (playerAttackState != null)
            {
                // 공격 판정 시작 이벤트에 함수 등록
                playerAttackState.SubscribeOnAttackBegin(_weapon.OnAttackBegin);

                // 공격 판정 종료 이벤트에 함수 등록
                playerAttackState.SubscribeOnAttackEnd(_weapon.OnAttackEnd);
            }
        }
    }
}