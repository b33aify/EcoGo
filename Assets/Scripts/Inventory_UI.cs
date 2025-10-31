using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;
using Image = UnityEngine.UI.Image;

public class Inventory_UI : MonoBehaviour
{
    public TextMeshProUGUI coinText;
    public TextMeshProUGUI popuptext;
    public Button PayButton;
    public KeyCode payKey = KeyCode.P;
    public Player_Inventory player_Inventory;
    public WaterfallTrigger trigger;
    public Image Fesh;
    public Image Fox;
    void Start()
    {
        coinText = GetComponent<TextMeshProUGUI>();
        popuptext = GetComponent<TextMeshProUGUI>();
        PayButton.onClick.AddListener(PayCoins);
        PayButton.gameObject.SetActive(false);
        Fesh = GetComponent<Image>();
        Fox = GetComponent<Image>();
    }

    public void UpdateCoinText(Player_Inventory player_Inventory)
    {
        coinText.text = player_Inventory.NumberOfCoins.ToString(); 
    }

    public void UpdateImage(Player_Inventory player_Inventory)
    {
        
        if (player_Inventory.NumberOfFish > 0) 
        {
            SetImageTransparency(Fesh, 255f); 
        }
        if (player_Inventory.NumberOfFox > 0)
        {
            SetImageTransparency(Fox, 255f);
        }
    }

    public void SetImageTransparency(Image image, float alpha)
    {
        var color = Fesh.color;
        color.a = 1f;
        Fesh.color = color; 
        var color1 = Fox.color;
        color1.a = 1f; 
        Fox.color = color1; 

    }

    public void SetTextTransparency(TextMeshProUGUI textMeshProUGUI, float alpha)
    {
        var color = textMeshProUGUI.color;
        color.a = 1f; 
        textMeshProUGUI.color = color; 
    }
    public void HideTextIfFishCollected()
    {
        popuptext.gameObject.SetActive(false);
        PayButton.gameObject.SetActive(false);  
    }
    
    public void UpdatePopupText()
    {
        SetTextTransparency(popuptext, 1f); 
        PayButton.gameObject.SetActive(true);
    }
    void Update()
    {
        
        if (Input.GetKeyDown(payKey))
        {
            if (PayButton.gameObject.activeSelf) 
            {
                Debug.Log("P key pressed. Invoking button click.");
                PayButton.onClick.Invoke(); 
            }
        }
    }
    public void PayCoins()
    {
        if (player_Inventory.NumberOfCoins >= 10)
        {
            player_Inventory.ModifyCoins(-10);

            if (player_Inventory.NumberOfCoins == 0)
            {
                popuptext.gameObject.SetActive(false);
                PayButton.gameObject.SetActive(false);

                SceneManager.LoadScene(trigger.sceneToLoad);
            }

            else
            {
                Debug.Log("Not enough coins to pay!");
            }
        }
    }
}
