using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour 
{
    [SerializeField]
    private int _speed = 5;

    [SerializeField]
    private AudioClip _powerUpAudio;

	
	void Update () 
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);
	}

    void OnTriggerEnter2D(Collider2D other)//other is the name of the obect that colided with the powerup
    {
        if(tag=="Triple_Shot_Powerup")
        {
            if (other.tag == "Player")
            {
                AudioSource.PlayClipAtPoint(_powerUpAudio, Camera.main.transform.position,1f);
                Player player = other.GetComponent<Player>();

                //If the Player component is not found, the player object becomes null
                //Accessing any component of player if it is null will give error
                if (player != null)
                {
                    player.canTripleShot = true;
                    player.powerUp = 0;
                    player.EnableCoroutine();
                }
                //This calls the coroutine in the Player script


                Destroy(this.gameObject);
            }
        }

        else if(tag=="Speed_Powerup")
        {
            if (other.tag == "Player")
            {
                AudioSource.PlayClipAtPoint(_powerUpAudio,Camera.main.transform.position, 1f);
                Player player = other.GetComponent<Player>();

                //If the Player component is not found, the player object becomes null
                //Accessing any component of player if it is null will give error
                if (player != null)
                {
                    player.speed = 20;
                    player.powerUp = 1;
                    player.EnableCoroutine();
                }
                //This calls the coroutine in the Player script

                Destroy(this.gameObject);
            }

        }

        else if(tag=="Shield_Powerup")
        {
            if(other.tag=="Player")
            {
                AudioSource.PlayClipAtPoint(_powerUpAudio,Camera.main.transform.position, 1f);
                Player player = other.GetComponent<Player>();
                if (player != null)
                {
                    player.powerUp = 2;
                    player.canShieldPowerup = true;
                    player._ShieldGameObject.SetActive(true);
                }
                //This calls the coroutine in the Player script

                Destroy(this.gameObject);

            }
        }
    }
}
