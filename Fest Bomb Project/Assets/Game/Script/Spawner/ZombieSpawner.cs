using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    [SerializeField]
    private GameManager m_gameManager;
    [SerializeField]
    private CharacterBasic m_zombiePrefab;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DoSpawnZombie(0.02f + (100f - m_gameManager.time)/100f * 0.35f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator DoSpawnZombie(float time)
    {
        yield return new WaitForSeconds(time);
        SpawnZombie();
        StartCoroutine(DoSpawnZombie(0.02f + (100f - m_gameManager.time)/100f * 0.35f));
    }

    private void SpawnZombie()
    {
        if (m_zombiePrefab == null) return;
        
        var Player = GameObject.FindGameObjectWithTag("Player");
        if (Player == null) return;

        Vector2 spawnPos = transform.position;
        spawnPos.x += Random.Range(-transform.localScale.x/2f, transform.localScale.x/2f);
        spawnPos.y += Random.Range(-transform.localScale.y/2f, transform.localScale.y/2f);
        Instantiate(m_zombiePrefab, spawnPos, Quaternion.Euler(Vector3.zero));
    }
}
