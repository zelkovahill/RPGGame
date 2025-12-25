using UnityEngine;

namespace RPGGame
{
    /// <summary>
    /// 플레이어가 수집할 수 있는 아이템의 데이터를 제공하는 클래스
    /// </summary>
    public abstract class Item : ScriptableObject
    {
        [Tooltip("인번토리에 보여줄 아이템의 이름")] public string ItemName;
        [Tooltip("인벤토릴 UI에 보여줄 2D 스프라이트")] public Sprite Sprite;
        [TextArea(2, 15), Tooltip("아이템을 수집했을 때 다이얼로그 화면에 보여줄 메세지")] public string MessageWhenCollected;
        [TextArea(2, 15), Tooltip("아이템을 사용했을 때 다이얼로그 화면에 보여줄 메세지")] public string MessageWhenUsed;

        /// <summary>
        /// 아이템을 사용할 때 필요한 기능을 제공하는 함수
        /// </summary>
        public virtual void Use() { }
    }

}