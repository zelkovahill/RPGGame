using UnityEngine;
using UnityEngine.Events;


namespace RPGGame
{
    /// <summary>
    /// 플레이어가 수집할 수 있는 아이템 클래스F
    /// </summary>
    [RequireComponent(typeof(Collider))]
    public class CollectableItem : MonoBehaviour
    {
        [SerializeField, Tooltip("아이템 정보")] protected Item _item;
        [SerializeField, Tooltip("아이템 수집 후 게임 오브젝트를 삭제할 지 여부를 결정하는 옵션")] private bool _shouldDeleteAfterCollected = true;
        [SerializeField, Tooltip("아이템 획득 이벤트")] protected UnityEvent _onItemCollected;

        protected Transform _refTransform;  // 트랜스폼 컴포넌트 참조 변수
        [Tooltip("아이템이 수집됐는지를 알려주는 프로퍼티")] public bool HasCollected { get; protected set; } = false;
        [Tooltip("아이템 정보를 반환하는 공개 프로퍼티")] public Item Item { get { return _item; } }

        protected virtual void Awake()
        {
            if (_refTransform == null)
            {
                _refTransform = transform;
            }
        }


        private void OnTriggerEnter(Collider other)
        {
            OnCollect(other);
        }


        protected virtual void OnCollect(Collider other)
        {
            if (_item == null)
            {
                Debug.Log("Item 변수가 설정되지 않았습니다.");
                return;
            }

            if (HasCollected || !other.CompareTag("Player"))
            {
                return;
            }

            _onItemCollected?.Invoke();
        }
    }
}
