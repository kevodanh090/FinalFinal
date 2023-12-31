using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TrapManager : MonoBehaviour
{
    private static TrapManager Instance = null;
    [SerializeField] private GameObject platformPrefab;
    [SerializeField] private Transform transform1;
    [SerializeField] private Transform transform2;


    private void Awake()
    {
        if (Instance == null) { 
            Instance = this;
        }else if(Instance != this) { 
            Destroy(gameObject);
        }
        
    }
    private void Start()
    {
        Instantiate(platformPrefab, transform1.position, platformPrefab.transform.rotation);
        Instantiate(platformPrefab, transform2.position, platformPrefab.transform.rotation);
    }
    IEnumerator SpawnPlatform(Vector3 spawPosition)
    {
        yield return new WaitForSeconds(2f);
        Instantiate(platformPrefab, spawPosition, platformPrefab.transform.rotation);
    }
    
}
