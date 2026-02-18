using UnityEngine;
using TMPro;

public class gameManagerScript : MonoBehaviour
{
    public int gameTime;
    private float timePast;
    public GameObject timerDisplay;
    public GameObject playerObject;
    public GameObject overScreen;
    private bool gameState = true;
    private int setGameTime;
    public GameObject bananaParent;
    public GameObject monkeyParent;
    public GameObject spawners;

    private int upLine = 0;
    private int downLine = 0;
    private int gameDifficulty = 0;
    public int difficultyRange;
    public float speedChange;
    public float originalSpeed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        upLine = difficultyRange;
        setGameTime = gameTime;
        playerObject.GetComponent<playerControl>().gameState = gameState;
        string seconds = (gameTime%60).ToString("D2");
        timerDisplay.GetComponent<TMP_Text>().text = gameTime/60 + ":" + seconds;
    }

    // Update is called once per frame
    void Update()
    {
        int playScore = playerObject.GetComponent<playerControl>().GetScore();
        timePast += Time.deltaTime;
        if(timePast >= 1 && gameState)
        {
            timePast = 0;
            gameTime -= 1;
            string seconds = (gameTime%60).ToString("D2");
            timerDisplay.GetComponent<TMP_Text>().text = gameTime/60 + ":" + seconds;
            //timerDisplay.GetComponent<TMP_Text>().text = gameTime/60 + ":" + gameTime%60;
        }

        if(gameTime <= 0&& gameState)
        {
            GameOver(playScore);
        }

        if (Input.GetKey("r"))
        {
            GameRestart();
            
        }

        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }

        if(gameDifficulty<4 && playScore >= upLine)
        {
            gameDifficulty += 1;
            upLine += difficultyRange;
            downLine += difficultyRange;
            ChangeDifficulty(speedChange);
        }
        else if(gameDifficulty>0 && playScore < downLine)
        {
            gameDifficulty -= 1;
            upLine -= difficultyRange;
            downLine -= difficultyRange;
            ChangeDifficulty(-speedChange);
        }
        
    }

    void GameRestart()
    {
        gameTime = setGameTime;
        overScreen.SetActive(false);
        gameState = true;
        playerObject.GetComponent<playerControl>().PlayerReset();
        timePast = 0;
        string seconds = (gameTime%60).ToString("D2");
        timerDisplay.GetComponent<TMP_Text>().text = gameTime/60 + ":" + seconds;

        foreach(Transform child in bananaParent.transform){
            Destroy(child.gameObject);
        }

        foreach(Transform child in monkeyParent.transform){
            Destroy(child.gameObject);
        }

        foreach(Transform child in spawners.transform){
            child.gameObject.GetComponent<spawnerScript>().gameState = true;
        }

        gameDifficulty = 0;
        upLine = difficultyRange;
        downLine = 0;
        ChangeDifficulty(0f);
        bananaParent.GetComponent<parentScript>().fallSpeed = originalSpeed;
        monkeyParent.GetComponent<parentScript>().fallSpeed = originalSpeed;

    }

    void GameOver(int playScore)
    {
        gameState = false;
        playerObject.GetComponent<playerControl>().gameState = gameState;
        overScreen.SetActive(true);
        overScreen.transform.GetChild(1).GetComponent<TMP_Text>().text = "Final Score: "+ playScore;

        foreach(Transform child in spawners.transform){
            child.gameObject.GetComponent<spawnerScript>().gameState = false;
        }

        foreach(Transform child in bananaParent.transform){
            child.gameObject.GetComponent<bananaMove>().bananaSpeed = 0;
        }

        foreach(Transform child in monkeyParent.transform){
            child.gameObject.GetComponent<monkeyMove>().monkeySpeed = 0;
        }
    }

    void ChangeDifficulty(float newSpeed)
    {
        foreach(Transform child in spawners.transform){
            child.gameObject.GetComponent<spawnerScript>().bananaLine = gameDifficulty;
        }
        bananaParent.GetComponent<parentScript>().fallSpeed += newSpeed;
        monkeyParent.GetComponent<parentScript>().fallSpeed += newSpeed;
        foreach(Transform child in bananaParent.transform){
            child.gameObject.GetComponent<bananaMove>().bananaSpeed += newSpeed;
        }

        foreach(Transform child in monkeyParent.transform){
            child.gameObject.GetComponent<monkeyMove>().monkeySpeed += newSpeed;
        }
    }
}
