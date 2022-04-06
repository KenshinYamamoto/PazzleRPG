using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectGenerator : MonoBehaviour
{
    [SerializeField] GameObject[] effects;
    [SerializeField] Transform[] attackPlaces;
 
    public static EffectGenerator effectGenerator;
    private void Awake()
    {
        effectGenerator = this;
    }

    public void GenerateEffect(int index)
    {
        Instantiate(effects[index], attackPlaces[index].position, Quaternion.identity);
    }
}
