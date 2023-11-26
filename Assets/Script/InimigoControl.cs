using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.Pool;

public class InimigoControl : MonoBehaviour
{
    public Transform _alvoInicial;
    public Transform _grupoInimigos;
    
    public List<GameObject> _inimigoList = new List<GameObject>();
    public List<GameObject> _inimigoListas = new List<GameObject>();
    
    [SerializeField] float _timeIni, _contador;
    bool _timeAtivo;

    public List<Transform> _pos1List = new List<Transform>();
    // Start is called before the first frame update
    void Start()
    {
        // nao necessario --> Invoke("Inimigo_1ON", 1);
        _timeIni = 3;
        _contador = _timeIni;
        _timeAtivo = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (_timeAtivo)
        {
            _contador -= Time.deltaTime;
            if (_contador < 0)
            {
                // _timeAtivo = false;
                _contador = _timeIni;
                Inimigo_1ON();
            }
        }
    }

    void Inimigo_1ON()
    {
        GameObject bullet = InimigoTipo1._SharedInstance.GetPooledObject();
        if (bullet != null)
        {
            int number = Random.Range(0, _pos1List.Count);
            bullet.transform.position = _pos1List[number].transform.position;
            //bullet.transform.SetParent(gameObject.transform);
            bullet.transform.SetParent(_grupoInimigos.transform);
            bullet.GetComponent<Movimento_inimigo>()._player = _alvoInicial;
            bullet.SetActive(true);
           bullet.GetComponent<HitInimigo>().Restart();
        }
    }
}
