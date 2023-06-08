using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public oxygen Oxygen;
    public virtual void Interact()
    {
        Oxygen.oxygenLevel = Mathf.Min(Oxygen.oxygenLevel + 10,30);
    }
}
