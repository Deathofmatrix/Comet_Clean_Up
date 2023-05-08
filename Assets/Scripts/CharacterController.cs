using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

namespace CometCleanUP
{
    public class CharacterController : MonoBehaviour
    {
        //UnityEvent playerMovementUnityEvent;

        [SerializeField] private InputActionReference thrust, turn;
        private Rigidbody2D rb2D;

        [SerializeField] private float moveSpeed;
        [SerializeField] private float turnSpeed;
        [SerializeField] private float maxVelocity;

        [SerializeField] private AudioSource audioSource;
        [SerializeField] private AudioClip clip;

        [SerializeField] private GameObject fire;
        
        private float thrustInput;
        private float turnInput;

        private void Awake()
        {
            rb2D = GetComponent<Rigidbody2D>();
        }
        void Start()
        {
            PlayerManager.playerCharacter = gameObject;
        }

        void Update()
        {
            thrustInput = thrust.action.ReadValue<float>();
            turnInput = turn.action.ReadValue<float>();

            bool clipPlayed = false;

            if (thrustInput > 0 )
            {
                fire.SetActive(true);
                if (clipPlayed == false )
                {
                    audioSource.PlayOneShot(clip);
                    clipPlayed = true;
                }
            }
            else
            {
                fire.SetActive(false);
                audioSource.Stop();
                clipPlayed= false;
            }

            ClampVelocity();

        }

        private void FixedUpdate()
        {
            ThrustForward(thrustInput * moveSpeed);
            TurnShip(turnInput * turnSpeed);
        }

        private void ClampVelocity()
        {
            if(rb2D.velocity.magnitude > maxVelocity)
            {
                rb2D.velocity = Vector2.ClampMagnitude(rb2D.velocity, maxVelocity);
            }
        }

        private void ThrustForward(float amount)
        {
            Vector2 force = transform.up * amount;

            rb2D.AddForce(force);
        }

        private void TurnShip(float amount)
        {
            rb2D.MoveRotation(rb2D.rotation - amount * Time.fixedDeltaTime);
        }
    }
}
