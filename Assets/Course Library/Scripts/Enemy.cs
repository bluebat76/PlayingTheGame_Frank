using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 1;

    private Rigidbody EnemyRB;
    private GameObject player;
    private int OOB = -10; // Out Of Bounds


    // Start is called before the first frame update
    void Start()
    {
        EnemyRB = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 MoveDir = (player.transform.position - transform.position).normalized;
        EnemyRB.AddForce(MoveDir * speed);

        if (transform.position.y < OOB)
        {
            Destroy(gameObject);
        }
    }
}
