using UnityEngine;
using MMX.CoreSystem;
using MMX.WeaponSystem;

namespace MMX.PlayerSystem
{
    [DisallowMultipleComponent]
    public abstract class AbstractArmor : MonoBehaviour
    {
        [field: SerializeField] public ArmorName Name { get; private set; }

        [field: Space]
        [field: SerializeField] public AbstractWeapon MainWeapon { get; private set; }
        [field: SerializeField] public AbstractWeapon SideWeapon { get; private set; }
        [field: SerializeField] public AbstractWeapon GigaWeapon { get; private set; }
    }
}
