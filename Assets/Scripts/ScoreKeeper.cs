using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour {
    public static int score = 0;

    private Text pointsText;
    private LevelManager levelManager;
    
    void Start () {
        pointsText = GetComponent<Text>();
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        pointsText.text = score.ToString();
    }

    public void Score(int points){
        score += points;
        pointsText.text = score.ToString();	
	}
    
    public static void Reset(){
        //when called resets score to zero
        score = 0;
    }

    public void Achievement(){
        if (score == 1500)
            levelManager.LoadNextLevel();
        if (score >= 3000 && score <= 3050)
            levelManager.LoadNextLevel();
        if (score >= 5000)
            levelManager.LoadLevel("Win");
    }
}
