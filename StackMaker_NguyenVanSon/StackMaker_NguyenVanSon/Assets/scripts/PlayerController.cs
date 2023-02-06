using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Animator anim;

    private Rigidbody rb;
    private string currentAnimName;
    private BoxCollider boxCollider;

    public float moveSpeed;
    


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }
    void Update()
    {

       /* float horAxis = Input.GetAxis("Horizontal");
        float verAxis = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horAxis, 0.0f, verAxis);

        GetComponent<Rigidbody>().AddForce(movement * speed * Time.deltaTime);*/
        rb.velocity = new Vector3(Input.GetAxis("Horizontal")*moveSpeed, rb.velocity.y, Input.GetAxis("Vertical")*moveSpeed);
    }
    /*private void InputHandle()
    {
        if (Input.GetKeyDown(KeyCode.W))
            {
            MoveFoward(moveSpeed);
        }

    }
    void jump()
    {

    }
    void MoveLeft(float moveSpeed)

    {
        boxCollider.center = LEFT_COLLIDER_CENTER;
        rb.velocity = Vector3.left * moveSpeed;

    }
    void MoveRight(float moveSpeed)
    {
      //  Jump();
        boxCollider.center = RIGHT_COLLIDER_CENTER;
        rb.velocity = Vector3.right * moveSpeed;
    }

    void MoveFoward(float moveSpeed)
    {
     //   Jump();
        boxCollider.center = FORWARD_COLLIDER_CENTER;
        rb.velocity = Vector3.forward * moveSpeed;
    }

    void MoveBackward(float moveSpeed)
    {
      //  Jump();
        boxCollider.center = BACKWARD_COLLIDER_CENTER;
        rb.velocity = Vector3.back * moveSpeed;
    }
    public void Move(Vector3 direction, float moveSpeed)
    {
       // Jump();
        boxCollider.center = direction * 0.45f;
        rb.velocity = direction * moveSpeed;
    }*/
    private void ChangeAnim(string animName)
    {
        if (currentAnimName != animName)
        {
            anim.ResetTrigger(animName);
            currentAnimName = animName;
            anim.SetTrigger(currentAnimName);
        }
    }
    private void OnTriggerEnter(Collider collision)
    {
        if(collision.tag == "ground")
        {
            Destroy(collision.gameObject);
        }    
    }

}
