using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour
{
    [SerializeField] float growthSpeed = 0.8f;
    Vector3 startScale, startPosition;
    PlayerRespawn respawn;
    bool isRising = false;// iki de�er alan de�i�iken
    void Start()
    {
        startScale = transform.localScale;
        startPosition = transform.position;
    }

    void Update()
    {
        if (isRising)
        {
            transform.localScale += new Vector3(0f, growthSpeed * Time.deltaTime, 0f);// lav�n b�y�mesi ii�in
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

    void OnCollisionEnter(Collision collision)// dokundu�unda �al���r
    {
        if (collision.gameObject.CompareTag("Player"))// e�er tagi player olan obje dokunursa
        {
            var respawn = collision.gameObject.GetComponent<PlayerRespawn>();//
            respawn.health -= 10;
            Destroy(respawn.weapon);    
            respawn.Respawn();//
            StopLava();

        }
    }
}