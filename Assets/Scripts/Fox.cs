using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fox : MonoBehaviour
{
    public AudioSource collectSound; // Referința la AudioSource
    void Start()
    {
        if (collectSound == null)
        {
            // Încearcă să găsești AudioSource pe același GameObject
            collectSound = GetComponent<AudioSource>();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Player_Inventory player_Inventory = other.GetComponent<Player_Inventory>();

        if (player_Inventory != null)
        {
            player_Inventory.FoxCollected();
            gameObject.SetActive(false);
        }
        if (other.CompareTag("Player")) // Verifică dacă playerul atinge obiectul
        {
            // Redă sunetul de colectare
            if (collectSound != null)
            {
                collectSound.Play();
            }
        }
    }
}