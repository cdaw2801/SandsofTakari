using UnityEngine;
using UnityEngine.UI;

public class ZigguratDoor : MonoBehaviour
{
    public Button restartButton;
    public GameObject victoryText;
    public GameManager gameManagerScript;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == ("PlayerObj"))
        {
            gameManagerScript.GameWon();
        }
    }
}
