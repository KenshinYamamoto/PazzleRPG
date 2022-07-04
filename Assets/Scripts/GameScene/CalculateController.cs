using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CalculateController : MonoBehaviour
{
    public int basicPower;

    [SerializeField] GameObject[] attackTexts;
    [SerializeField] int[] attackPowers;

    [SerializeField] PlayerManager player;
    [SerializeField] EnemyManager enemy;

    public static CalculateController calculateController;
    private void Awake()
    {
        calculateController = this;
    }
    private void Start()
    {
        ResetAttackPower();
    }

    public void Calculation(int dropID,int removeAmount)
    {
        switch (dropID)
        {
            case 0: // FireDrop
                switch (EnemyManager.enemyManager.attribute)
                {
                    case 2:
                    case 3: // ����ɋ��������̏ꍇ
                        attackPowers[dropID] += removeAmount * basicPower * 2;
                        break;
                    case 1:
                    case 4: // ����Ɏア�����̏ꍇ
                        attackPowers[dropID] += removeAmount * basicPower / 2;
                        break;
                    default:
                        attackPowers[dropID] += removeAmount * basicPower;
                        break;
                }
                AddClearTimes(dropID);
                break;
            case 1: // WaterDrop
                switch (EnemyManager.enemyManager.attribute)
                {
                    case 0:
                    case 4: // ����ɋ��������̏ꍇ
                        attackPowers[dropID] += removeAmount * basicPower * 2;
                        break;
                    case 2:
                    case 3: // ����Ɏア�����̏ꍇ
                        attackPowers[dropID] += removeAmount * basicPower / 2;
                        break;
                    default:
                        attackPowers[dropID] += removeAmount * basicPower;
                        break;
                }
                AddClearTimes(dropID);
                break;
            case 2: // WindDrop
                switch (EnemyManager.enemyManager.attribute)
                {
                    case 1:
                    case 4: // ����ɋ��������̏ꍇ
                        attackPowers[dropID] += removeAmount * basicPower * 2;
                        break;
                    case 0:
                    case 3: // ����Ɏア�����̏ꍇ
                        attackPowers[dropID] += removeAmount * basicPower / 2;
                        break;
                    default:
                        attackPowers[dropID] += removeAmount * basicPower;
                        break;
                }
                AddClearTimes(dropID);
                break;
            case 3: // ThunderDrop
                switch (EnemyManager.enemyManager.attribute)
                {
                    case 1:
                    case 2: // ����ɋ��������̏ꍇ
                        attackPowers[dropID] += removeAmount * basicPower * 2;
                        break;
                    case 0:
                    case 4: // ����Ɏア�����̏ꍇ
                        attackPowers[dropID] += removeAmount * basicPower / 2;
                        break;
                    default:
                        attackPowers[dropID] += removeAmount * basicPower;
                        break;
                }
                AddClearTimes(dropID);
                break;
            case 4: // SoilDrop
                switch (EnemyManager.enemyManager.attribute)
                {
                    case 0:
                    case 3: // ����ɋ��������̏ꍇ
                        attackPowers[dropID] += removeAmount * basicPower * 2;
                        break;
                    case 1:
                    case 2: // ����Ɏア�����̏ꍇ
                        attackPowers[dropID] += removeAmount * basicPower / 2;
                        break;
                    default:
                        attackPowers[dropID] += removeAmount * basicPower;
                        break;
                }
                AddClearTimes(dropID);
                break;
        }
    }

    void AddClearTimes(int attackPower)
    {
        attackPowers[attackPower] += ProjectController.projectController.clearTimes;
        attackTexts[attackPower].GetComponent<Text>().text = attackPowers[attackPower].ToString("N0");
    }

    public void ResetAttackPower()
    {
        for (int i = 0; i < attackTexts.Length; i++)
        {
            attackPowers[i] = 0;
            attackTexts[i].GetComponent<Text>().text = attackPowers[i].ToString();
        }
    }

    public IEnumerator FromPlayerToEnemyAttack()
    {
        for (int i = 0;i < attackPowers.Length; i++)
        {
            if(attackPowers[i] == 0)
            {
                yield return null;
            }
            else if(EnemyManager.enemyManager.currentHp <= 0)
            {
                yield return null;
            }
            else
            {
                EffectGenerator.effectGenerator.GenerateEffect(i);
                yield return new WaitForSeconds(0.5f);
                FigureGenerator.figureGenerator.GenerateFigure(i,attackPowers[i]);
                player.attack = attackPowers[i];
                BattleManager.battleManager.PlayerAttack();
                switch(i){
                    case 0: AudioManager.audioManager.PlaySE(AudioManager.SE.FireAttack); break;
                    case 1: AudioManager.audioManager.PlaySE(AudioManager.SE.WaterAttack); break;
                    case 2: AudioManager.audioManager.PlaySE(AudioManager.SE.WindAttack); break;
                    case 3: AudioManager.audioManager.PlaySE(AudioManager.SE.ThunderAttack); break;
                    case 4: AudioManager.audioManager.PlaySE(AudioManager.SE.SoilAttack); break;
                    default: break;
                }
            }
        }
        ResetAttackPower();
        yield return new WaitForSeconds(1f);
        GameController.gameController.EnemyTurn();
    }
}
