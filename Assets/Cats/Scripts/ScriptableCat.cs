using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[CreateAssetMenu]
public class ScriptableCat : ScriptableObject
{
    public float timeIn;
    public float timeOut;
    public AudioClip catSound1;
    public AudioClip catSound2;
    public AudioClip catSound3;
    public ScriptableCat(int timeIn, int timeOut, AudioClip catSound1, AudioClip catSound2, AudioClip catSound3)
    {
        this.timeIn = timeIn;
        this.timeIn = timeOut;
        this.catSound1 = catSound1;
        this.catSound2 = catSound2;
        this.catSound3 = catSound3;
    }
}
