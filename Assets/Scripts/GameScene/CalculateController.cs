using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CalculateController : MonoBehaviour
{
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
                    case 3: // ‘Šè‚É‹­‚¢‘®«‚Ìê‡
                        attackPowers[0] += removeAmount * 100 * 2;
                        break;
                    case 1:
                    case 4: // ‘Šè‚Éã‚¢‘®«‚Ìê‡
                        attackPowers[0] += removeAmount * 100 / 2;
                        break;
                    default:
                        attackPowers[0] += removeAmount * 100;
                        break;
                }
                attackTexts[0].GetComponent<Text>().text = attackPowers[0].ToString("N0");
                break;
            case 1: // WaterDrop
                switch (EnemyManager.enemyManager.attribute)
                {
                    case 0:
                    case 4: // ‘Šè‚É‹­‚¢‘®«‚Ìê‡
                        attackPowers[1] += removeAmount * 100 * 2;
                        break;
                    case 2:
                    case 3: // ‘Šè‚Éã‚¢‘®«‚Ìê‡
                        attackPowers[1] += removeAmount * 100 / 2;
                        break;
                    default:
                        attackPowers[1] += removeAmount * 100;
                        break;
                }
                attackTexts[1].GetComponent<Text>().text = attackPowers[1].ToString("N0");
                break;
            case 2: // WindDrop
                switch (EnemyManager.enemyManager.attribute)
                {
                    case 1:
                    case 4: // ‘Šè‚É‹­‚¢‘®«‚Ìê‡
                        attackPowers[2] += removeAmount * 100 * 2;
                        break;
                    case 0:
                    case 3: // ‘Šè‚Éã‚¢‘®«‚Ìê‡
                        attackPowers[2] += removeAmount * 100 / 2;
                        break;
                    default:
                        attackPowers[2] += removeAmount * 100;
                        break;
                }
                attackTexts[2].GetComponent<Text>().text = attackPowers[2].ToString("N0");
                break;
            case 3: // ThunderDrop
                switch (EnemyManager.enemyManager.attribute)
                {
                    case 1:
                    case 2: // ‘Šè‚É‹­‚¢‘®«‚Ìê‡
                        attackPowers[3] += removeAmount * 100 * 2;
                        break;
                    case 0:
                    case 4: // ‘Šè‚Éã‚¢‘®«‚Ìê‡
                        attackPowers[3] += removeAmount * 100 / 2;
                        break;
                    default:
                        attackPowers[3] += removeAmount * 100;
                        break;
                }
                attackTexts[3].GetComponent<Text>().text = attackPowers[3].ToString("N0");
                break;
            case 4: // SoilDrop
                switch (EnemyManager.enemyManager.attribute)
                {
                    case 0:
                    case 3: // ‘Šè‚É‹­‚¢‘®«‚Ìê‡
                        attackPowers[4] += removeAmount * 100 * 2;
                        break;
                    case 1:
                    case 2: // ‘Šè‚Éã‚¢‘®«‚Ìê‡
                        attackPowers[4] += removeAmount * 100 / 2;
                        break;
                    default:
                        attackPowers[4] += removeAmount * 100;
                        break;
                }
                attackTexts[4].GetComponent<Text>().text = attackPowers[4].ToString("N0");
                break;
        }
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
            }
        }
        ResetAttackPower();
        yield return new WaitForSeconds(1f);
        GameController.gameController.EnemyTurn();
    }
}
