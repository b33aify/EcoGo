using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player_Inventory : MonoBehaviour
{
    public int NumberOfCoins { get; private set; }
    public int NumberOfFish { get; private set; }
    public int NumberOfFox { get; private set; }

    public bool HasFish { get; private set; }

    public UnityEvent<Player_Inventory> OnCoinCollected;
    public UnityEvent<Player_Inventory> OnFishCollected;
    public UnityEvent<Player_Inventory> OnFoxCollected;
    public void CoinCollected()
    {
        NumberOfCoins++;
        OnCoinCollected.Invoke(this);
    }

    public void FishColected()
    {
        NumberOfFish++;
        OnFishCollected.Invoke(this);
        HasFish = true;
        
    }
    public bool CheckIfHasFish()
    {
        return HasFish;
    }

    public void FoxCollected()
    {
        NumberOfFox++;
        OnFoxCollected.Invoke(this);

    }
    public void ModifyCoins(int amount)
    {
        
        NumberOfCoins += amount;

        if (NumberOfCoins < 0)
        {
            NumberOfCoins = 0;
        }
    }
}
