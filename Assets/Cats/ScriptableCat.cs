using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ScriptableCat : ScriptableObject
{
    public int TimeIn;
    public int TimeOut;

    public ScriptableCat(int timeIn, int timeOut)
    {
        this.TimeIn = timeIn;
        this.TimeOut = timeOut;
    }
}
