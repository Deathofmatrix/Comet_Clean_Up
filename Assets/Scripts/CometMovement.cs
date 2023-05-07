using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

namespace CometCleanUP
{
    public class CometMovement : MonoBehaviour
    {
        public delegate void CometDeath(int score);
        public static event CometDeath cometDeathEvent;

        public CometType cometType;
        private Rigidbody2D currentRigidbody2D;
        private SpriteRenderer currentSpriteRenderer;

        [SerializeField] private float minDistanceFromPlayer;
        [SerializeField] private Transform targetPosition;
        [SerializeField] private float moveSpeed;
        [SerializeField] private int cometValue;

        private Vector2 heading;
        private float distance;
        private Vector2 direction;

        private void Awake()
        {
            currentRigidbody2D = GetComponent<Rigidbody2D>();
            currentSpriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void Start()
        {
            targetPosition = PlayerManager.playerCharacter.transform;

            currentSpriteRenderer.color = cometType.color;
            moveSpeed = cometType.speed;
            cometValue = cometType.value;
        }

        private void Update()
        {
            heading = (Vector2)targetPosition.position - currentRigidbody2D.position;
            distance = heading.magnitude;
            direction = heading / distance;
        }

        private void FixedUpdate()
        {
            MoveAway();
        }

        void MoveAway()
        {
            if (distance < minDistanceFromPlayer)
            {
                currentRigidbody2D.MovePosition(currentRigidbody2D.position - direction * moveSpeed * Time.deltaTime);
            }
        }

        private void OnDestroy()
        {
            if (cometDeathEvent != null)
            {
                cometDeathEvent(cometValue);
            }
        }
    }
}
