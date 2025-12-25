using UnityEngine;

namespace RPGGame
{
    /// <summary>
    /// 무기 아이템
    /// </summary>
    [CreateAssetMenu(fileName = "New Weapon Item", menuName = "Inventory/Item/WeaponItem")]
    public class WeaponItem : Item
    {
        public float Attack;

        public void Awake()
        {
            ItemName = "무기";
        }
    }
}