using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;



public class FoxPlayer : PlayerMovement
{
    public Animator animator;
    protected override void Start()
    {
        base.Start();
        animator = this.transform.GetChild(1).GetComponent<Animator>();
    }

    void OnEnable()
    {      
        GameManager.GameManagerInstance.Stage=3;
    }
}
