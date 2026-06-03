
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    //this is just water stuff
    public float timeLeft = 120;
    public float maxWater = 120;
    public float waterLeft;

   
    // gets the scripts necessary
    private Interactable interactableScript;
    private Chest chestScript;
    public GameManager gameManagerScript;
   
    private bool isTitleScreenActive;
    public bool isGameActive;


    public bool crate1;
    public bool crate2;
    public bool crate3;
    public bool crate4;
    
    public Camera cam;

    public WaterBarScript waterScript;

    public GameObject ziggurat;
    
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // this creates the timer level, starts it topped up, and gets some scripts
        timeLeft = 120;
        interactableScript = GameObject.Find("Camera Holder").GetComponent<Interactable>();
        chestScript = GameObject.Find("Crate #1").GetComponent<Chest>();
        waterLeft = maxWater;
        waterScript.SetMaxWaterLevel(maxWater);
        
    }

    // Update is called once per frame
    void Update()
    {
        // for raycasts
         Vector3 forward = transform.forward;

        // this is a timer
        if (gameManagerScript.isGameActive)
        {
            
            waterLeft -= Time.deltaTime;
            waterScript.SetWaterLevel(waterLeft);
            if (waterLeft < 0)
            {
                gameManagerScript.GameOver();
            }
            
        }
        // this increases the water level on the bar
        if (interactableScript.numFound > 0 && Input.GetKeyDown(KeyCode.E))
        {
            waterLeft += 60;
            if(waterLeft > 120)
            {
                waterLeft = 120;
            }
        }
            

        if (interactableScript.numFound > 0 && Input.GetKeyDown(KeyCode.E))
        {
            RaycastHit hit;
            
            // getting a raycast to get the tag of a crate
            if(Physics.Raycast(cam.transform.position, cam.transform.forward, out hit))
            {
                // these are for specific crates around the map
                Debug.Log(hit.collider.gameObject.name);
                if (hit.collider.CompareTag("Shuttle crate"))
                {
                    crate1 = true;
                    Debug.Log("Stem of Vindit acquired");
                }
                if (hit.collider.CompareTag("Abandoned settlement crate"))
                {
                    crate2 = true;
                    Debug.Log("Symbol of Vindit acquired");
                }
                if (hit.collider.CompareTag("Cactus crate"))
                {
                    Debug.Log("Base of Vindit acquired");
                    crate3 = true;
                }
                if (hit.collider.CompareTag("Cthulu crate"))
                {
                    Debug.Log("Gem of Vindit acquired");
                    crate4 = true;
                }
            }
            
        }

        // this initiates the endgame
        if(crate1 && crate2 && crate3 && crate4)
        {
            ziggurat.SetActive(true);
            
        }


    }

   


   
}
