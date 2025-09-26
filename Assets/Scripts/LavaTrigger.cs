using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaTrigger : MonoBehaviour
{
    public enum TriggerType { Start, End , Middle }// 
    public TriggerType triggerType;
    public Lava lava;
        
    private void OnTriggerEnter(Collider other)// bir collider i�ine ge�ti�i zaman �al���r
    {
       
        if (!other.CompareTag("Player")) return;//

        if (triggerType == TriggerType.Start)
        {
            lava.StartLava();
        }
        else if (triggerType == TriggerType.End)
        {
            lava.StopLava();
        }
    }
}
