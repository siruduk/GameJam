using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class RotateTrig : MonoBehaviour
{
    public GameObject mainCamera;
    public GameObject player;

    public float rot;

    Vector3 rotation;
    bool once;
    float time;
    Quaternion quat;

    void Start()
    {
        
    }

    void Update()
    {
        /*if(once)
        {
            time += Time.deltaTime;
            
            player.transform.rotation = Quaternion.Slerp(player.transform.rotation,
                 quat * transform.rotation, Time.deltaTime * 5f);

            if (time >= 1f)
            { 
                once = false;
            }
        }*/
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player") && !once)
        {
            time = 0f;
            once = true;
            
            GameObject g = other.gameObject;

            player.GetComponent<PlayerMovement>().rotWeight += rot;
            quat = Quaternion.Euler(0, rot, 0);
            player.transform.forward = quat * player.transform.forward;
            //StartCoroutine(MoveCamera(g));

        }
    }

    IEnumerator MoveCamera(GameObject player)
    {
        /*mainCamera.GetComponent<CameraMovement>().enabled = false;
        mainCamera.transform.SetParent(player.transform, true);*/
        //player.GetComponent<PlayerMovement>().IsRotated = true;


        for (int i = 0; i < rot; i+=3)
        {
            yield return new WaitForSeconds(0.01f);
            player.GetComponent<PlayerMovement>().rotWeight += i;
            Quaternion rotation = Quaternion.Euler(0, i, 0);
            //player.transform.forward = rotation * player.transform.forward;
            player.transform.rotation = Quaternion.Lerp(player.transform.rotation,
                 rotation * transform.rotation, Time.deltaTime * 5f);
        }
        //player.GetComponent<PlayerMovement>().IsRotated = false;
        /*mainCamera.transform.SetParent(null, true);        
        mainCamera.GetComponent<CameraMovement>().enabled = true;*/
    }
}
