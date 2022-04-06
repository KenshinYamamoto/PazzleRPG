using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PlayerHPBarController : MonoBehaviour
{
    [SerializeField] Slider playerSlider;
    [SerializeField] GameObject playerHPBarFill;
    public int playerMaxHP;
    public int playerCurrentHP;

    public static PlayerHPBarController playerHPBarController;
    private void Awake()
    {
        playerHPBarController = this;
    }

    private void Start()
    {
        playerMaxHP = PlayerManager.playerManager.maxHp;
        playerCurrentHP = PlayerManager.playerManager.maxHp;
        playerSlider.maxValue = playerMaxHP;
        playerSlider.value = playerMaxHP;
    }

    public void UpdatePlayerHPBar(int laterHP)
    {
        DOTween.To(
            () => playerSlider.value,
            num => playerSlider.value = num,
            laterHP,
            0.3f);
        playerCurrentHP = laterHP;

        if(playerCurrentHP <= playerMaxHP * 0.25f)
        {
            playerHPBarFill.GetComponent<Image>().color = new Color(1f, 0.2f, 0f, 1f);
        }
        else if(playerCurrentHP <= playerMaxHP * 0.5f)
        {
            playerHPBarFill.GetComponent<Image>().color = new Color(1f, 0.392f, 0f, 1f);
        }
    }
}
