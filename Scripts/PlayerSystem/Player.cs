using UnityEngine;
using MMX.CharacterSystem;
using ActionCode.Physics;
using ActionCode.Sidescroller;
using ActionCode.AnimatorStates;
using ActionCode.ColliderAdapter;

namespace MMX.PlayerSystem
{
    /// <summary>
    /// Player main component.
    /// All player-related components should be accessed through this component.
    /// </summary>
    [DisallowMultipleComponent]
    [RequireComponent(typeof(Motor))]
    [RequireComponent(typeof(BoxBody))]
    [RequireComponent(typeof(AnimationEvents))]
    [RequireComponent(typeof(AnimatorStateMachine))]
    [RequireComponent(typeof(BoxCollider2DAdapter))]
    public sealed class Player : MonoBehaviour
    {
        [field: SerializeField] public Motor Motor { get; private set; }
        [field: SerializeField] public BoxBody Body { get; private set; }
        [field: SerializeField] public AnimationEvents Events { get; private set; }
        [field: SerializeField] public AnimatorStateMachine StateMachine { get; private set; }
        [field: SerializeField] public BoxCollider2DAdapter ColliderAdapter { get; private set; }

        [field: Space]
        [field: SerializeField] public AbstractArmorLoader ArmorLoader { get; private set; }


        public BoxCollider2D Collider => ColliderAdapter.Collider;

        private void Reset()
        {
            Motor = GetComponent<Motor>();
            Body = GetComponent<BoxBody>();
            Events = GetComponent<AnimationEvents>();
            StateMachine = GetComponent<AnimatorStateMachine>();
            ColliderAdapter = GetComponent<BoxCollider2DAdapter>();

            ArmorLoader = GetComponentInChildren<AbstractArmorLoader>();
        }

        #region INPUTS
        public void SetMoveInput(Vector2 input)
        {
            Motor.SetMoveInput(input);
            /*ZiplineLocomotion.SetMoveInput(input);

            Crouch.SetInput(input.y);
            ClimbLadder.SetInput(input.y);*/
        }

        public void SetJumpInput(bool hasInput)
        {
            //Jump.Input.Set(hasInput);
            //WallJump.SetInput(hasInput);
        }

        public void SetDashInput(bool hasInput) { }// => Dash.Input.Set(hasInput);
        public void SetMainAttackInput(bool hasInput) { }//=> Weapons.TrySetMainWeaponInput(hasInput);
        public void SetSideAttackInput(bool hasInput) { }// => Weapons.TrySetSideWeaponInput(hasInput);
        public void SetGigaAttackInput(bool hasInput) { } //TODO => Weapons.TrySetGigaWeaponInput(hasInput);
        #endregion
    }
}