using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcAnimation : MonoBehaviour
{
    private NpcInteraction npcInteraction;

    private const string IS_TALKING = "IsTalking";

    private Animator animator;

    private void Awake() {
        animator = GetComponent<Animator>();
        npcInteraction = GetComponent<NpcInteraction>();
    }

    void Update()
    {
        animator.SetBool(IS_TALKING, npcInteraction.IsTalking());
    }

}
