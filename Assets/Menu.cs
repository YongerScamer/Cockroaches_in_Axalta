using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // ����� ��� ������ Play
    public void PlayGame()
    {
        // �������� ������� ������ (�����)
        SceneManager.LoadScene("SampleScene"); // ������� ������ ��� �������� ����� �����
    }

    // ����� ��� ������ Exit
    public void ExitGame()
    {
        // ����� �� ����������
        Debug.Log("Game is exiting..."); // ��� �������, ��� ��������� ����� ����� � ������� Unity
        Application.Quit();
    }
}
