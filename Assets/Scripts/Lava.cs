using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour
{
    [SerializeField] float growthSpeed = 0.8f;
    Vector3 startScale, startPosition;
    PlayerRespawn respawn;
    bool isRising = false;// iki deðer alan deðiþiken
    void Start()
    {
        startScale = transform.localScale;
        startPosition = transform.position;
    }

    void Update()
    {
        if (isRising)
        {
            transform.localScale += new Vector3(0f, growthSpeed * Time.deltaTime, 0f);// lavýn büyümesi iiçin
            transform.position += new Vector3(0f, growthSpeed * Time.deltaTime / 2f, 0f);
        }
          
    }
    public void StartLava()
    {
        isRising = true;
    }

    public void StopLava()
    {
        isRising = false;
        transform.localScale = startScale;
        transform.position = startPosition;
    }

    void OnCollisionEnter(Collision collision)// dokunduðunda çalýþýr
    {
        if (collision.gameObject.CompareTag("Player"))// eðer tagi player olan obje dokunursa
        {
            var respawn = collision.gameObject.GetComponent<PlayerRespawn>();//
            respawn.health -= 10;
            Destroy(respawn.weapon);    
            respawn.Respawn();//
            StopLava();

        }
    }
}