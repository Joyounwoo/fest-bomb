using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCharacter : CharacterBasic
{
    protected override void Start()
    {
        base.Start();
        if (m_characterAnimator)
        {
            var spriteRenderers = m_characterAnimator.GetComponentsInChildren<SpriteRenderer>();
            foreach(var renderer in spriteRenderers)
            {
                renderer.color = Color.HSVToRGB(Random.Range(0f, 1f), 0.3f, 1f);
            }
        }
    }
    protected override void Update()
    {
        base.Update();
        var Player = GameObject.FindGameObjectWithTag("Player");
        if (Player)
        {
            Vector2 inputVelocity = Player.transform.position - transform.position;
            SetMoveInput(inputVelocity.normalized);
        }
    }
    // Update is called once per frame
    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }
}
