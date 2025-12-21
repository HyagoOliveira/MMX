using UnityEngine;

namespace MMX.PlayerSystem
{
    [DisallowMultipleComponent]
    public sealed class ArmorController : MonoBehaviour
    {
        [field: SerializeField] public AbstractArmorLoader Loader { get; private set; }
    }
}