using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource BGMAudioSource;
    [SerializeField] AudioSource SEAudioSource;

    [SerializeField] AudioClip[] BGMAudioClips;
    [SerializeField] AudioClip[] SEAudioClips;

    public enum BGM{
        Title,
        Game
    };

    public enum SE{
        ButtonTap,
        Back,
        DraggingDrops,
        CrashDrops,
        FireAttack,
        WaterAttack,
        WindAttack,
        ThunderAttack,
        SoilAttack,
        Damage,
        Clear,
        Gameover
    };

    public bool playBGM;
    public bool playSE;
    
    GameObject homeUIController;

    public static AudioManager audioManager;
    private void Awake() {
        if(audioManager == null){
            audioManager = this;
            DontDestroyOnLoad(this);
        }
        else{
            Destroy(gameObject);
        }
    }

    void Start()
    {
        playBGM = true;
        playSE = true;

    searchObject();
    }

    void Update()
    {
        if(!CheckIsExists()){
            return;
        }

        if(HomeUIController.homeUIController.MuteBGMFlag()){
            playBGM = false;
            pauseBGM();
        }
        else{
            playBGM = true;
            UnPauseBGM();
        }

        if(HomeUIController.homeUIController.MuteSEFlag()){
            playSE = false;
        }
        else{
            playSE = true;
        }
    }

    public void pauseBGM(){
        BGMAudioSource.Pause();
    }

    public void UnPauseBGM(){
        BGMAudioSource.UnPause();
    }

    public void PlayBGM(BGM bgm){
        if(!playBGM){
            return;
        }

        int index = (int)bgm;
        BGMAudioSource.clip = BGMAudioClips[index];
        BGMAudioSource.Play();
    }

    public void PlaySE(SE se){
        if(!playSE){
            return;
        }

        int index = (int)se;
        SEAudioSource.PlayOneShot(SEAudioClips[index]);
    }

    bool CheckIsExists(){
        if(homeUIController){
            return true;
        }
        else{
            return false;
        }
    }

    public void searchObject(){
        homeUIController = GameObject.Find("HomeUIController");
    }
}
