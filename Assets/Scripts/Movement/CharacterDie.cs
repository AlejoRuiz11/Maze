using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDie : MonoBehaviour
{
    private void FixedUpdate()
    {
        if (gameObject.transform.position.y < -5f)
        {
            FindObjectOfType<GameOverManager>().TriggerDefeat();
        }
    }
}
