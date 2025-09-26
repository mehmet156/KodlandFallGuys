using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public Transform cameraTransform;
    public float mouseSense = 1;
    public float checkDistance = 0.5f;
    public float moveDownAmount = 1f;
    private Vector3 defaultCameraLocalPos;

    private float verticalRotation = 0f;//************************************
    public float verticalLimit;//******************************************
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        defaultCameraLocalPos = cameraTransform.localPosition;
    }

    void Update()
    {
        float rotateX = Input.GetAxis("Mouse X") * mouseSense;
        float rotateY = Input.GetAxis("Mouse Y") * mouseSense;
        Vector3 rotPlayer = transform.rotation.eulerAngles;
        rotPlayer.y += rotateX;
        transform.rotation = Quaternion.Euler(rotPlayer);

        //*******************************************************************
        // Kamerayý yukarý/aþaðý döndür
        verticalRotation -= rotateY;
        verticalRotation = Mathf.Clamp(verticalRotation, -verticalLimit, verticalLimit); // Aþýrý dönmeyi engelle
        cameraTransform.localRotation = Quaternion.Euler(verticalRotation, 0f, 0f);
        //*******************************************************************


        CheckCollisionAbove();
    }

    void CheckCollisionAbove()
    {
        RaycastHit hit;
        Vector3 checkPosition = gameObject.transform.position;

        if (Physics.Raycast(checkPosition, Vector3.up, out hit, checkDistance))
        {
            cameraTransform.localPosition = defaultCameraLocalPos - new Vector3(0, moveDownAmount, 0);
        }
        else
        {
            cameraTransform.localPosition = defaultCameraLocalPos;
        }
    }
}