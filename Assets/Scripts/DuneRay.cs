using UnityEngine;

public class DuneRay : MonoBehaviour
{

    public GameManager gameManagerScript;
    public float riseSpeed;
    public float fallSpeed;
    public bool moveUp;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManagerScript.isGameActive)
        {
            // moves the ray up when the 
            if (gameManagerScript.timeLeft <= 3)
            {
                if (transform.position.y >= -150 && moveUp)
                {
                    transform.Translate(Vector3.up * Time.deltaTime * riseSpeed);
                }
                if (!moveUp)
                {
                    transform.Translate(Vector3.down * Time.deltaTime * fallSpeed);

                }

                if (transform.position.y <= -150)
                {
                    Destroy(gameObject);
                }

                if (transform.position.y >= 1)
                {
                    moveUp = false;
                }
            }
        }
        
    }
}
