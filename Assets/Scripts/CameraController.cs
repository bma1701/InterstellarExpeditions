using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public GameObject player;
    private float respawnTime = 3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);
        if(player.activeSelf == false)
        {
            if(respawnTime > 0)
                respawnTime -= Time.deltaTime;
            else
            {
                player.SetActive(true);
                player.transform.position = new Vector3(0, 0, 0);
                player.transform.eulerAngles = new Vector3(0, 0, 0);
                respawnTime = 3;
            }
        }
    }
}
