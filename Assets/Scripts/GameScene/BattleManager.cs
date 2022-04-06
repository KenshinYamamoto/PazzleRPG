using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// í‚¢‚ğŠÇ—‚·‚é
// Player‚ÆEnemy‚ğí‚í‚¹‚é

public class BattleManager : MonoBehaviour
{
    // Player‚ğæ“¾‚·‚é
    public PlayerManager player;
    // Enemy‚ğæ“¾‚·‚é
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

    // Player‚ªEnemy‚ÉUŒ‚‚·‚é
    public void PlayerAttack()
    {
        if (gameOverFlag)
        {
            return;
        }

        player.Attack(enemy); // Player‚ªEnemy‚ÉUŒ‚‚·‚é

        if (enemy.currentHp <= 0)
        {
            Invoke("DestroyEnemyInformation", 0.5f);
        }
    }

    // Enemy‚ªPlayer‚ÉUŒ‚‚·‚é
    public void EnemyAttack()
    {
        if (clearFlag)
        {
            return;
        }
        enemy.Attack(player); // Enemy‚ªPlayer‚ÉUŒ‚‚·‚é

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
