using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    //[SerializeField] private Animator anim;
    [SerializeField] GameObject obj;
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
    
   /* private void ChangeAnim(string animName)
    {
        if (currentAnimName != animName)
        {
            anim.ResetTrigger(animName);
            currentAnimName = animName;
            anim.SetTrigger(currentAnimName);
        }
    }*/
    private void OnTriggerEnter(Collider collision)
    {
        /*Ray ray = new Ray(transform.position, transform.forward);

        RaycastHit hit;

       
        if (Physics.Raycast(ray,out hit)&& hit .collider.tag == "ground")
         {
            //Instantiate(obj,hit.point,Quaternion.Identity);
            Destroy(collision.gameObject);
        }*/
        if(collision.gameObject.tag == "ground")
        {
            Destroy(collision.gameObject);
        }
        
    }

}
