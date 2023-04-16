using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deathanim : StateMachineBehaviour
{
    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        foreach (Behaviour childCompnent in GameObject.FindGameObjectWithTag("Player").GetComponentsInChildren<Behaviour>())
            {
                childCompnent.enabled = false;
            }

    }

    //OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

    //OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.Log("Monkey D. Nigga");
        GameObject[] allObjects = UnityEngine.GameObject.FindObjectsOfType<GameObject>() ;
            foreach(GameObject go in allObjects)
                if (go.activeInHierarchy && go.layer != 5 && go.layer != 12 )
                        go.SetActive(false);
    }

}
