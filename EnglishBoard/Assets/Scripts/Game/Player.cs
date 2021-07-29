using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Sprite[] playerSkins;
    private UserManager userManager;
    public bool isGrounded = false;
    public AudioSource audioSource;
    public AudioClip[] sounds;
    Transform parentTransform;
    Rigidbody2D rb;
    Vector2 origin;
    GameObject canvas;
    // Start is called before the first frame update
    void Awake()
    {
        canvas = GameObject.FindGameObjectWithTag("Canvas");
        parentTransform = GetComponentInParent<Transform>();
        origin = this.transform.position;
        audioSource = GetComponent<AudioSource>();
        userManager = GameObject.FindGameObjectWithTag("UserManager").GetComponent<UserManager>();
        this.GetComponent<Image>().sprite = playerSkins[userManager.skinIndexUsed];
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //this.transform.Translate(Vector3.down * 2.5f);
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }
        if(Input.touchCount > 0 && isGrounded)
        {
            Jump();
        }
        //if (rb.velocity.y <= 0) ;
            //this.GetComponent<BoxCollider2D>().isTrigger = false;
    }
    private void Jump()
    {
        Debug.Log("Jumping");
        //Rigidbody2D rb = this.GetComponent<Rigidbody2D>();
        
        rb.AddForce(new Vector2(0f, 95f), ForceMode2D.Impulse);
        transform.parent = canvas.transform;
        //this.transform.Translate(Vector3.up * 105f * Time.deltaTime);
        //rb.velocity = Vector2.up * 145.0f;
        //this.GetComponent<BoxCollider2D>().isTrigger = true;
        isGrounded = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PowerUp"))
        {
            int index = collision.gameObject.GetComponentInParent<PowerUps>().randomIndex;
            LaunchingSound(index);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            isGrounded = true;
            //transform.SetParent(collision.transform,false);
            transform.parent = collision.transform;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            isGrounded = false;
            //transform.SetParent(parentTransform,false);
            transform.parent = canvas.transform;
        }
    }
    private void LaunchingSound(int index)
    {
        if(UserManager.soundOn == 1)
        {
            switch (index)
            {
                case 0:
                    audioSource.clip = sounds[0];
                    audioSource.Play();
                    break;
                case 1:
                    audioSource.clip = sounds[1];
                    audioSource.Play();
                    break;
                case 2:
                    audioSource.clip = sounds[2];
                    audioSource.Play();
                    break;
            }
        }
    }
}
