using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStartController : MonoBehaviour 
{
    public GameObject player;
    private UIManager _uiManager;
    // Update is called once per frame
    void Update () 
    {
        if(Input.GetKeyDown("space"))
        {
            Instantiate(player);
            _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
            _uiManager.DisableMainMenu();
            Destroy(this.gameObject);
        }
	}
}
