using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stack : MonoBehaviour
{
    static string addStack = "addstack";
    static string normal_tag = "normal_tag";
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag.Equals(addStack))
        {
            other.gameObject.tag = normal_tag;
          
            //PlayerController.
        }
    }
}
