using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSpawnObstacle : MonoBehaviour
{
    [SerializeField]
    int Stage;
    [SerializeField]
    int Delay;

    // Start is called before the first frame update
    void Start()
    {
          
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameManager.GameManagerInstance.Stage = Stage;
            GameManager.GameManagerInstance.Delay = Delay;
        }
    }
}
