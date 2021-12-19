using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private bool m_isGameOver;
    private bool m_isGameClear;
    public float time;
    private void Start() {
        m_isGameOver = false;
        time = 0f;
    }
    private void Update() {
        time += Time.deltaTime;
        if (time > 120f)
        {
            SceneManager.LoadScene("03_Victory");
        }
    }
    public void GameOver()
    {
        if (m_isGameOver) return;

        m_isGameOver = true;
        StartCoroutine(DoReturnToMainMenu(3f));
    }

    public IEnumerator DoReturnToMainMenu(float time)
    {
        yield return new WaitForSeconds(time);
        
        SceneManager.LoadScene("01_Lobby");
    }
}
