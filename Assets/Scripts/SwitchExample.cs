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
                Debug.Log("Se�im 0: Ba�lang��!");
                break;
            case 1:
                Debug.Log("Se�im 1: Devam ediyoruz...");
                break;
            case 2:
                Debug.LogWarning("Se�im 2: Uyar� �rne�i.");
                break;
            case 3:
                Debug.LogError("Se�im 3: Hata �rne�i!");
                break;
            default:
                Debug.Log("Bilinmeyen se�im.");
                break;
        }
    }
}