using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenPipe : MonoBehaviour
{
    public GameObject Pipes;
    public int whatpipe;

    public virtual void Interact()
    {
        Destroy(gameObject.GetComponent<InteractableObject>());
        GetComponentInChildren<ParticleSystem>().Stop();

        Pipes.GetComponent<Pipe>().boolList[whatpipe] = false;

    }
}
