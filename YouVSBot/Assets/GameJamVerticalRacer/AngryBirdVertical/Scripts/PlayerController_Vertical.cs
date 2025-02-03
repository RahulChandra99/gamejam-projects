using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace fb
{
    public class PlayerController_Vertical : MonoBehaviour
    {
        /* VARIABLES*/
        private Rigidbody2D playerRB;
        private TrajectoryLine trajectoryLine;

        [Header("DragToShoot variables")]
        public float launchPower = 10f;
        public Vector2 minPower;
        public Vector2 maxPower;
        //public Transform TrajectoryStartPos;
        private Vector3 startPos;
        private Vector3 endPos;
        private Vector2 force;
        public bool canMovenow;
        /* UNITY METHODS*/


        private void Awake()
        {
            playerRB = GetComponent<Rigidbody2D>();
            trajectoryLine = GetComponent<TrajectoryLine>();
            canMovenow = true;
        }

        private void Update()
        {
            HoldToMove();
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("canHold&Move"))
            {
                Debug.Log("Collided");
                canMovenow = true;
            }
            if(other.gameObject.CompareTag("Dead"))
            {
                SceneManager.LoadSceneAsync("GameScene_VerticalRunner");
            }
        }

        

        /* CALLBACK METHODS*/

        void HoldToMove()
        {
            if (canMovenow)
            {

                if (Input.GetMouseButtonDown(0))
                {

                    startPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    startPos.z = 15;

                }

                if (Input.GetMouseButton(0))
                {
                    Time.timeScale = 0.2f;
                    Time.fixedDeltaTime = 0.02f * Time.timeScale;

                    Vector3 currentPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    currentPos.z = 15;
                    trajectoryLine.RenderLine(startPos, currentPos);
                }

                if (Input.GetMouseButtonUp(0))
                {
                    Time.timeScale = 1f;
                    Time.fixedDeltaTime = 0.02f * Time.timeScale;

                    endPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    endPos.z = 15;

                    force = new Vector2(Mathf.Clamp(startPos.x - endPos.x, minPower.x, maxPower.x), Mathf.Clamp(startPos.y - endPos.y, minPower.y, maxPower.y));
                    playerRB.velocity = force * launchPower;

                    trajectoryLine.EndLine();
                    canMovenow = false;
                }
            }
        }
    }
}

