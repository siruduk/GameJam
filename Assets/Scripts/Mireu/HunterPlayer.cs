using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HunterPlayer : PlayerMovement
{
    Rigidbody CharRigidbody;
    private bool CanJump = true;
    public float jumpForce = 5f;
    [SerializeField]
    GameObject Player;
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
        HandleJump();
    }

    void HandleJump()
    {
        if (Input.GetKeyUp(KeyCode.Space) && CanJump)
        {
            CharRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            CanJump = false;
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

        void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MemoryTrg"))
        {
            Player.SetActive(true);
            gameObject.SetActive(false);
        }

        if (other.CompareTag("EndCutTrg"))
        {
            other.GetComponent<CutSceneController>().PlayCutScene();
        }
        if (other.CompareTag("CutTrg"))
        {
            other.GetComponent<CutSceneController>().PlayCutScene();
        }
    }
    private void OnEnable()
    {
        base.OnEnable();
        rotWeight = 90;
    }
}
