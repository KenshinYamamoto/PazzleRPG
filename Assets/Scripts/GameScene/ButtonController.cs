using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    [SerializeField] GameObject menuCanvas;
    


    public void OnResetButton()
    {
        for(int i = 0;i < GameController.gameController.drops.Count / 2; i++)
        {
            Vector3 extraDropPosition = GameController.gameController.drops[i].transform.position;
            GameController.gameController.drops[i].transform.position = GameController.gameController.drops[GameController.gameController.drops.Count - 1 - i].transform.position;
            GameController.gameController.drops[GameController.gameController.drops.Count - 1 - i].transform.position = extraDropPosition;
        }
    }

    public void OnMenuButton()
    {
        GameController.gameController.isOperateDrops = false;
        menuCanvas.SetActive(true);
    }

    public void OnBackButton()
    {
        GameController.gameController.isOperateDrops = true;
        menuCanvas.SetActive(false);
    }

    public void ToHomeScene()
    {
        SceneManager.LoadScene("HomeScene");
    }
}
