using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// キャラクターを管理する

public class UnitManager : MonoBehaviour
{
    // ステータス
    public int hp; // 体力
    public int attack; // 攻撃力

    // 攻撃する関数
    public void Attack(UnitManager target)
    {
        target.Damage(attack);
    }

    // ダメージを受ける関数
    void Damage(int damage)
    {
        hp -= damage;
    }
}
