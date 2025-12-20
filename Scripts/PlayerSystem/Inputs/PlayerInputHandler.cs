using UnityEngine;
//using Input = MMXD.InputSystem.Input;

namespace MMX.PlayerSystem
{
    [DefaultExecutionOrder(-1)]
    [DisallowMultipleComponent]
    public sealed class PlayerInputHandler : MonoBehaviour
    {
        [SerializeField] private Player player;

        private void OnEnable()
        {
            /*Input.Player.OnMoved += player.SetMoveInput;
            Input.Player.OnJumped += player.SetJumpInput;
            Input.Player.OnDashed += player.SetDashInput;
            Input.Player.OnMainAttacked += player.SetMainAttackInput;
            Input.Player.OnSideAttacked += player.SetSideAttackInput;
            Input.Player.OnGigaAttacked += player.SetGigaAttackInput;
            //Input.Player.OnSwitched += PlayerManager.Switch;*/
        }

        private void OnDisable()
        {
            /*Input.Player.OnMoved -= player.SetMoveInput;
            Input.Player.OnJumped -= player.SetJumpInput;
            Input.Player.OnDashed -= player.SetDashInput;
            Input.Player.OnMainAttacked -= player.SetMainAttackInput;
            Input.Player.OnSideAttacked -= player.SetSideAttackInput;
            Input.Player.OnGigaAttacked -= player.SetGigaAttackInput;
            //Input.Player.OnSwitched -= PlayerManager.Switch;*/
        }
    }
}