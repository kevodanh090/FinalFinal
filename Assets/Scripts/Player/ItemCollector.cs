using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI keysNumber;
    [SerializeField] private TextMeshProUGUI booksNumber;
    public static int keys;
    public static int books;
    private bool isKey;
    private bool isBook;
    private void Awake()
    {
      isKey = default;
      isBook = default;
    }
    private void Update()
    {
        keysNumber.text = "" + keys;
        booksNumber.text = "" + books;
    }
    private async void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.CompareTag("Key"))
        {   
            isKey = true;
            Destroy(collision.gameObject);
            keys++;
            
        } if (collision.gameObject.CompareTag("Book"))
        {
            isBook = true;
            Destroy(collision.gameObject);
            books++;
            
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Key"))
        {
            isKey = false;
        }  
        if (collision.gameObject.CompareTag("Book"))
        {
            isBook = false;
        }


    }
}
