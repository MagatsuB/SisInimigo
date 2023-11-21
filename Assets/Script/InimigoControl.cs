using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.Pool;

public class InimigoControl : MonoBehaviour
{
    public Transform _alvoInicial;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Inimigo_1ON", 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Inimigo_1ON()
    {
        GameObject bullet = InimigoTipo1._SharedInstance.GetPooledObject();
        if (bullet != null)
        {
            // bullet.transform.position = turret.transform.position;
            bullet.GetComponent<Movimento_inimigo>()._player = _alvoInicial;
            bullet.SetActive(true);
        }
    }
}
