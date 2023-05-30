using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public string scriptname = "";
    private MonoBehaviour interactableObject;

    private void Start()
    {

        interactableObject = GetComponent(scriptname) as MonoBehaviour;

        if (interactableObject == null)
        {
            Debug.LogError("Failed" + scriptname);
        }
    }

    public virtual void Interact()
    {
        Debug.Log("Interacting with " + scriptname);


        if (interactableObject != null)
        {
            interactableObject.Invoke("Interact", 0f);
        }
        else
        {
            Debug.LogError("interactableObject is null");
        }
    }
}





