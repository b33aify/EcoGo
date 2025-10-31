using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{
    public float speed = 5f; // viteza de miscare a jucatorului
    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        // miscare pe axa X si Z
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // vector de miscare
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        // aplicam miscarea pe jucator
        rb.AddForce(movement * speed);
    }
}
