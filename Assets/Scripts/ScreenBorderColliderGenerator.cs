using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CometCleanUP
{
    public class ScreenBorderColliderGenerator : MonoBehaviour
    {
        [SerializeField] private Camera _camera;
        private Vector3 cameraPos;

        Vector2 screenSize;

        public float colliderThickness;
        public float zPosition = 0f;

        Transform topCollider;
        Transform bottomCollider;
        Transform leftCollider;
        Transform rightCollider;

        float cameraHeight;

        void Start()
        {
            topCollider = new GameObject().transform;
            bottomCollider = new GameObject().transform;
            leftCollider = new GameObject().transform;
            rightCollider = new GameObject().transform;

            topCollider.name = "TopCollider";
            bottomCollider.name = "BottomCollider";
            leftCollider.name = "LeftCollider";
            rightCollider.name = "RightCollider";

            topCollider.gameObject.AddComponent<BoxCollider2D>();
            bottomCollider.gameObject.AddComponent<BoxCollider2D>();
            leftCollider.gameObject.AddComponent<BoxCollider2D>();
            rightCollider.gameObject.AddComponent<BoxCollider2D>();

            topCollider.parent = transform;
            bottomCollider.parent = transform;
            leftCollider.parent = transform;
            rightCollider.parent = transform;

            cameraPos = _camera.transform.position;
            screenSize.x = Vector2.Distance(_camera.ScreenToWorldPoint(new Vector2(0, 0)), _camera.ScreenToWorldPoint(new Vector2(Screen.width, 0))) * 0.5f;
            screenSize.y = Vector2.Distance(_camera.ScreenToWorldPoint(new Vector2(0, 0)), _camera.ScreenToWorldPoint(new Vector2(0, Screen.height))) * 0.5f;

            rightCollider.localScale = new Vector3(colliderThickness, screenSize.y * 2, colliderThickness);
            rightCollider.position = new Vector3(cameraPos.x + screenSize.x + (rightCollider.localScale.x * 0.5f), cameraPos.y, zPosition);



            
        }

        void Update()
        {

        }
    }
}
