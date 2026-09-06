using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform player;
    public Vector3 posWeight;

    void Start()
    {
        
    }

    void Update()
    {
        Debug.Log("ºÎ¸ð");
    }

    private void FixedUpdate()
    {
        Vector3 targetPos = player.position + posWeight;

        transform.position = targetPos;
        //transform.position = new Vector3(0, transform.position.y, transform.position.z);


        //transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * 2f);
    }
}
