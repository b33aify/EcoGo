using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float turnSpeed;

    private Animator animator;
    private CharacterController characterController;

    public AudioSource footstepAudio; // Referința la componenta AudioSource
    private bool isMoving = false;    // Starea mișcării

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        if (footstepAudio == null)
        {
            footstepAudio = GetComponent<AudioSource>();
        }
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        // Get input values
        float moveInput = Input.GetAxis("Vertical");
        float turnInput = Input.GetAxis("Horizontal");

        // Compute movement direction
        Vector3 moveDirection = transform.forward * moveInput * speed;

        // Move the player using CharacterController
        if (characterController != null)
        {
            characterController.Move(moveDirection * Time.deltaTime);
        }

        // Rotate the player
        transform.Rotate(Vector3.up, turnInput * Time.deltaTime * turnSpeed);

        // Update animation
        animator.SetFloat("Speed", moveInput * speed);

        // Verifică dacă animația de mers este activă
        isMoving = animator.GetCurrentAnimatorStateInfo(0).IsName("Walk") || animator.GetCurrentAnimatorStateInfo(0).IsName("Swim");
        // Asigură-te că animația de mers se numește "Walking"

        //footstepAudio.Play();

        // Pornește sau oprește sunetul în funcție de mișcare
        if (isMoving && !footstepAudio.isPlaying)
        {
            footstepAudio.Play();
        }
        else if (!isMoving && footstepAudio.isPlaying)
        {
            footstepAudio.Stop();
        }
    }
}
