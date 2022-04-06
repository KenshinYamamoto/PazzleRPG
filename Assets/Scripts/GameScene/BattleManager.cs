using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 戦いを管理する
// PlayerとEnemyを戦わせる

public class BattleManager : MonoBehaviour
{
    // Playerを取得する
    public PlayerManager player;
    // Enemyを取得する
    public EnemyManager enemy;

    [SerializeField] GameObject enemyHpBar;
    [SerializeField] GameObject clearText;
    [SerializeField] GameObject gameOverText;

    bool clearFlag;
    bool gameOverFlag;

    public static BattleManager battleManager;
    private void Awake()
    {
        battleManager = this;
    }
    void Start()
    {
    }

    // PlayerがEnemyに攻撃する
    public void PlayerAttack()
    {
        if (gameOverFlag)
        {
            return;
        }

        player.Attack(enemy); // PlayerがEnemyに攻撃する

        if (enemy.currentHp <= 0)
        {
            Invoke("DestroyEnemyInformation", 0.5f);
        }
    }

    // EnemyがPlayerに攻撃する
    public void EnemyAttack()
    {
        if (clearFlag)
        {
            return;
        }
        enemy.Attack(player); // EnemyがPlayerに攻撃する

        if (player.currentHp <= 0)
        {
            GameOver();
        }
    }

    void ToHomeScene()
    {
        StartCoroutine(GameController.gameController.ToHomeScene());
    }

    void DestroyEnemyInformation()
    {
        Destroy(enemyHpBar);
        Destroy(enemy.gameObject);
        Clear();
    }

    void Clear()
    {
        clearText.SetActive(true);
        clearFlag = true;
        ToHomeScene();
    }

    void GameOver()
    {
        gameOverText.SetActive(true);
        GameController.gameController.gameOver = true;
        ToHomeScene();
    }
}
