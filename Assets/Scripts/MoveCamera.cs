using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public Transform cameraPosition;
    private GameManager gameManagerScript;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManagerScript = GameObject.Find("Game manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {

       if(gameManagerScript.isGameActive == true)
        {
            transform.position = cameraPosition.position;
        }
            
        
        
    }
}
