using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAnimation : MonoBehaviour
{
    [SerializeField] private Animator myDoor = null;
    [SerializeField] private bool openTrigger = false;

    private bool isOpen = false;

    void Update()
    {
        // Toggle the door state when 'E' key is pressed
        if (Input.GetKeyDown(KeyCode.E))
        {
            ToggleDoor();
        }
    }

    void ToggleDoor()
    {
        // Toggle the door state
        isOpen = !isOpen;

        // Set the appropriate trigger based on the door state
        if (isOpen)
        {
            myDoor.SetTrigger("Open");
        }
        else
        {
            myDoor.SetTrigger("Close");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // If the collider is tagged as "Player" and openTrigger is enabled, open the door
        if (other.CompareTag("Player") && openTrigger)
        {
            OpenDoor();
        }
    }

    // Open the door when triggered
    void OpenDoor()
    {
        if (myDoor != null)
        {
            myDoor.SetTrigger("Open");
            isOpen = true;
        }
    }

    // Close the door when triggered
    private void OnTriggerExit(Collider other)
    {
        // If the collider is tagged as "Player" and the door is currently open, close the door
        if (other.CompareTag("Player") && isOpen)
        {
            ToggleDoor();
        }
    }
}