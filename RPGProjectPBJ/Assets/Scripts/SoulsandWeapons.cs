using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoulsandWeapons : MonoBehaviour
{
    public int soulCount;
    
    public bool heal;
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
        if(collision.gameObject.tag == "Player")
        {
            uiZone.gameObject.SetActive(true);
            SlimeController player = collision.gameObject.GetComponent<SlimeController>();
            if (heal)
            {
                player.SoulHeal(soulCount);
                Destroy(gameObject);
            }
            else if(!heal)
            {
                player.Weapons(soulCount);
                Destroy(gameObject);
            }
            
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            uiZone.gameObject.SetActive(false);
           
        }
    }


}
