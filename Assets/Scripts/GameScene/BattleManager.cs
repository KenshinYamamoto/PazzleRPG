using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �킢���Ǘ�����
// Player��Enemy���킹��

public class BattleManager : MonoBehaviour
{
    // Player���擾����
    public PlayerManager player;
    // Enemy���擾����
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

    // Player��Enemy�ɍU������
    public void PlayerAttack()
    {
        if (gameOverFlag)
        {
            return;
        }

        player.Attack(enemy); // Player��Enemy�ɍU������

        if (enemy.currentHp <= 0)
        {
            Invoke("DestroyEnemyInformation", 0.5f);
        }
    }

    // Enemy��Player�ɍU������
    public void EnemyAttack()
    {
        if (clearFlag)
        {
            return;
        }
        enemy.Attack(player); // Enemy��Player�ɍU������

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
        AudioManager.audioManager.PlaySE(AudioManager.SE.Clear);
        ProjectController.projectController.AddClearTimes();
        clearText.SetActive(true);
        clearFlag = true;
        ToHomeScene();
    }

    void GameOver()
    {
        AudioManager.audioManager.PlaySE(AudioManager.SE.Gameover);
        gameOverText.SetActive(true);
        GameController.gameController.gameOver = true;
        ToHomeScene();
    }
}
