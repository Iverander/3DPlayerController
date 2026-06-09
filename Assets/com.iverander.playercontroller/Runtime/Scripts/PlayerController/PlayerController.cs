using System;
using Iverander.Input;
using NaughtyAttributes;
using UnityEngine;

namespace Iverander.Player
{
    public abstract class PlayerController : MonoBehaviour
    {
        [Header("References")]
        protected CharacterController characterController => Player.instance.characterController;
        public InputReader InputReader { get; private set; } = new();


        [Header("Settings")] 
        public Vector2 speed;
        public float jumpForce;
        public float mass = 2;
        [SerializeField] bool reverseSprint = false;
        
        [Header("Values")]
        [ReadOnly] public Vector3 localMoveDirection;
        [ReadOnly] public Vector3 velocity;
        [ReadOnly] public bool isSprinting;
        [ReadOnly] public bool isJumping;
        
        public virtual Vector3 worldMoveDirection => Quaternion.Euler(0, Player.instance.cam.transform.eulerAngles.y,0) * localMoveDirection;
        public virtual bool IsGrounded => characterController.isGrounded;
        public virtual float currentSpeed => isSprinting ? speed.y : speed.x;

        public void OnEnable()
        {
            isSprinting = reverseSprint;
            
            InputReader.Enable();
            InputReader.onMove += onMove;
            InputReader.onJump += onJump;
            InputReader.onSprint += onSprint;
        }

        public void OnDisable()
        {
            InputReader.Disable();
            InputReader.onMove -= onMove;
            InputReader.onJump -= onJump;
            InputReader.onSprint -= onSprint;
        }
        protected abstract void onMove(Vector2 direction);
        protected abstract void onJump();
        protected virtual void onSprint() => isSprinting = !isSprinting;

        void Update()
        {
            if (IsGrounded)
            {
                velocity.y = 0;   
                
                if(isJumping)
                    velocity.y = Mathf.Sqrt(jumpForce * -3 * Physics.gravity.y);
            }
            
            MovementCalculation(Move());
        }
        
        protected abstract Vector3 Move();

        protected virtual void Gravity()
        {
            velocity += Physics.gravity * (mass * Time.deltaTime);
        }
        private void MovementCalculation(Vector3 moveValue)
        {
            Gravity();
            characterController.Move((velocity + moveValue) * Time.deltaTime);
        }
    }
}
