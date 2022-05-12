using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    Dictionary<int, int> stageDict = new Dictionary<int, int>()
    {
        {101, 0},
        {102, 1},
        {103, 2},
        {104, 3},
        {105, 4},
        {106, 5},
        {107, 6},
        {108, 7},
        {109, 8},
        {110, 9}
    };
    [SerializeField] GameObject[] stageEnemys;

    private void Start()
    {
        int stageEnemy = stageDict[ProjectController.projectController.stageNumber];
        GameObject enemy = Instantiate(stageEnemys[stageEnemy], new Vector3(0, 3.11f, 0), Quaternion.identity);
        BattleManager.battleManager.enemy = enemy.GetComponent<EnemyManager>();
        FigureGenerator.figureGenerator.enemy = enemy;
    }
}
