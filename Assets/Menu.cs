using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Метод для кнопки Play
    public void PlayGame()
    {
        // Загрузка первого уровня (сцены)
        SceneManager.LoadScene("Level_1"); // Укажите индекс или название вашей сцены
    }

    // Метод для кнопки Exit
    public void ExitGame()
    {
        // Выход из приложения
        Debug.Log("Game is exiting..."); // Для отладки, это сообщение будет видно в консоли Unity
        Application.Quit();
    }
}
