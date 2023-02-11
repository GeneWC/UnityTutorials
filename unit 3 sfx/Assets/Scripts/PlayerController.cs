using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    public float jumpForce = 10;
    public float gravityModifier = 1;
    public bool isOnGround = true;
    public bool gameOver = false;
    private Animator playerAnim;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    public AudioClip jumpSound;
    public AudioClip crashSound;
    private AudioSource playerAudio;
    public float sfxVolume = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        Physics.gravity *= gravityModifier;
        playerAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            dirtParticle.Stop();
            playerAudio.PlayOneShot(jumpSound, sfxVolume);
        }
        if (transform.position.x < -0.01)
        {
            gameOver = true;
        }
        if (gameOver)
        {
            dirtParticle.Stop();
            Debug.Log("Game Over");
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            explosionParticle.Play();
            enabled = false;
            playerAudio.PlayOneShot(crashSound, sfxVolume);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        isOnGround = true;
        if (isOnGround)
        {
            dirtParticle.Play();
        }
        if (collision.gameObject.CompareTag("Unjumpable Obstacle"))
        {
            gameOver = true;
            
        }
    }
}
