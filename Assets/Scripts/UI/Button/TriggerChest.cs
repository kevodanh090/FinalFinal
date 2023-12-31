
using UnityEngine;
using UnityEngine.UI;

public class TriggerChest : MonoBehaviour
{
    [SerializeField] private GameObject[] itemDrop;
    [SerializeField] private Animator animator;
    [SerializeField] private Button btnTrigger;
    
    public bool IsOpened
    {
        get { return isOpened; }
        set
        {
            isOpened = value;
            animator.SetBool("IsOpened", isOpened);
        }
    }
    private bool isOpened;

    private void Awake()
    {
        Init();
    }
    private void Init()
    {
        isOpened = false;
    }

    private void OpenChest()
    {
        if ((isOpened && ItemCollector.keys <= 0) || ItemCollector.keys <= 0)
        {
            
            return;
        }
        
        else
        {

            
            IsOpened = true;
            ItemCollector.keys--;
            ShowItem();
            //Instantiate(itemDrop, transform.position,Quaternion.identity);
            
            Debug.Log($"keys = {ItemCollector.keys}");
        }
            

    }
    private void ShowItem()
    {
        foreach (var item in itemDrop)
        {
            if(item == null)
            {
                return;
            }
            item.SetActive(true);
        }
    }
 


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            
            btnTrigger.onClick.AddListener(() => OpenChest());
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            isOpened = true;
           // HideItem();
    }
}
