using UnityEngine;

public class LockedDoor : MonoBehaviour, IInteractable
{
    [SerializeField] private string prompt;
    public string InteractionPrompt { get => prompt; }
    public bool Interact(Interactable interactable)
    {
        Debug.Log("It's a door");
        return true;
    }
}
