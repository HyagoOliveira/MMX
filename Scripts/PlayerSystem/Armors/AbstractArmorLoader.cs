using UnityEngine;
using MMX.CoreSystem;

namespace MMX.PlayerSystem
{
    public abstract class AbstractArmorLoader : MonoBehaviour
    {
        public abstract void Load(Armors armor);
    }
}