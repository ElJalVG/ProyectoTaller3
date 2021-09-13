using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.Accessibility;


public class Ai2 : MonoBehaviour
{
    [SerializeField]
    public float speed;
    [SerializeField]
    private Transform target;
    [SerializeField]
    public float stopingDistance;
    [SerializeField]
    private float range;
    bool StayFollow = false;
    [SerializeField]
    int health = 100;
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(target.position, transform.position) <= range)
        {
            StayFollow = true;
        }
        if (StayFollow == true)
        {
            FollowPlayer();
        }
    }
    public void FollowPlayer()
    {
        if (Vector2.Distance(transform.position, target.position) > stopingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
        else 
        {

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Bala")
        {
            health -= 10;
            Destroy(collision.gameObject);
            if(health<=0)
            {
                Destroy(gameObject);
            }
        }
       
    }

}
