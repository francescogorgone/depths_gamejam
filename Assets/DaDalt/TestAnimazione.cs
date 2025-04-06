using UnityEngine;
using UnityEngine.InputSystem;
public class TestAnimazione : MonoBehaviour
{

    private Animator mAnimator;
    private bool isSprinting;

    void Start()
    {
        mAnimator = GetComponent<Animator>();
        
    }


    public void OnMove(InputAction.CallbackContext context) {
        isSprinting = context.started || context.performed;
        mAnimator.SetBool("Running", isSprinting);
         }

    public void OnAttack(InputAction.CallbackContext context) {
        if (context.started){
        mAnimator.SetTrigger("Hit");
        }
        
    }

}

