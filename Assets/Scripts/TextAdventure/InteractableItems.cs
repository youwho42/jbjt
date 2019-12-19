using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableItems : MonoBehaviour
{
    public List<InteractableObject> usableItemList;

    public Dictionary<string, string> examineDictionary = new Dictionary<string, string>();
    public Dictionary<string, string> takeDictionary = new Dictionary<string, string>();

    [HideInInspector]
    public List<string> nounsInRoom = new List<string>();

    Dictionary<string, ActionResponse> useDictionary = new Dictionary<string, ActionResponse>();
    public List<string> nounsInInventory = new List<string>();

    GameController controller;

    private void Awake()
    {
        controller = GetComponent<GameController>();
    }

    public string GetObjectsNotInInventory(Room currentRoom, int i)
    {
        InteractableObject interactableInRoom = currentRoom.interactableObjectsInRoom[i];

        if (!nounsInInventory.Contains(interactableInRoom.noun))
        {
            nounsInRoom.Add(interactableInRoom.noun);
            return interactableInRoom.description;
        }
        return null;
    }

    public void AddActionResponsesToUseDictionary()
    {
        for (int i = 0; i < nounsInInventory.Count; i++)
        {
            string noun = nounsInInventory[i];
            InteractableObject interactableObjectInInventory = GetInteractableObjectFromUsableList(noun);
            if(interactableObjectInInventory == null)
            {
                continue;
            }
            for (int j = 0; j < interactableObjectInInventory.interactions.Length; j++)
            {
                Interaction interaction = interactableObjectInInventory.interactions[j];

                if (interaction.actionResponse == null) { 
                    controller.DisplayInventoryText();
                    continue;
                }

                if (!useDictionary.ContainsKey(noun))
                {
                    useDictionary.Add(noun, interaction.actionResponse);
                    controller.DisplayInventoryText();
                }
            }
        }
    }

    InteractableObject GetInteractableObjectFromUsableList(string noun)
    {
        for (int i = 0; i < usableItemList.Count; i++)
        {
            if(usableItemList[i].noun == noun)
            {
                return usableItemList[i];
            }
        }
        return null;
    }

    public void DisplayInventory()
    {
        controller.LogStringWithReturn("You look in your backpack, inside there is: ");
        for (int i = 0; i < nounsInInventory.Count; i++)
        {
            controller.LogStringWithReturn(nounsInInventory[i]);
        }
    }

    public void ClearCollections()
    {
        examineDictionary.Clear();
        takeDictionary.Clear();
        nounsInRoom.Clear();
    }

    public Dictionary<string, string> Take(string[] separatedInputWords)
    {
        string noun = separatedInputWords[1];
        if (nounsInRoom.Contains(noun))
        {
            nounsInInventory.Add(noun);
            AddActionResponsesToUseDictionary();
            nounsInRoom.Remove(noun);
            
            return takeDictionary;
        }
        else
        {
            controller.LogStringWithReturn("There is no " + noun + " here to take.");
            return null;
        }
    }

    

    public void UseItem(string[] separatedInputWords)
    {
        string nounToUse = separatedInputWords[1];

        if (nounsInInventory.Contains(nounToUse))
        {
            if (useDictionary.ContainsKey(nounToUse))
            {
                bool actionResult = useDictionary[nounToUse].DoActionResponse(controller);
                if (!actionResult)
                {
                    controller.LogStringWithReturn("Hmm, nothing is happening.");
                }
                else
                {
                    if (useDictionary[nounToUse].oneUse)
                    {
                        nounsInInventory.Remove(nounToUse);
                        controller.DisplayInventoryText();
                    }
                    
                }
            }
            else
            {
                controller.LogStringWithReturn("You can't use the " + nounToUse + ".");
            }
        }
        else
        {
            controller.LogStringWithReturn("There is no " + nounToUse + " in your inventory to use");
        }
    }
}
