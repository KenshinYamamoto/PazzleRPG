using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerFigureGenerator : MonoBehaviour
{
    public static PlayerFigureGenerator playerFigureGenerator;

    [SerializeField] GameObject playerFigureText;
    [SerializeField] GameObject gameCanvas;

    private void Awake()
    {
        playerFigureGenerator = this;
    }

    public void GeneratePlayerFigure(int damage)
    {
        playerFigureText.GetComponent<Text>().text = "-" + damage.ToString("N0");
        GameObject figure = Instantiate(playerFigureText, transform.position, Quaternion.identity);
        figure.transform.parent = gameCanvas.transform;
    }
}
