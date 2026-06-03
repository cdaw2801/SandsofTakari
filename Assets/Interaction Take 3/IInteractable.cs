using UnityEngine;

public interface IInteractable
{
    //gets the prompt from Interactable
    public string InteractionPrompt { get; }
    //takes in the interaction from the interactable script
    public bool Interact(Interactable interactable);
}
