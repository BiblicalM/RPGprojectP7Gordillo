using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class PlayerInputManager : MonoBehaviour
{
    public GameObject Controller;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Corpse")
        {
            Destroy(Controller.GetComponent<MonoBehaviour>());
            MonoBehaviour HostController = other.GetComponent<Corpse>().HostBehavior;
            
        }
    }
}

