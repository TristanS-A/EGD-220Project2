using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateGround : MonoBehaviour
{
    public float rotSpeed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z + rotSpeed);
    }
}
