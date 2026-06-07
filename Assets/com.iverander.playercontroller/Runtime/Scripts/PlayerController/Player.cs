using System;
using UnityEngine;

namespace Iverander.Player
{
    [DisallowMultipleComponent, DefaultExecutionOrder(-1000)]
    public class Player : MonoBehaviour
    {
        public static Player instance;
        
        [HideInInspector] public PlayerController controller;
        
        [HideInInspector] public Rigidbody rb;
        [HideInInspector] public CharacterController characterController;
        [HideInInspector] public Camera cam;

        private void Awake()
        {
            instance = this;
        }

        private void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
            
            controller = GetComponent<PlayerController>(); 
            
            characterController = GetComponent<CharacterController>();
            rb = GetComponent<Rigidbody>();
            cam = GetComponentInChildren<Camera>();
        }
    }
}
