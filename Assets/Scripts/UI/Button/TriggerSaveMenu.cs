using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TriggerSaveMenu : MonoBehaviour
{
    [SerializeField] private GameObject saveGameMenu;
    [SerializeField] private Button btnTrigger;
    private int health;
    [SerializeField] private float fillTime = 10;
    [SerializeField] private Image[] hearts;
    [SerializeField] private Sprite fullHeart;
    [SerializeField] private Sprite emptyHeart;
    [SerializeField] private TextMeshProUGUI keysNumber;
    [SerializeField] private TextMeshProUGUI booksNumber;
    private const int maxOfHeart = 5;

    private void ShowHeart()
    {
        health = HealthManager.health;
        keysNumber.text = "" + ItemCollector.keys;
        booksNumber.text = "" + ItemCollector.books;
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }
            if (i < maxOfHeart)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }


    private void SaveMenu()
    {
       saveGameMenu.SetActive(true);
        ShowHeart();
       Time.timeScale = 0f;
            //GameIsPause = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            if (ItemCollector.books >= 1)
            {
                btnTrigger.onClick.AddListener(() => SaveMenu());
            }
        }
    }
}
