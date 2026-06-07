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

        public Action onJump;
        public void OnJump(InputAction.CallbackContext context)
        {
            if(context.performed) return;
            onJump?.Invoke();
        }

        public Action onSprint;
        public void OnSprint(InputAction.CallbackContext context)
        {
            if (context.performed) return;
            onSprint?.Invoke();
        }
    }
}
