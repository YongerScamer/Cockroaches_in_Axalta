using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pausePanel; // ������ �� ������ �����
    private bool isPaused = false;

    void Update()
    {
        // ��������� ��� ��������� ���� ����� �� ������� Esc
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
        pausePanel.SetActive(false); // �������� ������
        Time.timeScale = 1f; // ������������ �����
        isPaused = false;
        Cursor.lockState = CursorLockMode.Locked; // ������ ������
        Cursor.visible = false;
    }

    public void PauseGame()
    {
        pausePanel.SetActive(true); // ���������� ������
        Time.timeScale = 0f; // ������������� �����
        isPaused = true;
        Cursor.lockState = CursorLockMode.None; // ���������� ������
        Cursor.visible = true;
    }

    public void ExitGame()
    {
        // ����� �� ���� (� ��������� Unity �� ��������)
        Application.Quit();
        // ��� ������� � ��������� ����� ��������� ����� ����
        // SceneManager.LoadScene("MainMenu");
    }
}
