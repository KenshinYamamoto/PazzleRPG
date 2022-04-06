using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ParamsSO : ScriptableObject
{
    [Header("�h���b�v��傫�����邻�̑傫��(�f�t�H���g:0.9f)")]
    public float touchDropSize;

    [Header("�h���b�v�������锻�苗��(�f�t�H���g:1f)")]
    public float dropRemoveDistance;

    //ParamsSO���ۑ����Ă���ꏊ�̃p�X
    public const string PATH = "ParamsSO";

    //ParamsSO�̎���
    private static ParamsSO _entity;
    public static ParamsSO Entity
    {
        get
        {
            //���A�N�Z�X���Ƀ��[�h����
            if (_entity == null)
            {
                _entity = Resources.Load<ParamsSO>(PATH);

                //���[�h�o���Ȃ������ꍇ�̓G���[���O��\��
                if (_entity == null)
                {
                    Debug.LogError(PATH + " not found");
                }
            }

            return _entity;
        }
    }
}
