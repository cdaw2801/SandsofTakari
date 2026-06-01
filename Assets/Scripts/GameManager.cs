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
    public bool moveUp = true;

    bool hasShuttleDissappeared = false;
    
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
            timeLeft -= Time.deltaTime;
           
            if (timeLeft <= 0 && hasShuttleDissappeared == false)
            {
               
               Destroy(GameObject.Find("Shuttle"));
                timeLeft = 0;
                hasShuttleDissappeared = true; 
                if (GameObject.Find("Player").transform.position.x < 45 && hasShuttleDissappeared == true)
                {
                    GameOver();
                }
            }

            
            
            
        }
       
    }

    public void GameOver()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        deathRestartButton.gameObject.SetActive(true);
        gameOverText.gameObject.SetActive(true);
        waterBar.gameObject.SetActive(false);
        isGameActive = false;
        
    }
    public void GameWon()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
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
        isGameActive = true;
        waterBar.gameObject.SetActive(true);
        timeLeft = 60f;
        titleScreen.gameObject.SetActive(false);
        
        if (isGameActive)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

}
