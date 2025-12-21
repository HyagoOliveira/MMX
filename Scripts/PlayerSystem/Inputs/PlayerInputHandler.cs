using UnityEngine;
using MMX.InputSystem;

namespace MMX.PlayerSystem
{
    [DefaultExecutionOrder(-1)]
    [DisallowMultipleComponent]
    public sealed class PlayerInputHandler : MonoBehaviour
    {
        [SerializeField] private Player player;

        private void Awake() => SubscriveEvents();
        private void OnEnable() => InputManager.Player.Enable();
        private void Update() => InputManager.Player.Update();
        private void OnDisable() => InputManager.Player.Disable();
        private void OnDestroy() => UnsubscriveEvents();

        private void SubscriveEvents()
        {
            InputManager.Player.OnMoved += player.SetMoveInput;
            InputManager.Player.OnJumped += player.SetJumpInput;
            InputManager.Player.OnDashed += player.SetDashInput;
            InputManager.Player.OnMainAttacked += player.SetMainAttackInput;
            InputManager.Player.OnSideAttacked += player.SetSideAttackInput;
            InputManager.Player.OnGigaAttacked += player.SetGigaAttackInput;
            InputManager.Player.OnSwitched += player.SwitchInput;
        }

        private void UnsubscriveEvents()
        {
            InputManager.Player.OnMoved -= player.SetMoveInput;
            InputManager.Player.OnJumped -= player.SetJumpInput;
            InputManager.Player.OnDashed -= player.SetDashInput;
            InputManager.Player.OnMainAttacked -= player.SetMainAttackInput;
            InputManager.Player.OnSideAttacked -= player.SetSideAttackInput;
            InputManager.Player.OnGigaAttacked -= player.SetGigaAttackInput;
            InputManager.Player.OnSwitched -= player.SwitchInput;
        }
    }
}