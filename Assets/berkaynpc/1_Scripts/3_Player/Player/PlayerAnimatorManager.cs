using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace project_usomk
{
    public class PlayerAnimatorManager : MonoBehaviour
    {
        public Animator animator;
        public AnimatorOverrideController animatorOverrideController;
        InputHandler inputHandler;
        PlayerManager playerManager;
        PlayerLocomotion playerLoc;
        // public bool canRotate;

        private void Awake()
        {
            playerManager = GetComponentInParent<PlayerManager>();
            animator = GetComponent<Animator>();          
            inputHandler = GetComponentInParent<InputHandler>();
            playerLoc = GetComponentInParent<PlayerLocomotion>();
        }

        private void Start()
        {
            animatorOverrideController = new AnimatorOverrideController(animator.runtimeAnimatorController);            
            animator.runtimeAnimatorController = animatorOverrideController;
        }

        public void UpdateAnimatorValues(string getString,float getValue,bool getBool)
        {
            float snappedValue;
            
            #region snappedHorizontal
            if (getValue > 0 && getValue <= 0.55f)
            {
                snappedValue = 0.5f;
            }
            else if(getValue > 0.55f)
            {
                snappedValue = 1; 
            }
            else if(getValue < 0 && getValue >= -0.55f)
            {
                snappedValue = -0.5f;
            }
            else if(getValue < -0.55f)
            {
                snappedValue = -1;
            }
            else
            {
                snappedValue = 0;
            }
            #endregion

            if(getBool)
            {
                snappedValue=getValue*2;
            }
           animator.SetFloat(getString, snappedValue, 0.1f,Time.deltaTime);
        }

        public void PlayTargetAnimation(string targetAnim, bool inAnim)
        {
            animator.applyRootMotion = inAnim;
            animator.SetBool("inAnim", inAnim);
            animator.CrossFade(targetAnim,0.15f);
        }

        public void EnableCombo() //These are added to the animation as events.
        {
            animator.SetBool("canDoCombo", true);
        }
        public void DisableCombo() //These are added to the animation as events.
        {
            animator.SetBool("canDoCombo", false);
        }

        private void OnAnimatorMove() //If this method is deleted, the animations will be broken. //DO NOT TOUCH!
        {
            if (!playerManager.inAnim || playerManager.isPushPull)
            {
                return;
            }

            Vector3 deltaPos = animator.deltaPosition;
            //deltaPos.y = 0;
            Vector3 velocity = deltaPos / Time.deltaTime;

            playerLoc.cController.Move(velocity * Time.deltaTime);
        }
    }
}