using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    bool gameHasEnded = false;

    public float restartDelay = 2.5f;

    public void EndGame()
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            Debug.Log("Game Over");
            Invoke("Restart", restartDelay);
        }
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Score.scoreValue = 0;
    }
}
