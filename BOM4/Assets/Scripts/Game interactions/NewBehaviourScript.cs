using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public oxygen Oxygen;
    public virtual void Interact()
    {
        Oxygen.oxygenLevel = Oxygen.oxygenLevel + 10;
    }
}
