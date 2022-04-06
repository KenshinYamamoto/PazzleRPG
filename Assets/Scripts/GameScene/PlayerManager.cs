using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// ƒvƒŒƒCƒ„[‚ğŠÇ—‚·‚é

public class PlayerManager : MonoBehaviour
{
    public int maxHp;
    public int currentHp;
    public int attack;
    [SerializeField] Text playerHpText;

    public static PlayerManager playerManager;
    private void Awake()
    {
        playerManager = this;
    }

    private void Start()
    {
        currentHp = maxHp;
        UpdatePlayerHp();
    }

    public void Attack(EnemyManager enemy)
    {
        enemy.Damage(attack);
    }

    public void Damage(int damage)
    {
        currentHp -= damage;
        PlayerHPBarController.playerHPBarController.UpdatePlayerHPBar(currentHp);
        PlayerFigureGenerator.playerFigureGenerator.GeneratePlayerFigure(damage);
        if (currentHp <= 0)
        {
            currentHp = 0;
        }
        UpdatePlayerHp();
    }

    void UpdatePlayerHp()
    {
        playerHpText.text = currentHp + "/" + maxHp;
    }

    public void ChangePlayerAttack(int attack)
    {
        this.attack = attack;
    }
}
