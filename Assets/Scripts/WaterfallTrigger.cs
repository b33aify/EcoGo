using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEditor.Timeline.TimelinePlaybackControls;

public class WaterfallTrigger : MonoBehaviour
{
    public Player_Inventory player_Inventory;
    public Inventory_UI inventory_UI;
    public string sceneToLoad = "Main";
    void Start()
    {
        if (inventory_UI == null)
        {
            inventory_UI = GameObject.Find("popuptext").GetComponent<Inventory_UI>();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (player_Inventory.HasFish)
            {
                SceneManager.LoadScene(sceneToLoad);
            }
            else
            {
                inventory_UI.UpdatePopupText();
            }
        }
    }
    private void Update()
    {
        if (player_Inventory.NumberOfFish > 0 && inventory_UI.popuptext.color.a > 0f)
        {
            inventory_UI.HideTextIfFishCollected();
        }
    }
}
