using System.Threading.Tasks;
using UnityEngine.SceneManagement;

public class GameOver 
{
    public GameOver()
    {
        GameOverFlow();
    }
    private async void GameOverFlow()
    {
        await Task.Delay(1000);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
