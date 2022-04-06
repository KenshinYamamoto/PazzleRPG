using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EffectController : MonoBehaviour
{
    public GameObject enemy;

    public static EffectController effectController;
    private void Awake()
    {
        effectController = this;
    }

    private void Start()
    {
        transform.DOMove(enemy.transform.position, 0.5f);
        Invoke("DestroyEffect", 0.5f);
    }

    void DestroyEffect()
    {
        Destroy(this.gameObject);
    }
}
