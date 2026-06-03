using Iverander.Input;
using UnityEngine;

namespace Iverander.Player.ThirdPerson
{
    public class ThirdPersonController : PlayerController
    {
        public Vector3 moveDirection;
        
        public override void onMove(Vector2 direction)
        {
           Debug.Log(direction);
        }
    }
}
