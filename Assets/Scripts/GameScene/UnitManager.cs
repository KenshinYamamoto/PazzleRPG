using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UnitManager : MonoBehaviour
{
    public int hp;
    public int attack;

    public void Attack(UnitManager target)
    {
        target.Damage(attack);
    }

    void Damage(int damage)
    {
        hp -= damage;
    }
}
