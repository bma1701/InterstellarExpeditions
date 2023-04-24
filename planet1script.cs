using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class planet1script : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private string scene;

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
            SceneManager.LoadScene(scene);
    }
}
