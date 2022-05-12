using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadePanelController : MonoBehaviour
{
    [SerializeField] Image fadePanel;

    float alfa = 1;

    public static FadePanelController fadePanelController;
    private void Awake()
    {
        fadePanelController = this;
    }

    public IEnumerator FadeIn()
    {
        while(alfa > 0f)
        {
            alfa -= 0.01f;
            fadePanel.color = new Color(0, 0, 0, alfa);
            Debug.Log(fadePanel.color);
            yield return null;
        }
    }

    public IEnumerator FadeOut()
    {
        while (alfa < 1f)
        {
            alfa += 0.01f;
            fadePanel.color = new Color(0, 0, 0, alfa);
            Debug.Log(fadePanel.color);
            yield return null;
        }
        StageButtonController.stageButtonController.ToGameScene();
    }
}
