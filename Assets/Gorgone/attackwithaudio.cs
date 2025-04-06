using UnityEngine;
using UnityEngine.InputSystem;
public class xcv : MonoBehaviour
{

    private Animator mAnimator;
    private bool isSprinting;
    public AudioSource walk_sound;
    private bool walking = false;
    public bool isHappy;

    void Start()
    {
        mAnimator = GetComponent<Animator>();
            mAnimator.SetBool("Victory", isHappy);
                walk_sound = GetComponent<AudioSource>();
    
        
    }


    public void OnMove(InputAction.CallbackContext context) {
        /*Debug.Log("move");
        walking = true;
        if(walking) {*/
    isSprinting = context.started || context.performed;
        walk_sound.Play();
        mAnimator.SetBool("Running", isSprinting);
       /* }
        else {
            walking = false;
            walk_sound.Stop();
        }*/
         }

    public void OnAttack(InputAction.CallbackContext context) {
        if (context.started){
        mAnimator.SetTrigger("Hit");
        }
        
    }

}

