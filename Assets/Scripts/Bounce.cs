using UnityEngine;

public class Bounce : MonoBehaviour
{
    [SerializeField] Transform springObject;// yay objesi 
    [SerializeField] float compressScale = 0.7f;// ne kadar küçülecek
    [SerializeField] float stretchSpeed = 5f;// ne kadar hýzlý küçülecek ondalýklý sayý 1.72 koþma hýzý
    [SerializeField] int force;// uygulanacak kuvvet integer tamsayý 2 karekterin zýplama gücü
    bool isCompressing = false;// baský var mý__ Kapý açýk mý deðil mi 
    Vector3 one;// Vector3(1,1,1)// 3 veri taþýyan deðiþken instantiate olurken kullanýlabilir
    
    float compressDuration = 0.5f;
    float compressTime = 0f;
    float bounceDelay = 0.1f;
    float bounceTime = 0f;
    bool canBounce = false;
    void Start()
    {
        one = springObject.localScale;
    }

    void Update()
    {
        if (isCompressing)// eðer isCompressing 
        {
            springObject.localScale = Vector3.Lerp(springObject.localScale, new Vector3(1, compressScale, 1), Time.deltaTime * stretchSpeed);
            compressTime += Time.deltaTime;

            if (compressTime >= compressDuration)
            {
                canBounce = true;
            }
        }
        else
        {
            springObject.localScale = Vector3.Lerp(springObject.localScale, one, Time.deltaTime * stretchSpeed);
        }
        if (canBounce)
        {
            Collider playerCollider = GameObject.FindGameObjectWithTag("Player").GetComponent<Collider>();// gameObject sýnýrlarýný belirler
            Rigidbody playerRigidbody = playerCollider.GetComponent<Rigidbody>();//fizik iþlemleri için yer çekimi vb.
            playerRigidbody.AddForce(new Vector3(0, force, 0), ForceMode.Impulse);// 
            isCompressing = false;
            canBounce = false;
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            isCompressing = true;
            compressTime = 0f;
            bounceTime = 0f;
            canBounce = false;
            
        }
    }
}