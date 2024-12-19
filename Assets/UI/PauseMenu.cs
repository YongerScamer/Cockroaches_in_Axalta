using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pausePanel; // Ссылка на панель паузы
    private bool isPaused = false;

    void Update()
    {
        // Открываем или закрываем меню паузы по нажатию Esc
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
                ResumeGame();
            else
                PauseGame();
        }
    }

    public void ResumeGame()
    {
        pausePanel.SetActive(false); // Скрываем панель
        Time.timeScale = 1f; // Возобновляем время
        isPaused = false;
        Cursor.lockState = CursorLockMode.Locked; // Прячем курсор
        Cursor.visible = false;
    }

    public void PauseGame()
    {
        pausePanel.SetActive(true); // Показываем панель
        Time.timeScale = 0f; // Останавливаем время
        isPaused = true;
        Cursor.lockState = CursorLockMode.None; // Показываем курсор
        Cursor.visible = true;
    }

    public void ExitGame()
    {
        // Выход из игры (в редакторе Unity не работает)
        Application.Quit();
        // Для отладки в редакторе можно загрузить сцену меню
        // SceneManager.LoadScene("MainMenu");
    }
}
