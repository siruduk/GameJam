using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenPlayer : PlayerMovement
{
    Rigidbody CharRigidbody;
    private bool isGrounded = false;
    private bool CanJump = true;
    public float jumpForce = 5f;

    public Animator animator;
    protected override void Start()
    {
        base.Start();
        CharRigidbody = GetComponent<Rigidbody>();
        animator =  this.transform.GetChild(1).GetComponent<Animator>();
    }


    protected override void Update()
    {
        base.Update();
        if (Input.GetKeyUp(KeyCode.Space) && CanJump)
        {
            CharRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            CanJump = false;
        }
        if (Hp<=0)
        {
            GetComponent<CutSceneController>().PlayCutScene();
            speed = 0;
        }
    }

 

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            CanJump = true;
            animator.SetBool("IsJump", false);
        }
    }
    void OnEnable()
    {
        ;
    }
}
