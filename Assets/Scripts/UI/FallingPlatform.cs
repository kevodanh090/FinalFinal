using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    private float fadeDelay = 1.5f;
    [SerializeField] private GameObject targetObject;
    private bool _isFading;
    private void Awake()
    {
       
        _isFading = default;
        
    }
    private void Update()
    {
      
       
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (_isFading) { return; }
    //    if (collision.tag == "Player")
    //    {
    //        Debug.Log(_isFading);
    //        StartCoroutine(Fade());
    //        _isFading = false;
    //    }
    //}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (_isFading) { return; }
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(Fade());
            _isFading = false;

        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {

            StartCoroutine(Appear());
        }
    }
    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    if (collision.tag == "Player")
    //    {
    //        _isFading = false;
            
    //    }
    //}


    private IEnumerator Fade()
    {
        _isFading = true;
        yield return new WaitForSeconds(fadeDelay);
        targetObject.SetActive(false);


    }
    private IEnumerator Appear()
    {
        
        yield return new WaitForSeconds(fadeDelay);
        _isFading = false;
        targetObject.SetActive(true);


    }

}
