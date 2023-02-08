using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraflow : MonoBehaviour
{
    public GameObject Player;
    [SerializeField]private Vector3 offset;
    // Start is called before the first frame update


    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = Player.transform.position + offset;
    }
}
