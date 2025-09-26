using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallManager : MonoBehaviour
{
    [SerializeField] GameObject[] plates;// gameobject dizi 
    [SerializeField] int platesCount;// Tam say� olarak zeminlerin say�s�
    [SerializeField] int platesLength;//zeminlerin uzunlu�u
    private void Start()
    {

        //e�er plate uzunlu�u < i    i+ plate say�s� b�l� plate uzunlu�u
        for (var i = 0; i < plates.Length; i += (plates.Length / platesLength))
        {                          
            var x = Random.Range(i, i + platesCount);
            plates[x].gameObject.GetComponent<Rigidbody>().isKinematic = true;
            
        }

      

    }
}
