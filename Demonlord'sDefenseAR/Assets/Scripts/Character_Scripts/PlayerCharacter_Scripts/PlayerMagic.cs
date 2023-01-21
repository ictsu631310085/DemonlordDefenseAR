using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMagic : StateMachineBehaviour
{
    private PlayerCharacter _player;

    public float fireDelaySecond;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _player = animator.GetComponent<PlayerCharacter>();

        _player.Invoke("MagicAttackFire", fireDelaySecond);
        _player.animator.SetTrigger("Magic");
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("Magic", false);
        _player.input.magic = false;
    }
}
