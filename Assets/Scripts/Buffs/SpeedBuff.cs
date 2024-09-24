using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Buffs/Speed")]

public class SpeedBuff : PowerupEffect
{
    public float speed;
    public override void Apply(GameObject target)
    {
        if (target.GetComponent<CharacterRun>().speed < speed)
        {
            target.GetComponent<CharacterRun>().speed = speed;
        }
    }

}
