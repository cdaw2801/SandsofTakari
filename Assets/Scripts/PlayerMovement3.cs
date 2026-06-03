using UnityEngine;

public class PlayerMovement3 : MonoBehaviour
{
    public float senseX;
    public float senseY;

    public Transform orientation;

    float xRotation;
    float yRotation;

    private GameManager gameManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = GameObject.Find("Game manager").GetComponent<GameManager>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(gameManager.isGameActive == true)
        {
            

            // get mouse input
            float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * senseX;
            float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * senseY;
            //the rotation of the camera from the rotation of the mouse
            yRotation += mouseX;
            xRotation -= mouseY;
            //sets how far you can look up or down
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            // rotate camera and orientation
            transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
            orientation.rotation = Quaternion.Euler(0, yRotation, 0);
        }
        
    }
}
