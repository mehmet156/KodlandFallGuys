using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    Vector3 currentCheckpoint; 
    [SerializeField] float fallPoint = -20f;

    Rigidbody rb;//***************************************************
    public Lava lava;//**************************************************
    public int health;
    public GameObject weapon;
    void Start()
    {

        currentCheckpoint = transform.position;
        rb = GetComponent<Rigidbody>();//***************************************************
        
    }

    void Update()
    {
        if (transform.position.y < fallPoint)
        {
            Respawn();//***********************
        }
    }
   public void Respawn()//**********************
    {
        transform.position = currentCheckpoint;
        rb.velocity = Vector3.zero;
        lava.StopLava();//***************************************************
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Checkpoint"))
        {
            currentCheckpoint = other.transform.position;
        }
    }
    
}