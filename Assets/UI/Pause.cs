using UnityEngine;

public class Pause_Button : MonoBehaviour
{
    public GameObject panel;
    public void Pause()
    {
        panel.SetActive(false);
        Time.timeScale = 1f;
    }
}