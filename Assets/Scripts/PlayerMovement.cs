using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Animator animator;
    SpriteRenderer spriteRender;
    Vector2 movement;
    [SerializeField]
   public float health = 100f;
    public GameObject attackPoint;
    public VidaPlayer _uiManager;

    // Start is called before the first frame update
    void Start()
    {
        spriteRender = GetComponent<SpriteRenderer>();
        _uiManager = GameObject.Find("Player").GetComponent<VidaPlayer>();
        if (_uiManager != null)
        {
            _uiManager.UpdateLives(health);
        }
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        spriteRender.flipX = movement.x < 0;
        attackPoint.transform.localPosition= new Vector3(movement.x<0?-1.45f:1.45f,attackPoint.transform.localPosition.y,attackPoint.transform.localPosition.z);
        //Vector3 scale = new Vector3(movement.x < 0 ? -1 : 1, 1, 1);
        //transform.localScale = scale;

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }
    void FixedUpdate()
    {
        rb.MovePosition(rb.position+movement*moveSpeed*Time.fixedDeltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "BulletEnemy")
        {
            health -= 10;

            Destroy(collision.gameObject);
            if (health <= 0)
            {
                Destroy(gameObject);
            }

        }
        _uiManager.UpdateLives(health);

    }
}
