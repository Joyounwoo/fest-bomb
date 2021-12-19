using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject FireWorks;
    public Rigidbody2D Rigidbody2D;

    public void Init(Vector2 moveVelocity)
    {
        Rigidbody2D.AddForce(moveVelocity);
    }
// Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DoDestroy(4f));
    }

    IEnumerator DoDestroy(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Zombie")
        {
            Instantiate(FireWorks, transform.position, transform.rotation);
            Destroy(gameObject);
            other.GetComponent<CharacterBasic>().SetDead();
        }
    }
}
