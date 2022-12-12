using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class knockback : MonoBehaviour
{


    public float KBF = 50; //Knockback Force
    public GameObject enemy;
    Rigidbody rb;



    public float health = 50f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }



    private void OnTriggerEnter(Collider Collision)
    {
        if (Collision.gameObject.tag == "Base_Enemy")
        {
            Debug.Log("Enemy Hit");
            var healthComponent = gameObject.GetComponent<Health>();
            Knockback();

        }
    }
    public void Knockback()
    {


        if (rb != null)
        {
            Debug.Log("Player Should be blown back");
            rb.AddForce(gameObject.transform.position += transform.up * KBF, ForceMode.Impulse);
        }

    }
}