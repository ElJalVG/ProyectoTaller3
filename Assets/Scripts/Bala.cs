using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    public float speed = 20f;    
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
    }
<<<<<<< HEAD
    
=======
    //void OnTriggerEnter2D(Collider2D hitInfo)
    //{
    //    Enemy enemy = hitInfo.GetComponent<Enemy>();
    //    if (enemy != null)
    //    {
    //        enemy.TakeDamage(damage);
    //    }
    //    Destroy(gameObject);
    //}
    private void OnBecameInvisible()
    {

        Destroy(gameObject);

    }
>>>>>>> 46f0f85574b3f5074f26c0d97b276f6e859f2f6a
}
