using UnityEngine;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{

    public Button startButton;
    public Button restartButton;
    public Button doneButton;
    private GameManager gameManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = GameObject.Find("Game manager").GetComponent<GameManager>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void StartGame()
    {
        gameManager.StartGame();
    }
}
