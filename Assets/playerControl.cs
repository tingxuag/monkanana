using UnityEngine;
using TMPro;

public class playerControl : MonoBehaviour
{
    public float playerSpeed;
    private int playerScore = 0;
    public GameObject scoreText;
    public bool gameState;
    private Vector3 setPos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        setPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(gameState){
        if (Input.GetKey("a")&&transform.position.x>-8)
        {
            transform.Translate(Vector3.left*playerSpeed*Time.deltaTime);
            
        }

        if (Input.GetKey("d")&&transform.position.x<8)
        {
            transform.Translate(Vector3.right*playerSpeed*Time.deltaTime);
            
        }
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(gameState){
        if(col.gameObject.tag == "banana")
        {
            playerScore += 1;
        }
        else
        {
            playerScore -= 1;
        }
        
        Destroy(col.gameObject);
        scoreText.GetComponent<TMP_Text>().text = playerScore.ToString();
        }
    }

    public int GetScore()
    {
        return playerScore;
    }

    public void PlayerReset()
    {
        playerScore = 0;
        gameState = true;
        scoreText.GetComponent<TMP_Text>().text = playerScore.ToString();
        transform.position = setPos;
    }
}
