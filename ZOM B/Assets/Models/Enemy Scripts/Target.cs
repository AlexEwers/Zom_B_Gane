using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Target : MonoBehaviour
{
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public float KBF = 50; //Knockback Force
    public GameObject player;
    Rigidbody rb;
    

    Vector3 velocity;
    bool isGrounded;

    public float health = 50f;

     void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    
    private void OnTriggerEnter(Collider Collision)
    {
        if (Collision.gameObject.tag == "Player")
        {
            Debug.Log("Player Hit");
            var healthComponent = Collision.GetComponent<Health>();
            if(healthComponent !=null)
            {
                    healthComponent.TakeDamage(1);
            }

            Rigidbody rb = gameObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                Debug.Log("Player Should be blown back");
                Knockback();
            }
           
        }
    }


    void Knockback()
    {
        rb.AddForce(gameObject.transform.position += transform.up * KBF, ForceMode.Impulse);
      
    }
    
 
    


    public void TakeDamage (float amount)
    {
        health -= amount;

        if (health <= 0f)
        {
            Die();
        }
    }

  
    void Die()
    {
        Destroy(gameObject);
    }

     void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y< 0)
        {
            velocity.y = -2f;
        }
}
    

}

    
