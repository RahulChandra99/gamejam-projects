using System.Collections;
using UnityEngine;

namespace MazeCollapse
{
                                                  /*-----------     ATTACHED TO PLAYER GAMEOBJECT      --------------*/

    public class TileDestruction : MonoBehaviour
    {
        

        #region Variables
        //region to declare variables

        public bool isCollided;

        [Tooltip("To be used for level 3 only : Transportation tile")]
        public Transform teleportToTile_3 = null;


        #endregion

        #region UnityMethods
        //region to declare the monobehaviour methods


        //conditions to be met when player collides with different types of tiles

        private void OnCollisionEnter(Collision collision)
        {
            

            //FOR KEY TILE
            if (collision.gameObject.CompareTag("Key") )
            {
                //make bool to true
                LevelManager.Instance.isKeyPicked = true;

                //can pick key now
                collision.transform.GetChild(0).SetParent(this.transform);


                //reduce tile health now
                collision.gameObject.GetComponent<TileHealth>().tileHealth--;

                

            }

            //FOR LOCK TILE
            if (collision.gameObject.CompareTag("Lock"))
            {
                if (LevelManager.Instance.isKeyPicked)
                {
                    //make bool true
                    LevelManager.Instance.isLockedUnLocked = true;

                    //hide the key child
                    this.gameObject.transform.GetChild(1).gameObject.SetActive(false);

                    //remove the lock collider
                    //collision.gameObject.transform.GetChild(1).GetComponent<BoxCollider>().enabled = false;

                    //reduce tile health
                    collision.gameObject.GetComponent<TileHealth>().tileHealth--;

                    
                }
            }

            //for BLUE END TILE
            if (collision.gameObject.CompareTag("BlueEnd") && !isCollided)
            {
                if(LevelManager.Instance.isBlueUnlocked)
                {
                    //reduce tile health
                    collision.gameObject.GetComponent<TileHealth>().tileHealth--;
                    LevelManager.Instance.isLevelEnded = true;

                    isCollided = true;
                }
            }

            //for all PLANE TILES
            if (collision.gameObject.CompareTag("Plane") )
            {
                //reduce tile health
                collision.gameObject.GetComponent<TileHealth>().tileHealth--;

                
            }

            //FOR SINGLE BOLT
            if (collision.gameObject.CompareTag("SingleBolt") && !isCollided)
            {
                //remove bolt logo once
                collision.transform.GetChild(0).gameObject.SetActive(false);

                //reduce tile health now
                collision.gameObject.GetComponent<TileHealth>().tileHealth--;

                isCollided = true;
            }

            //FOR DOUBLE BOLT
            if (collision.gameObject.CompareTag("doubleBolt") && !isCollided)
            {
                //remove bolt logo once
                collision.transform.GetChild(1).gameObject.SetActive(false);

                if (collision.gameObject.GetComponent<TileHealth>().tileHealth == 2)
                    collision.transform.GetChild(0).gameObject.SetActive(false);


                //reduce tile health now
                collision.gameObject.GetComponent<TileHealth>().tileHealth--;

                isCollided = true;
            }

            //FOR TELEPORT FROM TILE
            if (collision.gameObject.CompareTag("TeleportFrom"))
            {
                //reduce tile health
                collision.gameObject.GetComponent<TileHealth>().tileHealth--;
                StartCoroutine("Teleportation");
            }

            if (collision.gameObject.CompareTag("TeleportTo"))
            {
                //reduce tile health
                collision.gameObject.GetComponent<TileHealth>().tileHealth--;
                
            }

        }

        private void OnCollisionExit(Collision collision)
        {

            //FOR KEY TILE
            if (collision.gameObject.CompareTag("Key") )
            {
                

                if (collision.gameObject.GetComponent<TileHealth>().tileHealth <= 0)
                {
                    collision.gameObject.AddComponent<Rigidbody>();
                    StartCoroutine(TileFallDown(collision.gameObject));

                    
                    LevelManager.Instance.numberOfTiles--;
                }
            }

            //FOR LOCK TILE
            if (collision.gameObject.CompareTag("Lock"))
            {
                

                if (collision.gameObject.GetComponent<TileHealth>().tileHealth <= 0)
                {
                    collision.gameObject.AddComponent<Rigidbody>();
                    StartCoroutine(TileFallDown(collision.gameObject));

                    LevelManager.Instance.numberOfTiles--;
                }
            }

            //for BLUE END TILE
            if (collision.gameObject.CompareTag("BlueEnd") && isCollided)
            {
                isCollided = false;

                if (collision.gameObject.GetComponent<TileHealth>().tileHealth <= 0)
                {
                    collision.gameObject.AddComponent<Rigidbody>();
                    StartCoroutine(TileFallDown(collision.gameObject));


                    LevelManager.Instance.numberOfTiles--;
                }
            }

            //for all PLANE TILES
            if (collision.gameObject.CompareTag("Plane") )
            {
                

                if (collision.gameObject.GetComponent<TileHealth>().tileHealth <= 0)
                {
                    collision.gameObject.AddComponent<Rigidbody>();
                    StartCoroutine(TileFallDown(collision.gameObject));


                    LevelManager.Instance.numberOfTiles--;
                }
            }

            //FOR SINGLE BOLT
            if (collision.gameObject.CompareTag("SingleBolt") && isCollided)
            {
                isCollided = false;

                if (collision.gameObject.GetComponent<TileHealth>().tileHealth <= 0)
                {
                    collision.gameObject.AddComponent<Rigidbody>();
                    StartCoroutine(TileFallDown(collision.gameObject));

                    LevelManager.Instance.numberOfTiles--;
                }
            }

            //FOR DOUBLE BOLT
            if (collision.gameObject.CompareTag("doubleBolt") && isCollided)
            {
                isCollided = false;
                
                if (collision.gameObject.GetComponent<TileHealth>().tileHealth <= 0)
                {
                    collision.gameObject.AddComponent<Rigidbody>();
                    StartCoroutine(TileFallDown(collision.gameObject));

                    LevelManager.Instance.numberOfTiles--;
                }
            }

            if (collision.gameObject.CompareTag("TeleportFrom"))
            {
               

                if (collision.gameObject.GetComponent<TileHealth>().tileHealth <= 0)
                {
                    collision.gameObject.AddComponent<Rigidbody>();
                    StartCoroutine(TileFallDown(collision.gameObject));

                    LevelManager.Instance.numberOfTiles--;
                }
            }

            if (collision.gameObject.CompareTag("TeleportTo"))
            {


                if (collision.gameObject.GetComponent<TileHealth>().tileHealth <= 0)
                {
                    collision.gameObject.AddComponent<Rigidbody>();
                    StartCoroutine(TileFallDown(collision.gameObject));

                    LevelManager.Instance.numberOfTiles--;
                }
            }
        }

        #endregion

        #region CallBackMethods
        //region to declare callback functions



        IEnumerator TileFallDown(GameObject col)
        {
            //to cause the fall down motion of tiles 
            yield return new WaitForSeconds(0.8f);
            col.SetActive(false);
        }

        IEnumerator Teleportation()
        {
            //for the teleportation tiles
            yield return new WaitForSeconds(1f);
            this.gameObject.transform.position = teleportToTile_3.position;
            
        }

        #endregion
    }

}




