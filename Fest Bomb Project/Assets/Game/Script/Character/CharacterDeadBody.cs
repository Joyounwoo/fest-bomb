using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDeadBody : MonoBehaviour
{
    public SpriteRenderer SpriteRenderer;
    public Vector3 MoveVelocity;

    [Header("Stuff Z")]
    [SerializeField]
    private Transform m_stuffTransform;
    private float m_stuffZ;
    private float m_stuffZSpeed;
    public float StuffZ{
        set{
            Vector3 newPos = m_stuffTransform.localPosition;
            newPos.y = value;
            m_stuffTransform.localPosition = newPos;
        }
    }
    public float StuffZSpeed{set{
        m_stuffZSpeed = value;}}

    private void Start() {
        m_stuffZSpeed = 0;
        Color newColor = SpriteRenderer.color;
        newColor.a = 10f;
        SpriteRenderer.color = newColor;
    }

    private void Update() {
        transform.Translate(MoveVelocity*Time.deltaTime);
    }
    private void FixedUpdate()
    {
        StuffZUpdate();

        MoveVelocity *= 0.99f;
        Color newColor = SpriteRenderer.color;
        newColor.a -= 0.04f;
        SpriteRenderer.color = newColor;
        if (newColor.a < 0f)
        {
            Destroy(gameObject);
        }
    }

    private void StuffZUpdate()
    {
        if (m_stuffTransform == null) return;


        m_stuffZSpeed -= 0.005f;
        m_stuffZSpeed = m_stuffZSpeed * (1f-0.02f);
        if (m_stuffTransform.localPosition.y > 0)
        {
            Vector3 newPos = m_stuffTransform.localPosition;

            newPos.y += m_stuffZSpeed;

            m_stuffTransform.localPosition = newPos;
        }
        else
        {
            m_stuffZSpeed = -m_stuffZSpeed*0.6f;
            m_stuffTransform.localPosition = Vector3.zero;
        }
    }
}
