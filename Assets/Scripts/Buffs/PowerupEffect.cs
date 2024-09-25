using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerupEffect : ScriptableObject
{
    [field: SerializeField] public static float powerUpTime = 15f; 
    public abstract void Apply(GameObject target);  
}
    