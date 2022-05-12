using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

// “G‚ğŠÇ—‚·‚é

public class EnemyManager : MonoBehaviour
{
    public int maxHp;
    public int currentHp;
    public int minAttack;
    public int maxAttack;
    [SerializeField] GameObject enemyHpSliderFill;
    [SerializeField] GameObject enemyAttribute;
    [Range(0,4)]
    public int attribute;

    public static EnemyManager enemyManager;
    private void Awake()
    {
        enemyManager = this;
    }

    private void Start()
    {
        enemyHpSliderFill = GameObject.Find("EnemyFill");
        ChangeAttribute();
        currentHp = maxHp;
    }

    public void Attack(PlayerManager player)
    {
        int attack = Random.Range(minAttack, maxAttack);
        player.Damage(attack);
        transform.DOShakePosition(1f);
    }

    public void Damage(int damage)
    {
        transform.DOShakePosition(0.2f);

        currentHp -= damage;
        EnemyHPBarController.enemyHPBarController.UpdateEnemyHPBar(currentHp);
        if (currentHp <= 0)
        {
            currentHp = 0;
        }
    }

    void ChangeAttribute()
    {
        switch (attribute)
        {
            case 0: // ‰Î‘®«
                enemyHpSliderFill.GetComponent<Image>().color = Color.red;
                enemyAttribute.GetComponent<SpriteRenderer>().color = Color.red;
                break;
            case 1: // …‘®«
                enemyHpSliderFill.GetComponent<Image>().color = Color.blue;
                enemyAttribute.GetComponent<SpriteRenderer>().color = Color.blue;
                break;
            case 2: // •—‘®«
                enemyHpSliderFill.GetComponent<Image>().color = Color.green;
                enemyAttribute.GetComponent<SpriteRenderer>().color = Color.green;
                break;
            case 3: // —‹‘®«
                enemyHpSliderFill.GetComponent<Image>().color = Color.yellow;
                enemyAttribute.GetComponent<SpriteRenderer>().color = Color.yellow;
                break;
            case 4: // “y‘®«
                enemyHpSliderFill.GetComponent<Image>().color = new Color(0.8156863f, 0.3098039f,0f,1f);
                enemyAttribute.GetComponent<SpriteRenderer>().color = new Color(0.8156863f, 0.3098039f, 0f, 1f);
                break;
        }
    }
}
