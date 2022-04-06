using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HomeButtonController : MonoBehaviour
{
    public string gameScene = "gameScene";
    public string stageNumber;

    

    public void ToGameScene()
    {
        Debug.Log(stageNumber);
        //SceneManager.LoadScene(gameScene);
    }
}
