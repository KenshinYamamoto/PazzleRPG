using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FigureGenerator : MonoBehaviour
{
    public static FigureGenerator figureGenerator;
    private void Awake()
    {
        figureGenerator = this;
    }

    public GameObject enemy;
    [SerializeField] GameObject figureText;
    [SerializeField] GameObject enemyCanvas;

    public void GenerateFigure(int dropID,int damage)
    {
        switch (dropID)
        {
            case 0:
                figureText.GetComponent<Text>().color = Color.red;
                break;
            case 1:
                figureText.GetComponent<Text>().color = Color.blue;
                break;
            case 2:
                figureText.GetComponent<Text>().color = Color.green;
                break;
            case 3:
                figureText.GetComponent<Text>().color = Color.yellow;
                break;
            case 4:
                figureText.GetComponent<Text>().color = new Color(0.8156863f, 0.3098039f, 0f, 1f);
                break;
        }
        figureText.GetComponent<Text>().text = damage.ToString("N0");
        GameObject figure = Instantiate(figureText, enemy.transform.position, Quaternion.identity);
        figure.transform.parent = enemyCanvas.transform;
    }
}
