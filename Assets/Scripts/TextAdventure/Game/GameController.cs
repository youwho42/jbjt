using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public TMP_Text displayText;
    public TMP_Text actionsDisplayText;
    public TMP_Text inventoryDisplayText;
    public TMP_Text locationDisplayText;
    public TMP_InputField inputField;
    public Color inputFieldCaretColor;
    public InputAction[] inputActions;
    

    [HideInInspector]
    public RoomNavigation roomNavigation;
    [HideInInspector]
    public List<string> interactionDescriptionInRoom = new List<string>();
    [HideInInspector]
    public InteractableItems interactableItems;

    List<string> actionLog = new List<string>();
    
    private void Awake()
    {
        interactableItems = GetComponent<InteractableItems>();
        
        roomNavigation = GetComponent<RoomNavigation>();
    }

    private void Start()
    {
        DisplayRoomText();
        DisplayLoggedText();
        DisplayActionsText();
        DisplayInventoryText();
        DisplayLocation();

        inputField.caretColor = inputFieldCaretColor;
        inputField.caretWidth = 8;
    }

    public void DisplayLoggedText()
    {
        string logAsText = string.Join("\n", actionLog.ToArray());
        displayText.text = logAsText;
    }

    public void DisplayActionsText()
    {
        string joinedInputActionNouns = "Keywords:";
        for (int i = 0; i < inputActions.Length; i++)
        {
            joinedInputActionNouns += "\n" + inputActions[i].keyWord;
        }
        actionsDisplayText.text = joinedInputActionNouns;
    }

    public void DisplayInventoryText()
    {
        string joinedInputActionNouns = "Inventory:";
        
        for (int i = 0; i < interactableItems.nounsInInventory.Count; i++)
        {
            joinedInputActionNouns += "\n" + interactableItems.nounsInInventory[i];
        }
        inventoryDisplayText.text = joinedInputActionNouns;
    }

    public void DisplayLocation()
    {
        locationDisplayText.text = "Location: " + roomNavigation.currentRoom.roomName;
        if(roomNavigation.currentRoom == roomNavigation.finalRoom)
        {
            StartCoroutine(EndMiniGame());
        }
    }

    public void DisplayRoomText()
    {
        ClearCollectionsForNewRoom();

        UnpackRoom();

        string joinedInteractionDescriptions = string.Join("\n", interactionDescriptionInRoom.ToArray());
        string combinedText = roomNavigation.currentRoom.description + "\n" + joinedInteractionDescriptions;
        LogStringWithReturn(combinedText);
    }

    private void UnpackRoom()
    {
        roomNavigation.UnpackExitsInRoom();
        PrepareObjectsToTakeOrExamine(roomNavigation.currentRoom);
    }

    void PrepareObjectsToTakeOrExamine(Room currentRoom)
    {
        for (int i = 0; i < currentRoom.interactableObjectsInRoom.Length; i++)
        {
            string descriptionNotInInventory = interactableItems.GetObjectsNotInInventory(currentRoom, i);
            if (descriptionNotInInventory != null)
            {
                interactionDescriptionInRoom.Add(descriptionNotInInventory);
            }

            InteractableObject interactableInRoom = currentRoom.interactableObjectsInRoom[i];
            
            for (int j = 0; j < interactableInRoom.interactions.Length; j++)
            {
                Interaction interaction = interactableInRoom.interactions[j];
                if(interaction.inputAction.keyWord == "examine")
                {
                    interactableItems.examineDictionary.Add(interactableInRoom.noun, interaction.textResponse);
                }
                if (interaction.inputAction.keyWord == "take")
                {
                    interactableItems.takeDictionary.Add(interactableInRoom.noun, interaction.textResponse);
                    
                }
            }
        }
    }

    public string TestVerbDictionaryWithNoun(Dictionary<string, string> verbDictionary, string verb, string noun)
    {
        if (verbDictionary.ContainsKey(noun))
        {
            return verbDictionary[noun];
        }
        return "You can't " + verb + " " + noun;
    }

    void ClearCollectionsForNewRoom()
    {
        interactableItems.ClearCollections();
        interactionDescriptionInRoom.Clear();
        roomNavigation.ClearExits();
    }

    public void LogStringWithReturn(string stringToAdd)
    {
        actionLog.Add(stringToAdd + "\n");
    }

    IEnumerator EndMiniGame()
    {
       
        yield return new WaitForSeconds(5f);
        LevelManager.instance.ChangeLevel("Level 3");
    }
}
