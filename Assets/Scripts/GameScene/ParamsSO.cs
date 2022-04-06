using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ParamsSO : ScriptableObject
{
    [Header("ドロップを大きくするその大きさ(デフォルト:0.9f)")]
    public float touchDropSize;

    [Header("ドロップが消える判定距離(デフォルト:1f)")]
    public float dropRemoveDistance;

    //ParamsSOが保存してある場所のパス
    public const string PATH = "ParamsSO";

    //ParamsSOの実体
    private static ParamsSO _entity;
    public static ParamsSO Entity
    {
        get
        {
            //初アクセス時にロードする
            if (_entity == null)
            {
                _entity = Resources.Load<ParamsSO>(PATH);

                //ロード出来なかった場合はエラーログを表示
                if (_entity == null)
                {
                    Debug.LogError(PATH + " not found");
                }
            }

            return _entity;
        }
    }
}
