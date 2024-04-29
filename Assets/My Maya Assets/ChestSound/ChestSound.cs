using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestSound : MonoBehaviour
{

    public AudioClip openSound;
    public AudioClip creak_open;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            gameObject.GetComponent<AudioSource>().PlayOneShot(openSound);
            gameObject.GetComponent<AudioSource>().PlayOneShot(creak_open);

        }
    }
}
