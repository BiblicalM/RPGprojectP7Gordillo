using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLich : MonoBehaviour
{
    public GameObject fireBallProjectile;
    public AnimationClip idleAnim;
    public Transform castSpellPos;
    
    private Animator bossAnim;
    private bool castSpell;
    // Start is called before the first frame update
    void Start()
    {
        //should we make the fireball start at the beginning or no?
        castSpell = false;
        StartCoroutine(CastingTime());
        bossAnim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        FireBallCast();
    }
    IEnumerator CastingTime()
    {
        //cooldown to cast fireball
        yield return new WaitForSeconds(10);
        
        castSpell = true;
    }

    public void FireBallCast()
    {
        //if castSpell is true then spawn a fireball, then restart cooldown.
        if (castSpell)
        {
            bossAnim.SetTrigger("Fireball_trig");
            Instantiate(fireBallProjectile, castSpellPos.transform.position, fireBallProjectile.transform.rotation);
            castSpell = false;
            StartCoroutine(CastingTime());
            
        }
    }
}

