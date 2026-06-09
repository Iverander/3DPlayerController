using System;
using UnityEngine;
using Unity.Cinemachine;

namespace Iverander.Player
{
    [DisallowMultipleComponent, DefaultExecutionOrder(-1000)]
    public class Player : MonoBehaviour
    {
        public static Player instance;
        
        [HideInInspector] public PlayerController controller;
        
        [HideInInspector] public Rigidbody rb;
        [HideInInspector] public CharacterController characterController;
        public Transform cam;

        private void Start()
        {
            instance = this;
            Cursor.lockState = CursorLockMode.Locked;
            
            controller = GetComponent<PlayerController>(); 
            
            characterController = GetComponent<CharacterController>();
            rb = GetComponent<Rigidbody>();
            cam = GetComponentInChildren<CinemachineCamera>().transform;
        }
    }
}
