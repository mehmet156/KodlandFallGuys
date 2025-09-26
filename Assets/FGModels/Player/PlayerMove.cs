using UnityEngine;
public class PlayerMove : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float jumpSpeed;
    public Animator anim;
    Rigidbody rb;
    Vector3 direction;
    bool isGrounded;

    [SerializeField] float iceAcceleration = 15f;//****************************  3.14 pi 
    bool isOnIce = false;//************************************** oyuncu buzun üstünde mi deðilmi 
    float colliderHeight;
    float tempSpeed;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        colliderHeight = gameObject.GetComponent<CapsuleCollider>().height;
        tempSpeed=speed;
    }
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        direction = transform.TransformDirection(x, 0, z);
        
        bool isMoving = direction.magnitude > 0.1f;
        anim.SetBool("isRunning", isMoving); 
        
        if (isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.AddForce(new Vector3(0, jumpSpeed, 0), ForceMode.Impulse);
            }
        }        
    }
    private void FixedUpdate()//***********************************
    {
        if (isOnIce==true)
        {
            rb.AddForce(direction * iceAcceleration);
        }
        else
        {
            rb.MovePosition(transform.position + direction * speed * Time.fixedDeltaTime);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Slide"))
        {
            speed *= 2;
             gameObject.GetComponent<CapsuleCollider>().height=1;
        }
    }
    private void OnCollisionStay(Collision other)
    {
        if (other != null)
        {
            isGrounded = true;

            //*********************************************************
            if (other.gameObject.CompareTag("Ice"))
            {
                isOnIce = true;//
            }
            else
            {
                isOnIce = false;
            }
            //*********************************************************
            
        }


    }
    private void OnCollisionExit(Collision other)
    {
        isGrounded = false;

        //****************************************
        if (other.gameObject.CompareTag("Ice"))
        {
            isOnIce = false;
        }
        //**********************************************
        if (other.gameObject.CompareTag("Slide"))
        {
            speed=tempSpeed;
            gameObject.GetComponent<CapsuleCollider>().height = colliderHeight;
        }
    }    
}