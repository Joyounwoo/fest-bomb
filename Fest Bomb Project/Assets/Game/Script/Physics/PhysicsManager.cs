using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsManager : MonoBehaviour
{
    [SerializeField]
    private float m_globalFriction = 0.05f;
    public static float GlobalFriction;
    
    [SerializeField]
    private PhysicsStuff m_physicsStuffOrigin;
    public static PhysicsStuff PhysicsStuffOrigin;


    // Start is called before the first frame update
    void Start()
    {
        GlobalFriction = m_globalFriction;
        PhysicsStuffOrigin = m_physicsStuffOrigin;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        GlobalFriction = m_globalFriction;
    }
}
