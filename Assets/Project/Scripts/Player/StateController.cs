using UnityEngine;

public class StateController : MonoBehaviour
{
    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    
    public void SetState(string stateName)
    {
        animator.SetBool("isWalking", false);
    }
}
