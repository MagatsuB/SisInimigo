using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitInimigo : MonoBehaviour
{
    Movimento_inimigo _moveInim;
    public GameObject _particDead, _particRestart;
    public MeshRenderer _meshren;
    public Collider _collider;
    private void Start()
    {
        _moveInim = GetComponent<Movimento_inimigo>();
        _meshren = GetComponent<MeshRenderer>();
        _collider = GetComponent<Collider>();
    }
    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Hit");
        if (other.gameObject.CompareTag("PlayerAttack"))
        {
            StartCoroutine(Morte());
            
        }
    }

    IEnumerator Morte()
    {
        
        _moveInim._checkMove = false;
        _particRestart.SetActive(true);
        _meshren.enabled = false;
        yield return new WaitForSeconds(1);
        _collider.enabled = false;
        _meshren.enabled = true;
        //_particDead.SetActive(false);
        gameObject.SetActive(false);
    }

    IEnumerator RestartTime()
    {
        _particRestart.SetActive(false);
        yield return new WaitForSeconds(1);
        _meshren.enabled = true;
        _collider.enabled = true;
        yield return new WaitForSeconds(0.5f);
        _moveInim._checkMove = true;
    }

    public void Restart()
    {
        StartCoroutine(RestartTime());
    }

}
