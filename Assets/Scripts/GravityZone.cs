using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityZone : MonoBehaviour
{
    float defaultGravity = -9.81f; //yer �ekimi
    bool isInZone = false;// alan�n i�erisine 

    void OnTriggerEnter(Collider other)// temas� alg�lar  giri� yapt���nda 
    {
        if (other.CompareTag("Player"))
        {
            isInZone = true;
        }
    }
   
    void OnTriggerExit(Collider other)// ��k�� yapt���nda
    {
        if (other.CompareTag("Player"))
        {
            isInZone = false;
            Physics.gravity = new Vector3(0, defaultGravity, 0);// standarrt yer�ekimi
        }
    }

    void Update()
    {
        if (isInZone && Input.GetKeyDown(KeyCode.Q))
        {
            Physics.gravity = new Vector3(0, -Physics.gravity.y, 0);// 
        }
    }
}
