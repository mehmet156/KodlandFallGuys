using UnityEngine;

public class Bounce : MonoBehaviour
{
    [SerializeField] Transform springObject;// yay objesi 
    [SerializeField] float compressScale = 0.7f;// ne kadar k���lecek
    [SerializeField] float stretchSpeed = 5f;// ne kadar h�zl� k���lecek ondal�kl� say� 1.72 ko�ma h�z�
    [SerializeField] int force;// uygulanacak kuvvet integer tamsay� 2 karekterin z�plama g�c�
    bool isCompressing = false;// bask� var m�__ Kap� a��k m� de�il mi 
    Vector3 one;// Vector3(1,1,1)// 3 veri ta��yan de�i�ken instantiate olurken kullan�labilir
    
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
        if (isCompressing)// e�er isCompressing 
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
            Collider playerCollider = GameObject.FindGameObjectWithTag("Player").GetComponent<Collider>();// gameObject s�n�rlar�n� belirler
            Rigidbody playerRigidbody = playerCollider.GetComponent<Rigidbody>();//fizik i�lemleri i�in yer �ekimi vb.
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