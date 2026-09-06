using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TrapActive : MonoBehaviour
{
    public Animator anim;
    public float power;

    private void OnTriggerEnter(Collider other)
    {       
        if (other.gameObject.CompareTag("Player"))
        {
            anim.SetFloat("speed", 1.0f);
            GameObject player = other.gameObject;

            player.GetComponent<Rigidbody>().AddForce(Vector3.up * power, ForceMode.Impulse);
        }
    }
}
