using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Sprite[] playerSkins;
    private UserManager userManager;
    public bool isGrounded = true;
    //Rigidbody2D rb;
    // Start is called before the first frame update
    void Awake()
    {
        userManager = GameObject.FindGameObjectWithTag("UserManager").GetComponent<UserManager>();
        this.GetComponent<Image>().sprite = playerSkins[userManager.skinIndexUsed];
        //rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //this.transform.Translate(Vector3.down * 2.5f);
        if (Input.GetKeyDown(KeyCode.Space))
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
        //rb.AddForce(new Vector2(0f, 105f)* Time.deltaTime, ForceMode2D.Impulse);
        this.transform.Translate(Vector3.up * 4.5f * Time.deltaTime);
        //rb.
        //this.GetComponent<BoxCollider2D>().isTrigger = true;
        isGrounded = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
            isGrounded = true;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
            isGrounded = true;
    }
}
