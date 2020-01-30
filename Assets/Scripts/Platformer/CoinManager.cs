using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public List<PickUpItem> coinPickUps = new List<PickUpItem>();

   
    private void Start()
    {
        if (coinPickUps.Count > 0)
        {
            int num = Random.Range(0, coinPickUps.Count);
            coinPickUps[num].hasCoin = true;
        }
    }
}
