using UnityEngine;
using System.Collections;

public class PlayerControler : MonoBehaviour {
    public int moveSpeed;
    public int jumpHeight;
    //public int health; 
    public Transform groundPoint;
    public float radius;
    public LayerMask groundMask;
    public GameObject animator;

    bool isGrounded;
    Rigidbody2D rigid2d;

	// Use this for initialization
	void Start ()
    {
        rigid2d = GetComponent<Rigidbody2D>();
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        Vector2 moveDir = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed, rigid2d.velocity.y);
        rigid2d.velocity = moveDir;
        isGrounded = Physics2D.OverlapCircle(groundPoint.position, radius, groundMask);

        if (Input.GetAxisRaw("Horizontal") == 1)
        {
            transform.localScale = new Vector3(7, 7, 7);// es 7 porque el sprite esta agrandado de su tamaño original
        } else if (Input.GetAxisRaw("Horizontal") == -1)
          {
            transform.localScale = new Vector3(-7, 7, 7);

          }
        if ((Input.GetAxisRaw("Horizontal") != 0))
        {
            animator.GetComponent<Animator>().SetBool("isMoving", true);
        }
        else
        {
            animator.GetComponent<Animator>().SetBool("isMoving", false);
        }
        if (Input.GetKeyDown(KeyCode.W) && isGrounded || Input.GetKeyDown(KeyCode.UpArrow)&& isGrounded)
            {
              rigid2d.AddForce(new Vector2(0, jumpHeight));
            }
    /*    if (health <= 0)
        {
            gameOver();
        }
    // void gameOver(){ };*/

	}
}
