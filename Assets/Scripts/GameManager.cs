using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using TMPro;
using UnityEngine.UI;
using UnityEditor;

public class GameManager : MonoBehaviour
{

    public float timeLeft;
    
    
    private PlayerController playerControllerScript;

    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI victoryText;
    public Slider waterBar;

    public Button deathRestartButton;
    public Button doneRestartButton;
    public Button startButton;
    
    public bool isGameActive = false;
    

    // allows the shuttle to dissappear
    bool hasShuttleDissappeared = false;
    // gets necessary objects
    public GameObject Player;
    public GameObject Shuttle;
    public GameObject titleScreen;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameActive)
        {
            // brings the time down
            timeLeft -= Time.deltaTime;
           
            if (timeLeft <= 0 && hasShuttleDissappeared == false)
            {
               //removes the shuttle if the timer is done
               Destroy(GameObject.Find("Shuttle"));
                timeLeft = 0;
                hasShuttleDissappeared = true; 
                // kills you if you're too close to the shuttle
                if (GameObject.Find("Player").transform.position.x < 45 && hasShuttleDissappeared == true)
                {
                    GameOver();
                }
            }

            
            
            
        }
       
    }

    public void GameOver()
    {
        //allows you to click things
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        //activates death screen
        deathRestartButton.gameObject.SetActive(true);
        gameOverText.gameObject.SetActive(true);
        //stops everything
        waterBar.gameObject.SetActive(false);
        isGameActive = false;
        
    }
    public void GameWon()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        //activates victory screen
        doneRestartButton.gameObject.SetActive(true);
        victoryText.gameObject.SetActive(true);
        waterBar.gameObject.SetActive(false);
        isGameActive = false;
    }



    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame()
    {
        //starts the game
        isGameActive = true;
        //starts the water bar
        waterBar.gameObject.SetActive(true);
        //sets the timer to 1 minute
        timeLeft = 60f;
        titleScreen.gameObject.SetActive(false);
        // uses the mouse to look around
        if (isGameActive)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

}
