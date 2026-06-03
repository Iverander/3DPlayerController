using Iverander.Input;
using UnityEngine;

namespace Iverander.Player
{
    public abstract class PlayerController : MonoBehaviour
    {
        public static PlayerController instance;
        public InputReader InputReader { get; private set; } = new();
        
        public void Awake()
        {
            instance = this;
        }
        
        public void OnEnable()
        {
            InputReader.Enable();
            InputReader.onMove += onMove;
        }

        public void OnDisable()
        {
            InputReader.Disable();
            InputReader.onMove -= onMove;
        }
        
        public abstract void onMove(Vector2 direction);
    }
}
