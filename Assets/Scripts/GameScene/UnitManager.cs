using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �L�����N�^�[���Ǘ�����

public class UnitManager : MonoBehaviour
{
    // �X�e�[�^�X
    public int hp; // �̗�
    public int attack; // �U����

    // �U������֐�
    public void Attack(UnitManager target)
    {
        target.Damage(attack);
    }

    // �_���[�W���󂯂�֐�
    void Damage(int damage)
    {
        hp -= damage;
    }
}
