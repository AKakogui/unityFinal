using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour
{

    [SerializeField] AudioSource soundSource;
    [SerializeField] AudioClip playerJump;

    public float speed = 3.0f;
    public float jumpForce = 12.0f;

    private Rigidbody2D body;
    private Animator animator;
    private BoxCollider2D box;


    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        box = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 max = box.bounds.max;
        Vector3 min = box.bounds.min;
        Vector3 corner1 = new Vector3(max.x, min.y - .2f);
        Vector3 corner2 = new Vector3(min.x, min.y - .2f);
        Collider2D hit = Physics2D.OverlapArea(corner1, corner2);

        bool grounded = false;
        if (hit != null)
        {
            grounded = true;
        }


        float deltaX = Input.GetAxis("Horizontal") * speed;
        Vector3 movement = new Vector3(deltaX, body.velocity.y);
        body.velocity = movement;

        MovingPlatform platform = null;
        if (hit != null)
        {
            platform = hit.GetComponent<MovingPlatform>();
        }
        if (platform != null)
        {
            transform.parent = platform.transform;
        }
        else
        {
            transform.parent = null;
        }

        animator.SetFloat("speed", Mathf.Abs(deltaX));
        Vector3 pScale = Vector3.one;
        if (platform != null)
        {
            pScale = platform.transform.localScale;
        }
        if (!Mathf.Approximately(deltaX, 0))
        {
            float playerScaleX = Mathf.Abs(transform.localScale.x); 
            
            float scaleX = Mathf.Sign(deltaX) * playerScaleX;

            float scaleY = transform.localScale.y;

            transform.localScale = new Vector3(scaleX, scaleY, 1);
        }

        if (Input.GetKeyDown(KeyCode.Space) && grounded) {
            body.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
            soundSource.PlayOneShot(playerJump);
        }

    }

}
