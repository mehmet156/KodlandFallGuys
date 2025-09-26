using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fan : MonoBehaviour
{
  
    [SerializeField] Vector3 windDirection;

  
    private void OnTriggerStay(Collider other)// Objenin içerinde kaldýðý sürece çalýþýr
    {
        other.GetComponent<Rigidbody>().AddForce(windDirection, ForceMode.Acceleration);
    }
    
}
