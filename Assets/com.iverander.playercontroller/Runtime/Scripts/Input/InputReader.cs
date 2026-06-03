using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Iverander.Input
{
    public class InputReader : PlayerInput.IPlayerActions
    {
        private PlayerInput actions;
        public void Enable()
        {
            actions = new PlayerInput();
            actions.Player.SetCallbacks(this);
            actions.Enable();
        }

        public void Disable()
        {
            actions.Disable();
        }
        
        public Action<Vector2> onMove;
        public void OnMove(InputAction.CallbackContext context)
        {
            onMove?.Invoke(context.ReadValue<Vector2>());
        }

        
        public void OnLook(InputAction.CallbackContext context)
        {
        }

        public void OnAttack(InputAction.CallbackContext context)
        {
        }

        public void OnInteract(InputAction.CallbackContext context)
        {
        }

        public void OnCrouch(InputAction.CallbackContext context)
        {
        }

        public void OnJump(InputAction.CallbackContext context)
        {
        }

        public void OnSprint(InputAction.CallbackContext context)
        {
        }
    }
}
