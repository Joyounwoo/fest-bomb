using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimator : MonoBehaviour
{
    public Animator Animator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetWalk(bool value)
    {
        Animator.SetBool("Walk", value);
    }

    public void SetDamaged(bool value)
    {
        Animator.SetBool("Damaged", value);
    }

    public void SetLookLeft(bool value)
    {
        Animator.SetBool("IsLookLeft", value);
    }
}
