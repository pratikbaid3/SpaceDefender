using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player: MonoBehaviour 
{
    public GameObject gameStartController;
    public GameObject _ShieldGameObject;

    [SerializeField]
    private GameObject _LeftEngine;

    [SerializeField]
    private GameObject _RightEngine;

    [SerializeField]
    private AudioClip _explosionAudioClip;

    /**[SerializeField]
    private GameObject _livesUI;**/

    private UIManager _uiManager;

    [SerializeField]
    private float _fireRate = 0.2f;

    [SerializeField]
    private GameObject _explosion;

    private float _canFire = 0.0f;

    [SerializeField]
    private GameObject _laserPrefab;
    [SerializeField]
    private GameObject _tripleShotLaserPrefab;

    [SerializeField]
    private int _health = 3;

    public int speed = 10;

    public bool canTripleShot = false;

    public bool canShieldPowerup = false;


    public int powerUp = 0;//0= TripleShot 1=Speed 2=Shield



	// Use this for initialization
	void Start () 
    {
        transform.position = new Vector3(0, -3.5f, 0);
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        Movement();
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            if(canTripleShot==true)
            {
                TripleFire();
            }
            else
            {
                Fire();
            }
        }
	}

    private void TripleFire()
    {
        if (Time.time > _canFire)
        {
            _canFire = Time.time + _fireRate;
            Instantiate(_tripleShotLaserPrefab, transform.position, Quaternion.identity);
        }
    }

    private void Fire()
    {
        if (Time.time > _canFire)
        {
            _canFire = Time.time + _fireRate;
            Instantiate(_laserPrefab, new Vector3(transform.position.x, transform.position.y + 1, 0), Quaternion.identity);
            gameObject.GetComponent<AudioSource>().Play();
        }
    }

    private void Movement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        transform.Translate(Vector3.up * vertical * Time.deltaTime * speed);
        transform.Translate(Vector3.right * horizontal * Time.deltaTime * speed);

        if (transform.position.x > 12.5)
        {
            transform.position = new Vector3(-12.5f, transform.position.y, transform.position.z);
        }
        if (transform.position.x < -12.5)
        {
            transform.position = new Vector3(12.5f, transform.position.y, transform.position.z);
        }
        if (transform.position.y > 3.97)
        {
            transform.position = new Vector3(transform.position.x, 3.97f, transform.position.z);
        }
        if (transform.position.y < -4.02)
        {
            transform.position = new Vector3(transform.position.x, -4.02f, transform.position.z);
        }
    }

    public void EnableCoroutine()
    {
        if(powerUp==0)
        {
            StartCoroutine(TripleShotPowerDownRoutine()); 
        }

        else if(powerUp==1)
        {
            StartCoroutine(SpeerPowerDownRoutine());
        }

    }

    public IEnumerator TripleShotPowerDownRoutine()
    {
        yield return new WaitForSeconds(5.0f);
        canTripleShot = false;
    }

    public IEnumerator SpeerPowerDownRoutine()
    {
        yield return new WaitForSeconds(5.0f);
        speed = 10;
    }

    public void HealthDeduction()
    {
        if (canShieldPowerup == false)
        {
            _health--;

            _uiManager.UpdateLives(_health);

            if(_health==2)
            {
                _LeftEngine.SetActive(true); 
            }
            if(_health==1)
            {
                _RightEngine.SetActive(true);
            }

            if (_health == 0)
            {
                //Instantiate(gameStartController);
                _uiManager.EnableMainMenu();
                Instantiate(gameStartController);
                AudioSource.PlayClipAtPoint(_explosionAudioClip,Camera.main.transform.position, 1f);
                Destroy(this.gameObject);
                Instantiate(_explosion, transform.position, Quaternion.identity);
            }
        }
        else
        {
            canShieldPowerup = false;
            _ShieldGameObject.SetActive(false);
        }
    }
}
