using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour
{
    public float fadeRate;

    private Image fadePanel;
    private Color currentColor = Color.black;
        
    void Start() {
        fadePanel = GetComponent<Image>();
    }

    void Update(){
    	if(Time.timeSinceLevelLoad < fadeRate){
    	// Fade in action initiater
    		float alphaChange = Time.deltaTime / fadeRate;
    		currentColor.a -= alphaChange;
			fadePanel.color = currentColor;
    	}
    	else{
    		gameObject.SetActive(false);
    	}
    }
}