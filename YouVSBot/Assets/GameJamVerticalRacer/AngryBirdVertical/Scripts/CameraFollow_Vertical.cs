using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace fb
{

    public class CameraFollow_Vertical : MonoBehaviour
    {
        public Transform target;

        private void Update()
        {
            transform.position = new Vector3(transform.position.x,target.position.y+38.4f,transform.position.z);
        }
    }
}

