using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    public float bounceForce;
    private Rigidbody2D myBody;
    private Animator anim;

    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip flyClip, pingClip, dieClip;
    public float flag = 0;
    private GameObject spawner;
    private bool isAlive;
    public int score = 0;

    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        MakeInstance();
        spawner = GameObject.Find("SpawnerPipe");
        isAlive = true;
    }

    void MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
    }    

    private void FixedUpdate()
    {
        PlayerMovement();
    }

    void PlayerMovement()
    {
        if (isAlive) {
            if (Input.GetKey(KeyCode.Space))
            {
                myBody.velocity = new Vector2(myBody.velocity.x, bounceForce);
                audioSource.PlayOneShot(flyClip);
            }

            if (myBody.velocity.y > 0)
            {
                float angle = 0;
                angle = Mathf.Lerp(0, 90, myBody.velocity.y / 7);
                transform.rotation = Quaternion.Euler(0, 0, angle);
            }
            else if (myBody.velocity.y == 0)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else if (myBody.velocity.y < 0)
            {
                float angle = 0;
                angle = Mathf.Lerp(0, -90, -myBody.velocity.y / 7);
                transform.rotation = Quaternion.Euler(0, 0, angle);
            }
        }
    }
    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "PipeHolder")
        {
            score++;
            if (GameplayController.instance != null)
            {
                GameplayController.instance.SetScore(score);
            }    
            audioSource.PlayOneShot(pingClip);
        }
    }

    private void OnCollisionEnter2D(Collision2D target)
    {
        if (target.gameObject.tag == "Pipe" || target.gameObject.tag == "Ground")
        {
            flag = 1;
            if (isAlive)
            {
                isAlive = false;
                Destroy(spawner);
                audioSource.PlayOneShot(dieClip);
                anim.SetTrigger("Died");
            }
            if (GameplayController.instance != null)
            {
                GameplayController.instance.ShowPanel(score);
            }    
        }    
    }
}
