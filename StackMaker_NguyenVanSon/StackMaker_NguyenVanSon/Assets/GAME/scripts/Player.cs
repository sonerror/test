using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //[SerializeField] private LayerMask wallLayer;
    [SerializeField] private float speed = 0.1f;
    [SerializeField] Rigidbody rb;
    [SerializeField] GameObject Object;

    [SerializeField] Stack<GameObject> brickUp = new Stack<GameObject>();

    private Vector3 currentTranform;

    [SerializeField] private float force = 400f;
    int count = 2;
    private Vector3 stack = new Vector3(0, 0.25f, 0);
    void Start()
    {
        //rb.GetComponent<Rigidbody>();
        currentTranform = new Vector3(0, transform.position.y, 0);
    }

    // Update is called once per frame

    void Update()
    {
        //xDirection = Input.GetAxisRaw("Horizontal");
        //zDirection = Input.GetAxisRaw("Vertical");
        Moving();
        //if (Input.GetKey(KeyCode.W))
        //{
        //    Debug.Log("1");
        //    rb.AddForce(Vector3.forward * force);
        //}
        //else if (Input.GetKey(KeyCode.A))
        //{
        //    Debug.Log("2");
        //    rb.AddForce(Vector3.left * force);
        //}
        //else if (Input.GetKey(KeyCode.S))
        //{
        //    Debug.Log("3");
        //    rb.AddForce(-Vector3.forward * force);
        //}
        //if (Input.GetKey(KeyCode.D))
        //{
        //    Debug.Log("4");
        //    rb.AddForce(-Vector3.left * force);
        //}
        //AddBrick();
        ControllerBrick();

    }

    void Moving()
    {
        //Vector3 moveDirection = new Vector3(xDirection, 0, zDirection);
        //transform.position+= moveDirection * speed;

        if (Input.GetKeyDown(KeyCode.D))
        {
            /*Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;
            Debug.DrawLine(transform.position, transform.position + Vector3.right * 100f, color: Color.red);
            if (Physics.Raycast(ray, out hit) && hit.collider.tag == "wall")
            {

                Debug.Log(hit.collider.name);
                float distance = hit.distance;
                Debug.Log("distance : " + distance);

            }*/
            rb.velocity = Vector3.right * speed;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            rb.velocity = -Vector3.right * speed;
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            rb.velocity = Vector3.forward * speed;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            rb.velocity = Vector3.back * speed;
        }

    }

    private void AddBrick()
    {

        RaycastHit hit;
        Debug.DrawLine(transform.position, transform.position + Vector3.down * 100f, color: Color.blue);
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 100f) && hit.collider.tag == "brick")
        {

            // Tạo 1 stack ngay dưới stack cũ
            GameObject obj = Instantiate(Object, new Vector3(transform.position.x, transform.position.y - count * stack.y, transform.position.z), Quaternion.identity) as GameObject;

            brickUp.Push(obj);

            // tăng độ cao nhân vật thêm 1 stack (0.25f)
            transform.position += stack;

            // xóa brick khi va chạm với raycast
            Destroy(hit.collider.gameObject);

            // sét các brick sinh ra làm con của player
            obj.transform.SetParent(transform);
            // tăng số lượng gạch lên 1 đv
            count++;

            //Debug.Log("1 :" + (count - 2));
            //obj.transform.position = transform.position - currentTranform + stack;
            //Debug.Log("2 :" + obj.transform.position);
        }
        if (hit.collider.tag == "bridge" && Physics.Raycast(transform.position, Vector3.down, out hit, 100f))
        {
            //Debug.LogError("stack");
            transform.position -= stack;
            Destroy(hit.collider.gameObject);

            Debug.Log("Name :" + transform.GetChild(count));
            Debug.Log("Name :" + count);

            Destroy(brickUp.Pop());
            //brickUp.Pop().SetActive(false);
        }
        if (hit.collider.tag == "bridge_end" && Physics.Raycast(transform.position, Vector3.down, out hit, 100f))
        {
            //Debug.LogError("stack");
            transform.position -= new Vector3(0, 0.75f, 0);
            Destroy(hit.collider.gameObject);
        }
    }


    private void ControllerBrick()
    {

        RaycastHit hit;
        Debug.DrawLine(transform.position, transform.position + Vector3.down * 100f, color: Color.red);
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 100f))
        {
            if (hit.collider.tag == "brick")
            {
                // Tạo 1 stack ngay dưới stack cũ
                GameObject obj = Instantiate(Object, new Vector3(transform.position.x, transform.position.y - count * stack.y, transform.position.z), Quaternion.identity) as GameObject;

                brickUp.Push(obj);

                // tăng độ cao nhân vật thêm 1 stack (0.25f)
                transform.position += stack;

                // xóa brick khi va chạm với raycast
                Destroy(hit.collider.gameObject);

                // sét các brick sinh ra làm con của player
                obj.transform.SetParent(transform);
                // tăng số lượng gạch lên 1 đv
                count++;

                //Debug.Log("1 :" + (count - 2));
                //obj.transform.position = transform.position - currentTranform + stack;
                //Debug.Log("2 :" + obj.transform.position);
            }
            else if (hit.collider.tag == "bridge")
            {
                count--;
                Destroy(hit.collider.gameObject);
                RemoveBrick();
            }
            else if (hit.collider.tag == "bridge_end")
            {
                Destroy(hit.collider.gameObject);
                ClearBrick();
            }
        }
    }

    private void RemoveBrick()
    {

        transform.position -= stack;
        Destroy(brickUp.Pop());
    }
    private void ClearBrick()
    {
        transform.position -= new Vector3(0, 0.75f, 0);
        Destroy(brickUp.Pop());
        Destroy(brickUp.Pop());
        Destroy(brickUp.Pop());
    }
}