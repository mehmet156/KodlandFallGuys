using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    [SerializeField] float force = 20f;// gücün þiddeti 
    private Vector3 hitDir;

    void OnCollisionEnter(Collision collision)// 
    {
        foreach (ContactPoint contact in collision.contacts)// 
        {

            if (collision.gameObject.tag == "Player")
            {
                hitDir = contact.normal;

                collision.gameObject.GetComponent<Rigidbody>().AddForce(-hitDir * force, ForceMode.Impulse);// belli bir yönde kuvvet uygulayan kod 
                return;
            }
        }
       
    }
}
