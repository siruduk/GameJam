using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public Transform SpawnPoint;
    // Start is called before the first frame update

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            // 오브젝트풀 에서 빌려오기
            var bulletGo = ObjectPoolManager.instance.GetObj("Apple");

            bulletGo.transform.position = this.SpawnPoint.position;
        }
    
    }
}
