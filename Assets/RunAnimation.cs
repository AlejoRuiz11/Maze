using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunAnimation : StateMachineBehaviour
{
    [SerializeField] private GameObject particleSystem;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        particleSystem.SetActive(true);
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        particleSystem.SetActive(false);
    }
}
