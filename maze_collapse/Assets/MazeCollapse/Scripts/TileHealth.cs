using UnityEngine;

namespace MazeCollapse

{                                                                                   /* -----------ATTACHED TO ALL THE TILES--------------*/

    public class TileHealth : MonoBehaviour
    {

        #region Variables
        //region to declare variables


        [Header("Tile Variable")]

        [Tooltip("Health of the tile : if turn 0 then it gets destroyed")]
        public int tileHealth = 1;

        #endregion

        #region UnityMethods
        //region to declare the monobehaviour methods

        private void Start()
        {
            //assigning individual health to each tile

            if (this.gameObject.CompareTag("Plane"))
            {
                tileHealth = 1;
            }
            if (this.gameObject.CompareTag("SingleBolt"))
            {
                tileHealth = 2;
            }
            if (this.gameObject.CompareTag("doubleBolt"))
            {
                tileHealth = 3;
            }
            if (this.gameObject.CompareTag("Key") || this.gameObject.CompareTag("Lock"))
            {
                tileHealth = 1;
            }
            if (this.gameObject.CompareTag("TeleportFrom") || this.gameObject.CompareTag("TeleportTo"))
            {
                tileHealth = 1;
            }

        }
        #endregion

        #region CallBackMethods
        //region to declare callback functions



        #endregion


    }

}

