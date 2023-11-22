using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitInimigo : MonoBehaviour
{
    Movimento_inimigo _moveInim;
    public GameObject _particDead, _particRestart; 
    private void Start()
    {
        _moveInim = GetComponent<Movimento_inimigo>();
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Hit");
        if (other.gameObject.CompareTag("PlayerAttack"))
        {

            StartCoroutine(Morte());
        }
    }

    IEnumerator Morte()
    {
        _moveInim._checkMove = false;
        _particDead.SetActive(true);
        yield return new WaitForSeconds(1);
        gameObject.SetActive(false);
    }

    private void Reset()
    {
        
    }
}
