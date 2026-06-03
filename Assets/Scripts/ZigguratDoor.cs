using UnityEngine;
using UnityEngine.UI;

public class ZigguratDoor : MonoBehaviour
{
   
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
        //makes you win if you collide with it.
        if(other.gameObject.name == ("PlayerObj"))
        {
            gameManagerScript.GameWon();
        }
    }
}
