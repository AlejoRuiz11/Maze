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
        MonoBehaviour targetMonoBehaviour = target.GetComponent<MonoBehaviour>();
        if (targetMonoBehaviour != null)
        {
            targetMonoBehaviour.StartCoroutine(ApplySpeedBoost(target));
        }
    }

    private IEnumerator ApplySpeedBoost(GameObject target)
    {
        CharacterRun characterRun = target.GetComponent<CharacterRun>();

        if (characterRun != null)
        {
            float originalSpeed = characterRun.speed; 

            characterRun.speed = speed;

            yield return new WaitForSeconds(powerUpTime);

            characterRun.speed = originalSpeed;
        }
    }
}
