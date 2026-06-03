using UnityEngine;
using UnityEngine.InputSystem;

public class Interactable : MonoBehaviour
{
    // interaction point and its size
    [SerializeField] private Transform interactionPoint;
    [SerializeField] private float interactionPointRadius = 0.5f;
    //gives the layer for interaction
    [SerializeField] private LayerMask interactableMask;
    private readonly Collider[] colliders = new Collider[3];
    public int numFound;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //whether or not there is anything to interact with in the interaction point
        numFound = Physics.OverlapSphereNonAlloc(interactionPoint.position, interactionPointRadius, colliders, interactableMask);
        //allows you to interact with specific things
        if(numFound > 0)
        {
            var interactable = colliders[0].GetComponent<IInteractable>();
            if(interactable != null && Keyboard.current.eKey.wasPressedThisFrame)
            {
                interactable.Interact(this);
            }
        }
    }

    private void OnDrawGizmos()
    {
        //creates a visible field for the interaction point
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(interactionPoint.position, interactionPointRadius);
    }


}
