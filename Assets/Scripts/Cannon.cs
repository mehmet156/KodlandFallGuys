using UnityEngine;

public class Cannon : MonoBehaviour
{
    [SerializeField] GameObject projectilePrefab;// sahnedeki her obje
    [SerializeField] Transform firePoint; // ateþ edeceði nokta
    [SerializeField] float fireInterval = 3f;// cooldown
    [SerializeField] float launchForce = 500f;// ateþ etme gücü

    private void Start()
    {
        InvokeRepeating("Fire", 0f, fireInterval);// tekrarlanan fonksiyon
        
    }

    void Fire()
    {
        GameObject proj = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);//bomba oluþturur
        Rigidbody rb = proj.GetComponent<Rigidbody>();
        rb.AddForce(firePoint.forward * launchForce);//
    }
}