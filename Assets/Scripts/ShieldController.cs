using UnityEngine;
using UnityEngine.UI;

public class ShieldController : MonoBehaviour {
    private int shield;
    private Text shieldText;
    private LevelManager levelManager;

    void Start () {
        shieldText = GetComponent<Text>();
        ShieldReset();
        levelManager = GameObject.FindObjectOfType<LevelManager>();
    }
	
    public void ShieldLevel(int percent){
        shield = percent;
        shieldText.text = shield.ToString();
    }

    public void ShieldReset()
    {
        //when called resets shield to zero
        shield = 500;
        shieldText.text = shield.ToString();
    }

    public void GameOver(){
        levelManager.LoadLevel("Lose");
        ShieldReset();
    }
}
