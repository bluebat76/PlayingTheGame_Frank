using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float ForSpeed;

    private Rigidbody PlayerRB;
    private GameObject FocalPoint;
    private Renderer PlayerRend;
    public bool HasPowerUp = false;
    private float PowerUpKick = 10f;
    private Animator Anim;
    public GameObject PowerUpRing;

    //private int OOB = -10; // Out Of Bounds

    // Start is called before the first frame update
    void Start()
    {
        PlayerRB = GetComponent<Rigidbody>();
        PlayerRend = GetComponent<Renderer>();
        Anim = GetComponent<Animator>();
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

        PowerUpRing.transform.position = transform.position;

        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUp"))
        {
            HasPowerUp = true;
            Anim.SetBool("HasPowerUp", true);
            PowerUpRing.SetActive(true);
            Destroy(other.gameObject);
            StartCoroutine(PowerUpCountdown());

        }
    }

    private IEnumerator PowerUpCountdown()
    {
        yield return new WaitForSeconds(5.0f);
        HasPowerUp = false;
        Anim.SetBool("HasPowerUp", false);
        PowerUpRing.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Player collided with " + collision.gameObject + " with powerUp set to " + HasPowerUp);

        if (collision.gameObject.CompareTag("Enemy") && HasPowerUp)
        {
            Rigidbody EnemyRB = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 dir = collision.gameObject.transform.position - transform.position;
            EnemyRB.AddForce(dir * PowerUpKick, ForceMode.Impulse);
        }
    }
}
