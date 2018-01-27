using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour
{
    static MusicPlayer instance = null;

    public AudioClip introClip;
    public AudioClip gameClip;
    public AudioClip game2Clip;
    public AudioClip game3Clip;
    public AudioClip winClip;
    public AudioClip loseClip;

    private AudioSource music;

    void Awake(){
        if (instance != null && instance != this){
            Destroy(gameObject);
            print("Duplicate music player self-destructing!");
        }
        else{
            instance = this;
            GameObject.DontDestroyOnLoad(gameObject);
            music = GetComponent<AudioSource>();
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode){
        if (scene.buildIndex == 0){
            music.clip = introClip;
        }
        if (scene.buildIndex == 1)
        {
            music.clip = gameClip;
        }
        if (scene.buildIndex == 2)
        {
            music.clip = game2Clip;
        }
        if (scene.buildIndex == 3)
        {
            music.clip = game3Clip;
        }
        if (scene.buildIndex == 4)
        {
            music.clip = winClip;
        }
        if (scene.buildIndex == 5)
        {
            music.clip = loseClip;
        }
        music.loop = true;
        music.Play();
    }
}