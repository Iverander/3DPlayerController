using System;
using Iverander.Input;
using NaughtyAttributes;
using UnityEngine;

namespace Iverander.Player.ThirdPerson
{
    [DisallowMultipleComponent, AddComponentMenu("Iverander/Player/ThirdPersonController")]
    public class ThirdPersonController : PlayerController
    {
        
        protected override void onMove(Vector2 direction)
        {
           localMoveDirection = new Vector3(direction.x, 0, direction.y);
        }

        protected override void onJump()
        {
            isJumping = !isJumping;
        }

        protected override Vector3 Move()
        {
            Debug.Log(Player.instance.cam);
            
            return worldMoveDirection.normalized * currentSpeed;
        }
    }
}
