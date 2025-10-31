using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public AudioSource collectCoinSound; // Referința la AudioSource
    public AudioSource collectCoinSound1;
    void Start()
    {
        if (collectCoinSound == null)
        {
            // Încearcă să găsești AudioSource pe același GameObject
            collectCoinSound = GetComponent<AudioSource>();
        }
        if (collectCoinSound1 == null)
        {
            // Încearcă să găsești AudioSource pe același GameObject
            collectCoinSound1 = GetComponent<AudioSource>();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Player_Inventory player_Inventory = other.GetComponent<Player_Inventory>();
        //Player_Inventory2 player_Inventory2 = other.GetComponent<Player_Inventory2>();

        if (player_Inventory != null)
        {
            player_Inventory.CoinCollected();
            gameObject.SetActive(false);
        }

        

        if (other.CompareTag("Player")) // Verifică dacă playerul atinge obiectul
        {
            // Redă sunetul de colectare
            if (collectCoinSound != null)
            {
                collectCoinSound.Play();
            }
            if (collectCoinSound1 != null)
            {
                collectCoinSound1.Play();
            }
        }
    }
}
