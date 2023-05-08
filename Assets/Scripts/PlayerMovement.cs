using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Animator animator;
    private Vector2 movement;
    private float direction = 2;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        rb.MovePosition(rb.position + movement * moveSpeed * 0.1f);

        if (movement.x > 0)
            direction = 0;
        else if (movement.x < 0)
            direction = 1;
        if(movement.y > 0)
            direction = 2;
        else if(movement.y < 0)
            direction = 3;

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
        animator.SetFloat("Direction", direction);
        if (direction == 0)
            transform.localScale = new Vector3(-1, 1, 1);
        else
            transform.localScale = new Vector3(1, 1, 1);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Planet1"))
            SceneManager.LoadScene("Scenes/Boss1");
        else if (collision.gameObject.CompareTag("Planet2"))
            SceneManager.LoadScene("Scenes/Boss2");
        else if (collision.gameObject.CompareTag("Planet3"))
            SceneManager.LoadScene("Scenes/Boss3");
        else if (collision.gameObject.CompareTag("Planet4"))
            SceneManager.LoadScene("Scenes/Boss4");
    }

}
