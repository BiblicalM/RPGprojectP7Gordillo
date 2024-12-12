using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Corpse : MonoBehaviour
{
    public Image uiZone;
    
    // Start is called before the first frame update
    void Start()
    {
        uiZone.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            uiZone.gameObject.SetActive(true);
            collision.GetComponent<PlayerSwitch>().switchCharacter = true;
            
        }
        else
        {
            return;
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            uiZone.gameObject.SetActive(false);
            collision.GetComponent<PlayerSwitch>().switchCharacter = false;
        }
        else
        {
            return;
        }
    }
}
