using UnityEngine;
using TMPro;

public class Projectile : MonoBehaviour
{
    [SerializeField] float explosionDelay = 5f;//ka� saniye sonra patlayacak
    [SerializeField] float explosionRadius = 5f;//patlama yar� �ap� 
    [SerializeField] float explosionForce = 700f;//patlama g�c�
    [SerializeField] GameObject timerUIPrefab;//bomban�n patlama s�resi
    GameObject timerUI; //s�renin canvas�
    TextMeshProUGUI timerText;//patlama metni
    [SerializeField] GameObject explosion;// patlama efekti

    void Start()
    {
        timerUI = Instantiate(timerUIPrefab, transform.position + Vector3.up * 1.5f, Quaternion.identity);//
        timerUI.transform.SetParent(null);
        timerText = timerUI.GetComponentInChildren<TextMeshProUGUI>();

        explosionDelay = Random.Range(1, explosionDelay);
    }

    void Update()
    {
        explosionDelay -= Time.deltaTime;
        if (explosionDelay <= 0f)
        {
            Explode();
        }
        timerUI.transform.position = transform.position + Vector3.up * 1.5f;
        timerUI.transform.rotation = Quaternion.LookRotation(Camera.main.transform.forward);
        timerText.text = explosionDelay.ToString("F1");
    }
    void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (var hit in colliders)//dizinin i�indeki b�t�n elamanlar� gezmek i�in kullan�l�r
        {
            if (hit.CompareTag("Player") && hit.attachedRigidbody != null)
            {
                hit.attachedRigidbody.AddExplosionForce(explosionForce, transform.position, explosionRadius);
                              
            }
        }
        Instantiate(explosion, transform.position, transform.rotation);
        Destroy(gameObject);

        Destroy(timerUI);
    }
}