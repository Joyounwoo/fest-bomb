using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBomb : MonoBehaviour
{
    private bool m_isBombed;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DoDestroy(2f));
        m_isBombed = true;
    }

    IEnumerator DoDestroy(float time)
    {
        yield return new WaitForFixedUpdate();
            m_isBombed = false;
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Zombie" && m_isBombed)
        {
            Vector2 pushVelocity = other.transform.position - transform.position;
            other.GetComponent<CharacterBasic>().Push(pushVelocity.normalized*600f);
        }
    }
}
