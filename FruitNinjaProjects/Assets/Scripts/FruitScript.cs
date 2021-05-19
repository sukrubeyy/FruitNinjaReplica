using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitScript : MonoBehaviour
{
    public GameObject fractureObject;
    Rigidbody2D rb;
    float startJump = 12f;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.up* startJump,ForceMode2D.Impulse);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Blade")
        {
            Vector3 direction = (collision.transform.position - transform.position).normalized;
            Quaternion rot = Quaternion.LookRotation(direction);

          GameObject fractured =  Instantiate(fractureObject,transform.position,rot);
            Destroy(fractured, 3f);
          Destroy(gameObject);
        }
    }
}
