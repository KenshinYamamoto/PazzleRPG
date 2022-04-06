using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    [SerializeField] GameObject[] enemyPrefabs;

    private void Start()
    {
        int dice = Random.Range(0, enemyPrefabs.Length);
        GameObject enemy = Instantiate(enemyPrefabs[dice], new Vector3(0, 3.11f, 0), Quaternion.identity);
        BattleManager.battleManager.enemy = enemy.GetComponent<EnemyManager>();
        FigureGenerator.figureGenerator.enemy = enemy;
    }
}
