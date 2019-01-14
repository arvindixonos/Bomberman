using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blastable : MonoBehaviour
{
    protected bool blasted = false;

    public bool isBlasted { get { return blasted; } }

    public virtual void BlastReceived()
    {
      
    }

    public virtual  bool    isBlastable()
    {
        return true;
    }
}