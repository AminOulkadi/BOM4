using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenPipe : MonoBehaviour
{
    public GameObject Pipes;
    public int whatpipe;
    public GameObject fixsound;

    public virtual void Interact()
    {
        Destroy(gameObject.GetComponent<InteractableObject>());
        GetComponentInChildren<ParticleSystem>().Stop();
        fixsound.GetComponent<AudioSource>().Play();
        Pipes.GetComponent<Pipe>().boolList[whatpipe] = false;

    }
}
