using UnityEngine;

namespace RPGGame
{
    /// <summary>
    /// 캐릭터의 무기 스크립트
    /// </summary>
    public class Weapon : CollectableItem
    {
        [SerializeField, Tooltip("공격력 데이터")] private float _attackAmount = 0f;
        [SerializeField, Tooltip("공격 판정에 사용할 충돌 영역의 반지름")] private float _radius = 0.1f;
        [SerializeField, Tooltip("무기와 몬스터가 충돌할 때 재생할 Hit 파티클")] private ParticleSystem _hitParticle;
        [SerializeField, Tooltip("공격을 판정할 때 사용할 위치")] private Transform[] _attackPoints;
        [SerializeField, Tooltip("공격 판정 대상 레이어")] private LayerMask _attackTargetLayer;

        private bool _isInAttack = false;   // 공격 판정을 진행하고 있는지 여부를 나타내는 변수

        protected override void Awake()
        {
            base.Awake();

            // 무기 아이템 정보로부터 공격력 값을 얻어와 _attackAmount 변수에 저장
            // 몬스터에 대미지를 전달할 때마다 공겨력 값을 함께 전달해야 하는데
            // 그떄마다 매번 item을 형변환해서 Attack 값을 읽어오는 것이 불필요하기 때문에 미리 저장해두고 사용
            WeaponItem weaponItem = Item as WeaponItem;
            if (weaponItem != null)
            {
                _attackAmount = weaponItem.Attack;
            }
        }

        protected override void OnCollect(Collider other)
        {
            // base.OnCollect(other);

            // 이 아이템을 수집하지 않았고, 부딪힌 충돌체의 태그가 Player라면 무집 수집 처리
            if (!HasCollected && other.CompareTag("Player"))
            {
                // 무기 수집 처리를 위해 WeaponController 컴포넌트 검색
                WeaponController weaponController = other.GetComponentInChildren<WeaponController>();

                // WeaponController에서 무기 수집 진행
                if (weaponController != null)
                {
                    weaponController.AttachWeapon(this);
                }

                _onItemCollected?.Invoke();     // 아이템이 수집됐다는 이벤트 발행
            }
        }

        /// <summary>
        /// 무기를 수집할 때 실행하는 함수
        /// </summary>
        /// <param name="parentTransform"></param>
        public void Attach(Transform parentTransform)
        {
            // 트랜스폼 설정 후 위치/회전 조정
            _refTransform.SetParent(parentTransform);
            _refTransform.localPosition = Vector3.zero;
            _refTransform.localRotation = Quaternion.identity;

            HasCollected = true;
        }

        public void OnAttackBegin()
        {
            _isInAttack = true;
        }

        public void OnAttackEnd()
        {
            _isInAttack = false;
        }

    }
}