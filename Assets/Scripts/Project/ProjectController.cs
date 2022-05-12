using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectController : MonoBehaviour
{
    public int clearTimes;
    public int stageNumber;

    public static ProjectController projectController;
    private void Awake()
    {
        if(projectController == null)
        {
            projectController = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        clearTimes = 1;
    }

    public void AddClearTimes()
    {
        clearTimes++;
    }
}
