using UnityEngine;
using static MMX.InputSystem.InputActions;

namespace MMX.InputSystem
{
    /// <summary>
    /// Manager for Input.
    /// </summary>
    [DisallowMultipleComponent]
    public sealed class InputManager : MonoBehaviour
    {
        public static InputActions Actions { get; private set; }
        public static UIActions UI => Actions.UI;
        public static PlayerActions Player { get; private set; }

        private void Awake() => Initialize();
        private void Update() => Player.Update();
        private void OnDestroy() => Dispose();

        public void Pause()
        {
            UI.Enable();
            Player.Disable();
        }

        public void Resume()
        {
            UI.Disable();
            Player.Enable();
        }

        private void Initialize()
        {
            Actions = new InputActions();
            Player = new PlayerActions(Actions.Player);
        }

        private void Dispose()
        {
            Player = null;
            Actions.Dispose();

            Actions = null;
        }
    }
}