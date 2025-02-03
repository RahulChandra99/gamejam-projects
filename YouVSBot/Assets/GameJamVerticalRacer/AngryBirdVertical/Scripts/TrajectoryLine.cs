using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace fb
{

    [RequireComponent(typeof(LineRenderer))]
    public class TrajectoryLine : MonoBehaviour
    {

        private LineRenderer lineRenderer;

        private void Awake()
        {
            lineRenderer = GetComponent<LineRenderer>();
        }

        public void RenderLine(Vector3 startPt, Vector3 endPt)
        {
            lineRenderer.positionCount = 2;
            Vector3[] points = new Vector3[2];
            points[0] = startPt;
            points[1] = endPt;

            lineRenderer.SetPosition(0, startPt);
            lineRenderer.SetPosition(1, endPt);

        }

        public void EndLine()
        {
            lineRenderer.positionCount = 0;
        }
    }

}
