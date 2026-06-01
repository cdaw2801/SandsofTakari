using Unity.VisualScripting;
using UnityEngine;

public class Door : MonoBehaviour
{
    
    public GameObject teleportPoint;
    
        
   
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
        
        if (other.gameObject.name == ("PlayerObj"))
        {
            other.transform.parent.transform.position = teleportPoint.transform.position;
             
        }
        else if(other.gameObject.name == ("PlayerObj"))
        {
            other.transform.parent.transform.position = teleportPoint.transform.position;
            
        }

        if (other.gameObject.name == ("PlayerObj"))
        {
            
            other.transform.parent.transform.position = teleportPoint.transform.position;
        }
        else if (other.gameObject.name == ("PlayerObj"))
        {
            other.transform.parent.transform.position = teleportPoint.transform.position;
            
        }
        
        if (other.gameObject.name == ("PlayerObj"))
        {
            other.transform.parent.transform.position = teleportPoint.transform.position;
            
        }
        else if (other.gameObject.name == ("PlayerObj"))
        {
            other.transform.parent.position = teleportPoint.transform.position;
            
            
        }

        
    }
}
