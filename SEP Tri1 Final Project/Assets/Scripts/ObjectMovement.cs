using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovement : MonoBehaviour
{

    private float speed = 10.0f;
    private bool spawnLeft;

    private float leftBound = -12.5f;
    private float rightBound = 12.5f;

    // Start is called before the first frame update
    void Start()
    {
        // determine which side the object spawned on
        if (transform.position.x < 0)
        {
            spawnLeft = true;
        }
        else
        {
            spawnLeft = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // object movement
        if (spawnLeft)
        {
            transform.Translate(Vector2.right * Time.deltaTime * speed);
        }
        else
        {
            transform.Translate(Vector2.left * Time.deltaTime * speed);
        }

        // destroy object out of bounds
        if ((spawnLeft && transform.position.x > rightBound) || (!spawnLeft && transform.position.x < leftBound))
        {
            Destroy(gameObject);
        }
    }
}
