using UnityEngine;

public class Cannon : MonoBehaviour
{
    [SerializeField] GameObject projectilePrefab;// sahnedeki her obje
    [SerializeField] Transform firePoint; // ate� edece�i nokta
    [SerializeField] float fireInterval = 3f;// cooldown
    [SerializeField] float launchForce = 500f;// ate� etme g�c�

    private void Start()
    {
        InvokeRepeating("Fire", 0f, fireInterval);// tekrarlanan fonksiyon
        
    }

    void Fire()
    {
        GameObject proj = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);//bomba olu�turur
        Rigidbody rb = proj.GetComponent<Rigidbody>();
        rb.AddForce(firePoint.forward * launchForce);//
    }
}