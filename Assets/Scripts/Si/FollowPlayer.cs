using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField]
    int MoveStage;
    [SerializeField]
    GameObject Player;

    PlayerMovement pm;

    // Start is called before the first frame update
    void Start()
    {
         pm=Player.GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (MoveStage == GameManager.GameManagerInstance.Stage)
        {
            transform.position += transform.forward * Time.deltaTime * pm.speed;
            if (MoveStage != 4)
                transform.rotation = Player.transform.rotation;            
        }
    }
}
