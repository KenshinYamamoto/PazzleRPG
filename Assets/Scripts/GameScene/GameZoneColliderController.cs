using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameZoneColliderController : MonoBehaviour
{
    Vector2[] points = new Vector2[4];

    [SerializeField] GameObject leftAboveObj;
    [SerializeField] GameObject leftButtonObj;
    [SerializeField] GameObject rightAboveObj;
    [SerializeField] GameObject rightButtonObj;

    private void Start()
    {
        EdgeCollider2D edgeCollider2D = GetComponent<EdgeCollider2D>();

        points[0] = leftAboveObj.transform.position;
        points[1] = leftButtonObj.transform.position;
        points[2] = rightButtonObj.transform.position;
        points[3] = rightAboveObj.transform.position;

        edgeCollider2D.points = points;
    }

}
