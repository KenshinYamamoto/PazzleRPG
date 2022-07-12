using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("PlayBGM", 0.1f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            SceneManager.LoadScene("HomeScene");
        }
    }

    void PlayBGM()
    {
        AudioManager.audioManager.PlayBGM(AudioManager.BGM.Title);
    }
}
