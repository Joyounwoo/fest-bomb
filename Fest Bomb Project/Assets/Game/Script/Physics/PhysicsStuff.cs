using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsStuff : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D m_rigidbody2D;
    [SerializeField]
    private bool m_isGlobalFriction;
    [SerializeField]
    private float m_frictionValue;
    public SpriteRenderer SpriteRenderer;


    [Header("Stuff Z")]
    [SerializeField]
    private Transform m_stuffTransform;
    private float m_stuffZ;
    private float m_stuffZSpeed;
    public float StuffZ{
        set{
            Vector3 newPos = m_stuffTransform.localPosition;
            newPos.z = value;
            m_stuffTransform.localPosition = newPos;
        }
    }
    public float StuffZSpeed{set{
        m_stuffZSpeed = value;}}

    private void Start() {
        m_rigidbody2D.freezeRotation = true;
        m_stuffZSpeed = 0;
    }
    private void FixedUpdate()
    {
        if (m_isGlobalFriction)
        {
            Vector2 newVelocity = m_rigidbody2D.velocity * (1-PhysicsManager.GlobalFriction);
            m_rigidbody2D.velocity = newVelocity;
        }

        StuffZUpdate();
        
    }

    private void StuffZUpdate()
    {
        if (m_stuffTransform == null) return;


        m_stuffZSpeed -= 0.01f;
        m_stuffZSpeed = m_stuffZSpeed * (1f-0.2f);
        if (m_stuffTransform.localPosition.y > 0)
        {
            Vector3 newPos = m_stuffTransform.localPosition;

            newPos.y += m_stuffZSpeed;

            m_stuffTransform.localPosition = newPos;
        }
        else
        {
            m_stuffZSpeed = 0;
            m_stuffTransform.localPosition = Vector3.zero;
        }
    }
}
