using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityZone : MonoBehaviour
{
    float defaultGravity = -9.81f; //yer çekimi
    bool isInZone = false;// alanýn içerisine 

    void OnTriggerEnter(Collider other)// temasý algýlar  giriþ yaptýðýnda 
    {
        if (other.CompareTag("Player"))
        {
            isInZone = true;
        }
    }
   
    void OnTriggerExit(Collider other)// çýkýþ yaptýðýnda
    {
        if (other.CompareTag("Player"))
        {
            isInZone = false;
            Physics.gravity = new Vector3(0, defaultGravity, 0);// standarrt yerçekimi
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
