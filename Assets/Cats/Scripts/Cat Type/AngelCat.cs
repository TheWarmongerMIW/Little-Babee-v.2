using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngelCat : MonoBehaviour
{
    public ScriptableCat scriptableCat;
    public float TimeIn;
    public float TimeOut;

    public AngelCat()
    {
        this.TimeIn = scriptableCat.timeIn;
        this.TimeOut = scriptableCat.timeOut;
    }
}
