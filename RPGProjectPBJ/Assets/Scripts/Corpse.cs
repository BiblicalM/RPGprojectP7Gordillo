using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Corpse : MonoBehaviour
{
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.GetComponent<PlayerSwitch>().switchCharacter = true;
            
        }
        else
        {
            return;
        }

    }
}
