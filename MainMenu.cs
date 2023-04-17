using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Mainkan()
    {
        SceneManager.LoadScene("Battle");
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Seting()
    {
        SceneManager.LoadScene("Setting");
    }

    public void main()
    {
        SceneManager.LoadScene("Menu");
    }

    public AudioSource Backsound;

    public void backsoundOnOff()
    {
        AudioSource bgSound = Backsound.GetComponent<AudioSource>();

        if (bgSound.mute == true)
        {
            bgSound.mute = false;
        }
        else
        {
            bgSound.mute = true;
        }
    }
}