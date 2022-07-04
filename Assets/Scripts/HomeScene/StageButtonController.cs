using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageButtonController : MonoBehaviour
{
    public int buttonID;

    public static StageButtonController stageButtonController;
    private void Awake()
    {
        stageButtonController = this;
    }

    public void OnStageButton()
    {
        AudioManager.audioManager.PlaySE(AudioManager.SE.ButtonTap);
        ProjectController.projectController.stageNumber = buttonID;
        StartCoroutine(FadePanelController.fadePanelController.FadeOut());
    }

    public void ToGameScene()
    {
        SceneManager.LoadScene("GameScene");
    }
}
