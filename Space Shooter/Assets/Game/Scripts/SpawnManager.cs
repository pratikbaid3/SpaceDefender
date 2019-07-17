using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour 
{
    private bool _enableEnemySpawn = false;
    private bool _enablePowerupSpawn = false;

    [SerializeField]
    private GameObject gameState;

    [SerializeField]
    private GameObject _Enemy;
    [SerializeField]
    private GameObject[] _Powerups;


    public IEnumerator EnemySpawner()
    {
        yield return new WaitForSeconds(2f);
        _enableEnemySpawn = false;
        Instantiate(_Enemy);
    }

    public IEnumerator PowerupSpawner()
    {
        yield return new WaitForSeconds(15f);
        Instantiate(_Powerups[Random.Range(0, 3)],new Vector3(Random.Range(-12.39f,12.39f),6f,0),Quaternion.identity);
        _enablePowerupSpawn = false;
    }

	// Update is called once per frame
	void Update () 
    {
        UIManager uIManager = gameState.GetComponent<UIManager>();
        if (_enableEnemySpawn == false && uIManager.gameState==true)
        {
            _enableEnemySpawn = true;
            StartCoroutine(EnemySpawner());
        }
        if(_enablePowerupSpawn==false && uIManager.gameState==true)
        {
            _enablePowerupSpawn = true;
            StartCoroutine(PowerupSpawner());
        }
	}
}
