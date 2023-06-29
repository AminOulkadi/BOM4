using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oxygenTank : MonoBehaviour
{
    public oxygen Oxygen;
    public GameObject Pipes;
    public GameObject Pickup;
    public GameObject Error;

    public virtual void Interact()
    {
        if (!Pipes.GetComponent<Pipe>().boolList.Contains(true))
        {
            Oxygen.oxygenLevel = Mathf.Min(Oxygen.oxygenLevel + 10, 30);
            Pickup.GetComponent<AudioSource>().Play();
        }
        else
        {
            Debug.Log("A Pipe Is Broken!");
            Error.GetComponent<AudioSource>().Play();
        }
    }
}
