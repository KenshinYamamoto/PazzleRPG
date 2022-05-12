using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HomeUIController : MonoBehaviour
{
    [SerializeField] Text clearCounterText;
    [SerializeField] GameObject[] homeSceneButtons;
    [SerializeField] GameObject stage1ScrollView;

   void Start()
    {
        ShowClearCounterText();
        StartCoroutine(FadePanelController.fadePanelController.FadeIn());
    }

    void ShowClearCounterText()
    {
        clearCounterText.text = "ÉNÉäÉAâÒêî:" + ProjectController.projectController.clearTimes;
    }

    public void OnStageSelectButton()
    {
        ShowButtons(false);
        ShowStage1ScrollView(true);
    }

    public void OnOptionButton()
    {
        ShowButtons(false);
    }

    public void OnExitGameButton()
    {

    }

    public void OnBackButton()
    {
        ShowStage1ScrollView(false);
        ShowButtons(true);
    }

    void ShowButtons(bool show)
    {
        for(int i = 0;i < homeSceneButtons.Length; i++)
        {
            homeSceneButtons[i].SetActive(show);
        }
    }

    void ShowStage1ScrollView(bool show)
    {
        stage1ScrollView.SetActive(show);
    }
}
