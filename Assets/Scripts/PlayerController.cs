using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float verticalInput;
    public float speed = 2.0f;
    public float zTop = -2.0f;
    public float zBottom = -4.0f;

    public AudioClip crashSound;
    public AudioClip pickupSound;
    private AudioSource playerAudio;

    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    public ParticleSystem emberParticle;
    public ParticleSystem smokeParticle;

    private GameManager gameManager;
    private bool dirtCleaned = false;

    // Start is called before the first frame update
    void Start()
    {
        playerAudio = GetComponent<AudioSource>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        // Keep the Player from going off the bottom of the scene.
        if (transform.position.z < zBottom)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zBottom);
        }
        // Keep the Player from going off the top of the scene.
        if (transform.position.z > zTop)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zTop);
        }
        if (gameManager.isGameActive)
        {
            // Up and Down arrow keys move the Player up and down.
            verticalInput = Input.GetAxis("Vertical");
            transform.Translate(Vector3.forward * verticalInput * Time.deltaTime * speed);
        }
        if (dirtCleaned == true)
        {
            // Check if Dirt was recently destroyed. If so, add a point to the score.
            gameManager.UpdateScore(1);
            dirtCleaned = false;
        }
    }

    // End game when colliding with Obstacles.
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameManager.GameOver();
            Debug.Log("Game Over!");
            explosionParticle.Play();
            emberParticle.Play();
            smokeParticle.Play();
            playerAudio.PlayOneShot(crashSound, 1.0f);
        }
    }

    // Destroy Dirt when colliding with it.
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Dirt"))
        {
            Destroy(other.gameObject);
            dirtParticle.Play();
            playerAudio.PlayOneShot(pickupSound, 1.0f);
            dirtCleaned = true;
        }
    }
}
