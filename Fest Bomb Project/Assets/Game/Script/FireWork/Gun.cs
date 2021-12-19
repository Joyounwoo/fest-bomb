using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField]
    private Bullet m_bulletPrefab;
    [SerializeField]
    private float m_bulletSpeed = 60f;
    [SerializeField]
    private Transform m_bulletFirePos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        FireBullet();
    }

    private void FireBullet()
    {
        var bullet = Instantiate(m_bulletPrefab, m_bulletFirePos.transform.position, Quaternion.Euler(Vector3.zero));
        Vector3 mPosition = Input.mousePosition;
        Vector3 oPosition = transform.position;

        mPosition.z = oPosition.z - Camera.main.transform.position.z;

        Vector3 target = Camera.main.ScreenToWorldPoint(mPosition);

        float dy = target.y - oPosition.y;
        float dx = target.x - oPosition.x;

        bullet.Init(new Vector2(dx, dy).normalized*m_bulletSpeed);
    }
}
