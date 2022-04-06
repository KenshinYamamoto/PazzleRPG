using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FugureController : MonoBehaviour
{
    private void Start()
    {
        transform.localScale = Vector3.one;
        transform.DOMoveY(transform.position.y + 1f, 1f);
        Invoke("DestroyFigure", 0.5f);
    }

    void DestroyFigure()
    {
        Destroy(gameObject);
    }
}
