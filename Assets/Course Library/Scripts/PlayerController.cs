using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float ForSpeed;

    private Rigidbody PlayerRB;
    private GameObject FocalPoint;
    private Renderer PlayerRend;

    // Start is called before the first frame update
    void Start()
    {
        PlayerRB = GetComponent<Rigidbody>();
        PlayerRend = GetComponent<Renderer>();
        FocalPoint = GameObject.Find("Focal Point");
        
    }

    // Update is called once per frame
    void Update()
    {
        float VertIn = Input.GetAxis("Vertical");
        PlayerRB.AddForce(FocalPoint.transform.forward * VertIn * ForSpeed);
        if (VertIn > 0)
        {
            PlayerRend.material.color = new Color(1 - VertIn, 1, 1 - VertIn);
        }
        else
        {
            PlayerRend.material.color = new Color(1 + VertIn, 1, 1 + VertIn);
        }
        

    }
}
