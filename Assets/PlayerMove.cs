using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float movePower = 1.0f;
    public float jumpPower = 1.0f;
    Animator animator;
    Rigidbody2D rigid;
    SpriteRenderer render;
    Collider2D col2D;
    Vector3 movement;
    bool isJumping = false;
    bool isGround = false;

    // Start is called before the first frame update
    void Start()
    {
        rigid = gameObject.GetComponent<Rigidbody2D>();
        render = gameObject.GetComponentInChildren<SpriteRenderer>();
        animator = gameObject.GetComponentInChildren<Animator>();
        col2D = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
      //  CheckGround();
        if (Input.GetButtonDown("Jump"))
        {
            isJumping = true;
        }
    }

    private void FixedUpdate()
    {
        Move();
        Jump();
    }

    void Move() {
        Vector3 moveVelocity = Vector3.zero;

        //LeftMove
        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            moveVelocity = Vector3.left;
            //transform.localScale = new Vector3(-1, 1, 1);
            render.flipX = true;
            animator.SetBool("isRun", true);
        }
        //RightMove
        else if (Input.GetAxisRaw("Horizontal") > 0)
        {
            moveVelocity = Vector3.right;
            //transform.localScale = new Vector3(1, 1, 1);
            render.flipX = false;
            animator.SetBool("isRun", true);
        }
        else {
            animator.SetBool("isRun", false);
        }
        transform.position += moveVelocity * movePower * Time.deltaTime;
    }

    void Jump() {
        if (!isJumping)
            return;
        //rigid.velocity = Vector2.zero;
        //Vector2 jumpVelocity = new Vector2(0, jumpPower);

        rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
        isJumping = false;

        //rigid.AddForce(Vector2.up * jumpPower);
        //isJumping = false;

    }
    //void CheckGround() {      
    //    RaycastHit2D raycastHit = Physics2D.BoxCast(col2D.bounds.center, col2D.bounds.size, 0f, Vector2.down, 0.02f, LayerMask.GetMask("Ground"));
    //    if (raycastHit.collider != null)
    //        animator.SetBool("isJump", false);
    //    else animator.SetBool("isJump", true);

    //    ////Å×½ºÆ®¿ë
    //    Debug.DrawRay(transform.position, Vector3.down * 1.2f, Color.red);
    //    //RaycastHit hit;
    //    //if (Physics.Raycast(transform.position, Vector3.down, out hit, 1.2f)) {
    //    //    if (hit.transform.tag == "Ground") {
    //    //        isGround = true;
    //    //        Debug.Log("¶¥¹ÙÅ¹È÷Æ®");
    //    //        return;
    //    //    }
    //    //}
    //    //isGround = false;

    //}
}
