using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MazeCollapse
{
                                                /* --------------------ATTACHED TO PLAYER GAME OBJECT ----------------------*/

    public class PlayerController : MonoBehaviour
    {
        #region Variables
        //region to declare variables

        private bool isMoving;
        private Vector3 targetPos, originalPos;
        private float timeBetweenMovement = 0.4f;

        #endregion

        #region UnityMethods
        //region to declare the monobehaviour methods

        private void OnTriggerEnter(Collider other)
        {

            //Death Trigger
            if (other.gameObject.CompareTag("Death"))
            {
                SceneManager.LoadScene("LevelSelectionScreen");
            }
        }

        #endregion

        #region CallBackMethods
        //region to declare callback functions

        public void ArrowButton(int arrowNumber)
        {
            if (!isMoving)
            {
                switch (arrowNumber)                                                            /*right : 1
                                                                                                                   down : 2
                                                                                                                   left : 3
                                                                                                                   up : 4 */
                {
                    case 1:
                        
                        StartCoroutine(GridMove(Vector3.right));
                        break;
                    case 2:
                        
                        StartCoroutine(GridMove(Vector3.back));
                        break;
                    case 3:
                        
                        StartCoroutine(GridMove(Vector3.left));
                        break;
                    case 4:
                        
                        StartCoroutine(GridMove(Vector3.forward));
                        break;
                    default: break;
                }
            }

        }

        IEnumerator GridMove(Vector3 direction)
        { 
            isMoving = true;
            float elapsedTime = 0f;
            originalPos = transform.position;
            targetPos = direction*1.5f + originalPos;

            while(elapsedTime < timeBetweenMovement)
            {
                transform.position = Vector3.Lerp(originalPos, targetPos, (elapsedTime / timeBetweenMovement));
                elapsedTime += Time.deltaTime;
                yield return null;
            }
            
            transform.position = targetPos;
            isMoving = false;
        }

        #endregion
    }

}
