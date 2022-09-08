using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private float leftBound = -2.0f;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        // Move objects left.
        if (gameManager.isGameActive)
        {
            transform.Translate(Vector3.left * Time.deltaTime * gameManager.speed);
        }

        // Destroy Obstacles when they go off the left side of the screen.
        if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }

        // Destroy Dirt when it goes off the left side of the screen.
        if (transform.position.x < leftBound && gameObject.CompareTag("Dirt"))
        {
            Destroy(gameObject);
        }
    }
}
