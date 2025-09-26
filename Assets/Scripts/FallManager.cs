using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallManager : MonoBehaviour
{
    [SerializeField] GameObject[] plates;// gameobject dizi 
    [SerializeField] int platesCount;// Tam sayý olarak zeminlerin sayýsý
    [SerializeField] int platesLength;//zeminlerin uzunluðu
    private void Start()
    {

        //eðer plate uzunluðu < i    i+ plate sayýsý bölü plate uzunluðu
        for (var i = 0; i < plates.Length; i += (plates.Length / platesLength))
        {                          
            var x = Random.Range(i, i + platesCount);
            plates[x].gameObject.GetComponent<Rigidbody>().isKinematic = true;
            
        }

      

    }
}
