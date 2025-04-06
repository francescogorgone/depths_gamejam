using UnityEngine;
using UnityEngine.InputSystem;
public class xcv : MonoBehaviour
{

    private Animator mAnimator;
    private bool isSprinting;
    public bool isHappy;

    void Start()
    {
        mAnimator = GetComponent<Animator>();
            mAnimator.SetBool("Victory", isHappy);
        
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

