using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ParamsSO : ScriptableObject
{
    [Header("ドロップをタッチしているときの大きさ(デフォルト:0.9f)")]
    public float touchDropSize;

    [Header("判定するドロップの距離(デフォルト:1f)")]
    public float dropRemoveDistance;

    public const string PATH = "ParamsSO";

    private static ParamsSO _entity;
    public static ParamsSO Entity
    {
        get
        {
            if (_entity == null)
            {
                _entity = Resources.Load<ParamsSO>(PATH);

                if (_entity == null)
                {
                    Debug.LogError(PATH + " not found");
                }
            }

            return _entity;
        }
    }
}
