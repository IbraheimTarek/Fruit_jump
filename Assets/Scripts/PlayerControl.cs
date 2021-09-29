using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private Rigidbody playerRb;
    private Animator playerAnim;
    private AudioSource playeraudio;
    public ParticleSystem explotionparticle;
    public ParticleSystem dirtparticle;
    public AudioClip jumpsound;
    public AudioClip crashsound;
    public float jumpforce = 10;
    public float garvitymodifier;
    private bool isonground = true;
    public bool gameover = false;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        playeraudio = GetComponent<AudioSource>();
        Physics.gravity *= garvitymodifier;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isonground && !gameover)
        {
            playerRb.AddForce(Vector3.up * jumpforce,ForceMode.Impulse);
            isonground = false;
            playerAnim.SetTrigger("Jump_trig");
            dirtparticle.Stop();
            playeraudio.PlayOneShot(jumpsound, 1.0f);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isonground = true;
            dirtparticle.Play();
        }else if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameover = true;
            Debug.Log("GAME OVER");
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            explotionparticle.Play();
            dirtparticle.Stop();
            playeraudio.PlayOneShot(crashsound, 1.0f);
        }
    }
}
