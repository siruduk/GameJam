using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StageEndTrig : MonoBehaviour
{
    public int stageNum;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if(stageNum == 1)
            {
                //컷신 + 다음 스테이지로
            }
        }
    }
}
