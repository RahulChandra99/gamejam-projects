using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace fb
{
    public class BackgroundScroll_Vertical : MonoBehaviour
    {
        public Transform bg_center;

        private void Update()
        {
            if (transform.position.y >= bg_center.position.y + 102.4f)
                bg_center.position = new Vector2(bg_center.position.x, transform.position.y + 102.4f);

            if (transform.position.y <= bg_center.position.y - 102.4f)
                bg_center.position = new Vector2(bg_center.position.x, transform.position.y - 102.4f);


        }
    }
}

