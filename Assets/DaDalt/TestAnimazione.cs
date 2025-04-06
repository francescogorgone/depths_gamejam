using UnityEngine;
using UnityEngine.InputSystem;
public class TestAnimazione : MonoBehaviour
{

    private Animator mAnimator;


    void Start()
    {
        mAnimator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if(mAnimator != null){
            if(Input.GetKeyDown(KeyCode.O)){
                    mAnimator.SetBool("Running", true);
                    }
            
            if (Input.GetKeyUp(KeyCode.O)){
                mAnimator.SetBool("Running", false);
            }

        }
    }

    public void Move(InputAction value) {
        mAnimator.SetBool("Running", true);
        }
}
