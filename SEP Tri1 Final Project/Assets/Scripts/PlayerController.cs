using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private GameManager gameManager;

    private float horizontalInput;
    private float verticalInput;
    private float speed = 10.0f;
    private float range = 3.5f;

    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.isGameActive)
        {
            // player movement
            horizontalInput = Input.GetAxis("Horizontal");
            verticalInput = Input.GetAxis("Vertical");
            transform.Translate(Vector2.right * Time.deltaTime * speed * horizontalInput);
            transform.Translate(Vector2.up * Time.deltaTime * speed * verticalInput);

            // animation direction setters
            animator.SetFloat("Down_speed", verticalInput);
            animator.SetFloat("Up_speed", verticalInput);
            animator.SetFloat("Left_speed", horizontalInput);
            animator.SetFloat("Right_speed", horizontalInput);

            // setting player movement range (within the island)
            if (transform.position.x < -range)
            {
                transform.position = new Vector2(-range, transform.position.y);
            }
            if (transform.position.x > range)
            {
                transform.position = new Vector2(range, transform.position.y);
            }
            if (transform.position.y < -range)
            {
                transform.position = new Vector2(transform.position.x, -range);
            }
            if (transform.position.y > range)
            {
                transform.position = new Vector2(transform.position.x, range);
            }
        }
        else
        {
            animator.SetFloat("Down_speed", 0);
            animator.SetFloat("Up_speed", 0);
            animator.SetFloat("Left_speed", 0);
            animator.SetFloat("Right_speed", 0);
        }
    }
}
