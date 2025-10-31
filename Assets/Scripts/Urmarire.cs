using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Urmarire : MonoBehaviour
{
    public Transform player; // referinta la obiectul jucatorului
    public Vector3 offset = new Vector3(0, 3, -2); // distanta dintre camera si jucator
    public float smoothSpeed = 0.125f; // viteza de urmarire (mai mica = urmarire mai lenta)
    private void LateUpdate()
    {
        // pozitia dorita a camerei (poziția jucătorului + offset-ul)
        Vector3 desiredPosition = player.position + player.TransformDirection(offset);

        // mișcăm camera lin între poziția curentă și poziția dorită
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // actualizăm poziția camerei
        transform.position = smoothedPosition;

        // setăm camera să privească întotdeauna către jucător
        transform.LookAt(player);
    }
}
