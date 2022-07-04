using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    [SerializeField] GameObject menuCanvas;
    [SerializeField] GameObject retireAttention;
    [SerializeField] Text stageNameText;
    [SerializeField] Text addAttackPowerText;

    int menuButtonPushCount;

    Dictionary<int, string> stageNameDict = new Dictionary<int, string>()
    {
        {101, "Stage1-1"},
        {102, "Stage1-2"},
        {103, "Stage1-3"},
        {104, "Stage1-4"},
        {105, "Stage1-5"},
        {106, "Stage1-6"},
        {107, "Stage1-7"},
        {108, "Stage1-8"},
        {109, "Stage1-9"},
        {110, "Stage1-10"}
    };

    private void Start()
    {
        stageNameText.text = stageNameDict[ProjectController.projectController.stageNumber];
        addAttackPowerText.text = "加算攻撃力:" + ProjectController.projectController.clearTimes;
        retireAttention.SetActive(false);
    }

    public void OnResetButton()
    {
        AudioManager.audioManager.PlaySE(AudioManager.SE.ButtonTap);
        for(int i = 0;i < GameController.gameController.drops.Count / 2; i++)
        {
            Vector3 extraDropPosition = GameController.gameController.drops[i].transform.position;
            GameController.gameController.drops[i].transform.position = GameController.gameController.drops[GameController.gameController.drops.Count - 1 - i].transform.position;
            GameController.gameController.drops[GameController.gameController.drops.Count - 1 - i].transform.position = extraDropPosition;
        }
    }

    public void OnMenuButton()
    {
        AudioManager.audioManager.PlaySE(AudioManager.SE.ButtonTap);
        menuButtonPushCount++;
        switch(menuButtonPushCount % 2)
        {
            case 0:
                OnBackButton();
                break;
            case 1:
                GameController.gameController.isOperateDrops = false;
                menuCanvas.SetActive(true);
                break;
        }
    }

    public void OnBackButton()
    {
        AudioManager.audioManager.PlaySE(AudioManager.SE.Back);
        menuButtonPushCount = 0;
        GameController.gameController.isOperateDrops = true;
        menuCanvas.SetActive(false);
    }

    public void OnRetireButton()
    {
        AudioManager.audioManager.PlaySE(AudioManager.SE.ButtonTap);
        retireAttention.SetActive(true);
    }

    public void ToHomeScene()
    {
        SceneManager.LoadScene("HomeScene");
    }

    public void OnYesButton()
    {
        AudioManager.audioManager.PlaySE(AudioManager.SE.ButtonTap);
        ToHomeScene();
    }

    public void OnNoButton()
    {
        AudioManager.audioManager.PlaySE(AudioManager.SE.Back);
        retireAttention.SetActive(false);
    }
}
