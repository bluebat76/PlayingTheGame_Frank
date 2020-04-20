using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCam : MonoBehaviour
{

    public float RotSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float HorzIn = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up, HorzIn * Time.deltaTime * RotSpeed);
    }
}
