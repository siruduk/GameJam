using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearRunObjectBase : ObjectBase
{
    public bool Turn = false;
    GameObject bear;
    PlayerMovement pm;
    // Start is called before the first frame update
    void Start()
    {
        bear = GameObject.Find("PlayerBaseBear");
        pm=bear.GetComponent<BearPlayer>();
    }

    // Update is called once per frame
    public Vector3 rotationSpeed = new Vector3(-130, 100,230); // 회전 속도 설정

    // Update is called once per frame
    void Update()
    {
        if (Turn)
            transform.Rotate(rotationSpeed * Time.deltaTime);
        if(pm.Hp<=0)
        {
            ReleaseObject();
        }
    }


        void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("End"))
        {
            ReleaseObject();
        }
    }

    public void SetRelease()
    {
        StartCoroutine(StartRelease());
    }

    IEnumerator StartRelease()
    {
        yield return new WaitForSeconds(0.3f);
        ReleaseObject();
    }
}
