using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public static PlayerInventory instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public List<GameObject> inventory = new List<GameObject>();

    public void Add(GameObject item)
    {
        inventory.Add(item);
    }

    public void Remove(GameObject item)
    {
        inventory.Remove(item);
    }
}
