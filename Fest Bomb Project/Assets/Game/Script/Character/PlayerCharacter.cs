using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : CharacterBasic
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Zombie")
        {
            SetDead();
        }
    }
}
