using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLook : MonoBehaviour
{
    public float mouseSensitivity = 100f; // sensibilitatea miscarii mouse-ului
    public Transform playerBody; // referinta la corpul jucatorului
    private float xRotation = 0f; // rotire pe axa X (sus-jos)

    void Start()
    {
        // ascundem cursorul si il blocam pe ecran
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // captam input-ul mouse-ului
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // rotire pe axa X (privire sus/jos)
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // limitam rotirea intre -90 si 90 de grade

        // aplicam rotirea pe axa X
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // rotire pe axa Y (stanga-dreapta) aplicata corpului jucatorului
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
