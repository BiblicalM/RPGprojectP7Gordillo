using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSwitch : MonoBehaviour
{

    public GameObject character;
    public GameObject currentCharacter;
    public List<GameObject> otherCharacters;
    public GameObject corpse;
    
    public int selectCharacter;
    public bool switchCharacter;
    // Start is called before the first frame update
    void Start()
    {
        currentCharacter = character;
        if(character == null && otherCharacters.Count >= 1)
        {
            character = otherCharacters[0];
            currentCharacter = character;

        }
        SwapCharacter();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && switchCharacter)
         {
             if(selectCharacter == 0)
             {
                 selectCharacter = otherCharacters.Count - 1;
             }
             else
             {
                 selectCharacter -= 1;
             }
             SwapCharacter();
             if(corpse != null)
            {
                Destroy(corpse);
            }
            else
            {
                return;
            }

         }
        
    }

    public void SwapCharacter()
    {
        character = otherCharacters[selectCharacter];
        character.GetComponent<SlimeController>().enabled = true;
        character.SetActive(true);
        character.transform.position = currentCharacter.transform.position;
        currentCharacter = character;
        for (int i = 0; i < otherCharacters.Count; i++)
        {
            if (otherCharacters[i] != character)
            {
                otherCharacters[i].GetComponent<SlimeController>().enabled = false;
                otherCharacters[i].SetActive(false);
            }
        }
    }
}
