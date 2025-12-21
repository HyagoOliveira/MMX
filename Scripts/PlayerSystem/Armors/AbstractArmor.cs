using UnityEngine;
using MMX.WeaponSystem;

namespace MMX.PlayerSystem
{
    [DisallowMultipleComponent]
    public abstract class AbstractArmor : MonoBehaviour
    {
        [field: SerializeField] public AbstractWeapon MainWeapon { get; private set; }
        [field: SerializeField] public AbstractWeapon SideWeapon { get; private set; }
        [field: SerializeField] public AbstractWeapon GigaWeapon { get; private set; }

        internal virtual void Dispose() { }
    }
}
