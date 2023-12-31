using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalGate : MonoBehaviour
{
    [SerializeField] private Transform gate;
    [SerializeField] GameObject player;
    private bool _isMoved;

    private void Awake()
    {
        Init();
    }
    private void Init()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        _isMoved = default;
    }
    private void Teleport()
    {
        if (_isMoved)
        {
            return;
        }
        
        if (Vector2.Distance(player.transform.position, transform.position) > 0.3f)
        {
            player.transform.position = gate.transform.position;
            _isMoved = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Teleport();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        _isMoved = false;
    }
}
