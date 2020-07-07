using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class DeadMenu : MonoBehaviour
{
    private static GameObject   _deadMenu;
    private static Text         _coins;

    private void Start()
    {
        _deadMenu = GameObject.Find("DeadMenu").gameObject;
        _deadMenu.SetActive(false);

        //_coins = GameObject.Find("Coins").GetComponent<Text>();
    }

    public void Restart()
    {
        SceneManager.LoadScene(1);
    }

    public void Menu()
    {
        SceneManager.LoadScene(0);
    }

    public static void ActiveDeadMenu()
    {
        _deadMenu.SetActive(true);
    }
}
