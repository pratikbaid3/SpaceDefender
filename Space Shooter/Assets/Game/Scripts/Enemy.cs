using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour 
{
    public GameObject enemy_Explosion;
    public int speed=15;

    private UIManager _uiManager;

	// Use this for initialization
	void Start () 
    {
        transform.position = new Vector3(Random.Range(-11.5f, 11.5f), 6.34f, 0);
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        if(transform.position.y<=-6.44f)
        {
            transform.position = new Vector3(Random.Range(-11.5f,11.5f), 6.35f, 0);
        }
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag=="Laser")
        {
            _uiManager.UpdateScore();
            Destroy(this.gameObject);
            Destroy(other.gameObject);
            Enemy_Explosion animations = enemy_Explosion.GetComponent<Enemy_Explosion>();
            animations.pos = transform.position;
            Instantiate(enemy_Explosion);

        }
        else if(other.tag=="Player")
        {
            _uiManager.UpdateScore();
            Player player = other.GetComponent<Player>();
            player.HealthDeduction();
            Destroy(this.gameObject);
            Enemy_Explosion animations = enemy_Explosion.GetComponent<Enemy_Explosion>();
            animations.pos = transform.position;
            Instantiate(enemy_Explosion);
        }
    }
}
