using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class EnemyHPBarController : MonoBehaviour
{
    [SerializeField] Slider enemySlider;
    public int enemyMaxHP;
    public int enemyCurrentHP;

    public static EnemyHPBarController enemyHPBarController;
    private void Awake()
    {
        enemyHPBarController = this;
    }

    private void Start()
    {
        enemyMaxHP = EnemyManager.enemyManager.maxHp;
        enemyCurrentHP = EnemyManager.enemyManager.maxHp;
        enemySlider.maxValue = enemyMaxHP;
        enemySlider.value = enemyMaxHP;
    }

    public void UpdateEnemyHPBar(int laterHP)
    {
        DOTween.To(
            () => enemySlider.value,
            num => enemySlider.value = num,
            laterHP,
            0.3f);
        enemyCurrentHP = laterHP;
    }
}
