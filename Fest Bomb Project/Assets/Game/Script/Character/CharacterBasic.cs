using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBasic : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D m_rigidbody2D;
    public float MoveSpeed;
    public float MaxSpeed;
    private Vector2 m_inputVelocity;

    [SerializeField]
    protected CharacterAnimator m_characterAnimator;
    // Start is called before the first frame update

    [SerializeField]
    private bool m_isDead;

    protected virtual void Start()
    {
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        //Move();
    }

    protected virtual void FixedUpdate()
    {
        Move();

        if (m_isDead)
            Dead();

        Vector3 newPos = transform.position;
        newPos.z = newPos.y;
        transform.position = newPos;
    }

    public void SetMoveInput(Vector2 inputVelocity)
    {
        m_inputVelocity = inputVelocity.normalized;
    }

    protected virtual void Move()
    {
        Vector2 oldVelocity = m_rigidbody2D.velocity;

        if (m_rigidbody2D.velocity.magnitude < MaxSpeed)
            m_rigidbody2D.AddForce(m_inputVelocity*MoveSpeed*Time.deltaTime);
        
        // Animation
        if (m_characterAnimator)
        {
            bool isWalk = m_inputVelocity.magnitude > 0.1;
            m_characterAnimator.SetWalk(isWalk);
            if (isWalk)
            {
                if (m_inputVelocity.x > 0)
                    m_characterAnimator.SetLookLeft(false);
                else if (m_inputVelocity.x < 0)
                    m_characterAnimator.SetLookLeft(true);
                m_characterAnimator.Animator.speed = m_rigidbody2D.velocity.magnitude*2f;
            }
            else
            {
                m_characterAnimator.Animator.speed = 1f;
            }
        }
    }
    public void Push(Vector2 velocity)
    {
        m_rigidbody2D.AddForce(velocity);
    }
    
    public void SetDead() { m_isDead = true; Dead(); }
    public virtual void Dead()
    {
        var spriteRenderers = m_characterAnimator.GetComponentsInChildren<SpriteRenderer>();
        foreach(var renderer in spriteRenderers)
        {
            var createPos = renderer.transform.position;
            createPos.y = transform.position.y;
            float stuffZ = renderer.transform.position.y - transform.position.y;
            var deadBody = Instantiate(CharacterManager.CharacterDeadBody, createPos, renderer.transform.rotation);
            deadBody.SpriteRenderer.sprite = renderer.sprite;
            deadBody.SpriteRenderer.color = renderer.color;
            deadBody.SpriteRenderer.gameObject.transform.localScale = Vector3.one;
            deadBody.MoveVelocity = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0f);
            deadBody.StuffZ = stuffZ;
            deadBody.StuffZSpeed = Random.Range(-0.5f, 4f);
        }
        Destroy(gameObject);
    }
}
