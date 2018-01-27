using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour {

    public AudioClip[] levelMusicChangeArray;

    private AudioSource audioSource;

    void Awake() {
        DontDestroyOnLoad(gameObject);
        Debug.Log("Don't destroy on load: " + name);
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    public void SetVolume(float currentVolume)
    {
    	audioSource.volume = currentVolume;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
    {
        AudioClip thisLevelMusic = levelMusicChangeArray[scene.buildIndex];
        Debug.Log("Playing clip: " + thisLevelMusic);
        
        if (thisLevelMusic){
            audioSource.clip = thisLevelMusic;
            audioSource.loop = true;
            audioSource.Play();
            if (scene.buildIndex >= 4){ //If level element is 4 or 5, do not loop sound effects
                audioSource.loop = false;
            }
        }
    }
}
