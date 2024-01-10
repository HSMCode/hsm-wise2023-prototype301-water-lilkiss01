using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    private bool gameLost = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (croco.isAlive == false)
            {
                RestartGame();
            }
            else
            {
                
                MoveCharacterWithSpace();
            }
        }
    }

    
    public void LoseGame()
    {
        gameLost = true;
        
    }

    
    private void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    
    private void MoveCharacterWithSpace()
    {
        
    }
}