using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public string scriptname = "";
    private MonoBehaviour interactableObject;

    private void Start()
    {
        // Find the component by its script name
        interactableObject = GetComponent(scriptname) as MonoBehaviour;

        // Check if the component is found
        if (interactableObject == null)
        {
            Debug.LogError("Failed to find component with name: " + scriptname);
        }
    }

    public virtual void Interact()
    {
        Debug.Log("Interacting with " + scriptname);

        // Check if interactableObject is null before calling its Interact method
        if (interactableObject != null)
        {
            interactableObject.Invoke("Interact", 0f);
        }
        else
        {
            Debug.LogError("interactableObject is null. Make sure the component is found and attached to the GameObject.");
        }
    }
}





