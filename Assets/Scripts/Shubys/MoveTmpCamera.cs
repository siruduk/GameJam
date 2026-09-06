using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MoveTmpCamera : MonoBehaviour
{
    public GameObject player;
    public float data;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player.transform.GetChild(0).position += new Vector3(0, data, 0);            
        }
    }
}
