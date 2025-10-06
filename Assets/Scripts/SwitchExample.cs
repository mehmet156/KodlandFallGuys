using UnityEngine;

public class SwitchExample : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0)) HandleChoice(0);
        if (Input.GetKeyDown(KeyCode.Alpha1)) HandleChoice(1);
        if (Input.GetKeyDown(KeyCode.Alpha2)) HandleChoice(2);
        if (Input.GetKeyDown(KeyCode.Alpha3)) HandleChoice(3);
    }

    void HandleChoice(int value)
    {
        switch (value)
        {
            case 0:
                Debug.Log("Seçim 0: Baþlangýç!");
                break;
            case 1:
                Debug.Log("Seçim 1: Devam ediyoruz...");
                break;
            case 2:
                Debug.LogWarning("Seçim 2: Uyarý örneði.");
                break;
            case 3:
                Debug.LogError("Seçim 3: Hata örneði!");
                break;
            default:
                Debug.Log("Bilinmeyen seçim.");
                break;
        }
    }
}