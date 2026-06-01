using UnityEngine;
using System.Collections;
using System.Collections.Generic;



public class Chest : MonoBehaviour, IInteractable
{
    [SerializeField] private string prompt;
    public  string InteractionPrompt { get => prompt; }
    public bool Interact(Interactable interactable)
    {
        
        return true;
    }
}
