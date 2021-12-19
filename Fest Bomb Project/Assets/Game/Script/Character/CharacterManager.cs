using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    [SerializeField]
    private CharacterDeadBody m_caracterDeadBody;
    public static CharacterDeadBody CharacterDeadBody;

    private void Start() {
        CharacterDeadBody = m_caracterDeadBody;
    }
}
