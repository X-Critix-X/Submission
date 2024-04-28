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
        // Open the door when 'E' key is pressed
        if (Input.GetKeyDown(KeyCode.E) && !isOpen)
        {
            OpenDoor();
        }
    }

    void OpenDoor()
    {
        if (myDoor != null)
        {
            myDoor.SetTrigger("Open");
            isOpen = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // If the collider is tagged as "Player" and openTrigger is enabled
        if (other.CompareTag("Player") && openTrigger)
        {
            OpenDoor();
        }
    }

    // Close the door when another object exits the collider
    private void OnTriggerExit(Collider other)
    {
        if (isOpen)
        {
            myDoor.SetTrigger("Close");
            isOpen = false;
        }
    }
}