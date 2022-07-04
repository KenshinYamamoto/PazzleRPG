using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HomeUIController : MonoBehaviour
{
    [SerializeField] Text playername;
    [SerializeField] Text clearCounterText;
    [SerializeField] GameObject optionSceneCanvas;
    [SerializeField] Toggle muteBGMYesToggle;
    [SerializeField] Toggle muteSEYesToggle;
    [SerializeField] GameObject stageSelectButton;
    [SerializeField] GameObject exitGameButton;
    [SerializeField] GameObject stage1Button;
    [SerializeField] GameObject backButton;
    [SerializeField] GameObject playerNameButton;
    [SerializeField] GameObject stage1ScrollView;
    [SerializeField] GameObject playerNameChangeScene;

    [SerializeField] GameObject playerNameInputField;

    [SerializeField] GameObject exitGameAttention;

    int muteBGM; // BGMをミュートする(0なら再生、1なら停止)
    int muteSE; // SEをミュートする(0なら再生、1なら停止)

    public static HomeUIController homeUIController;
    private void Awake() {
        homeUIController = this;
    }

   void Start()
    {
        AudioManager.audioManager.PlayBGM(AudioManager.BGM.Title);
        ShowClearCounterText();
        ShowPlayerNameText();
        StartCoroutine(FadePanelController.fadePanelController.FadeIn());
        muteBGM = PlayerPrefs.GetInt("MuteBGM");
        muteSE = PlayerPrefs.GetInt("MuteSE");

        switch(muteBGM){
            case 0: muteBGMYesToggle.isOn = false; break;
            case 1: muteBGMYesToggle.isOn = true; break;
        }

        switch(muteSE){
            case 0: muteSEYesToggle.isOn = false; break;
            case 1: muteSEYesToggle.isOn = true; break;
        }
    }

    void ShowClearCounterText()
    {
        clearCounterText.text = "クリア回数:" + PlayerPrefs.GetInt("ClearTimes");
    }

    void ShowPlayerNameText()
    {
        playername.text = "Name:" + PlayerPrefs.GetString("PlayerName");
    }

    public void OnStageSelectButton()
    {
        playerNameButton.SetActive(false);
        backButton.SetActive(true);
        stage1Button.SetActive(true);
        stageSelectButton.SetActive(false);
        exitGameButton.SetActive(false);
        AudioManager.audioManager.PlaySE(AudioManager.SE.ButtonTap);
    }

    /*public void OnOptionButton()
    {        
        optionSceneCanvas.SetActive(true);
        AudioManager.audioManager.PlaySE(AudioManager.SE.ButtonTap);
    }*/

    public void OnBackButton(){
        if(stage1Button.activeSelf){
            AudioManager.audioManager.PlaySE(AudioManager.SE.Back);
            backButton.SetActive(false);
            stage1Button.SetActive(false);
            stageSelectButton.SetActive(true);
            exitGameButton.SetActive(true);
            playerNameButton.SetActive(true);
        }
        else if(stage1ScrollView.activeSelf){
            AudioManager.audioManager.PlaySE(AudioManager.SE.Back);
            stage1ScrollView.SetActive(false);
            stage1Button.SetActive(true);
        }
        else if(exitGameAttention.activeSelf){
            cancelButton();
        }
        else if(playerNameInputField.activeSelf){
            AudioManager.audioManager.PlaySE(AudioManager.SE.Back);
            backButton.SetActive(false);
            playerNameChangeScene.SetActive(false);
            stageSelectButton.SetActive(true);
            exitGameButton.SetActive(true);
            playerNameButton.SetActive(true);
        }
    }

    public void OnExitGameButton()
    {
        AudioManager.audioManager.PlaySE(AudioManager.SE.ButtonTap);
        playerNameButton.SetActive(false);
        stageSelectButton.SetActive(false);
        exitGameButton.SetActive(false);
        backButton.SetActive(true);
        exitGameAttention.SetActive(true);
    }

    /*public void OptionToTitleBackButton()
    {
        optionSceneCanvas.SetActive(false);

        if(muteBGMYesToggle.isOn){
            PlayerPrefs.SetInt("MuteBGM", 1);
        }
        else{
            PlayerPrefs.SetInt("MuteBGM", 0);
        }

        if(muteSEYesToggle.isOn){
            PlayerPrefs.SetInt("MuteSE", 1);
        }
        else{
            PlayerPrefs.SetInt("MuteSE", 0);
        }
    }*/

    public bool MuteBGMFlag(){
        return muteBGMYesToggle.isOn;
    }

    public bool MuteSEFlag(){
        return muteSEYesToggle.isOn;
    }

    public void OnStage1Button(){
        AudioManager.audioManager.PlaySE(AudioManager.SE.ButtonTap);
        stage1Button.SetActive(false);
        stage1ScrollView.SetActive(true);
    }

    public void cancelButton(){
        AudioManager.audioManager.PlaySE(AudioManager.SE.Back);
        backButton.SetActive(false);
        exitGameAttention.SetActive(false);
        stageSelectButton.SetActive(true);
        exitGameButton.SetActive(true);
        playerNameButton.SetActive(true);
    }

    public void OnPlayerNameChange(){
        AudioManager.audioManager.PlaySE(AudioManager.SE.ButtonTap);
        backButton.SetActive(true);
        playerNameChangeScene.SetActive(true);
        playerNameButton.SetActive(false);
        stageSelectButton.SetActive(false);
        exitGameButton.SetActive(false);
    }

    public void InputPlayerName(){
        playername.text = playerNameInputField.GetComponent<InputField>().text;
        PlayerPrefs.SetString("PlayerName",playername.text);
        ShowPlayerNameText();
    }

    public void ExitGameYesButton(){
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
