using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerupEffect : ScriptableObject
{
    [field: SerializeField] public float powerUpTime { get; private set; }
    public abstract void Apply(GameObject target);  
}
