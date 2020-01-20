using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    [SerializeField]
    private float _speed;
    private float xrange =5f;
    private float yrange = 4f;
    private float speedMultiplier = 5.5f;
    [SerializeField]
    private int score;

    [SerializeField]
    private float _fireRate = 0.5f;
    private float _canFire = -1f;

    [SerializeField]
    private GameObject player_Damage1;
    [SerializeField]
    private GameObject player_Damage2;
    [SerializeField]
    private GameObject lazerPrefab;
    [SerializeField]
    private GameObject tripleShotPrefab;
    [SerializeField]
    private GameObject shieldOverlay;

    [SerializeField]
    private AudioClip _lazerSoundClip;

    [SerializeField]
    private GameObject _explosionSound;
    [SerializeField]
    private GameObject _powerUpSound;

    [SerializeField]
    private AudioSource _audioSource;



    private UIManager _uiManager;

    private Vector3 offset = new Vector3(0f, -1.05f, 0f);
    private SpawnManager spawnManager;
    [SerializeField]
    private int _lives;

    public bool isTripleShotActive = false;
    public bool isSpeedActive = false;
    public bool isShieldActive = false;

    private void Awake()
        {
        }

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        spawnManager = GameObject.Find("Spawn_Manager").GetComponent<SpawnManager>();
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();

        if ( spawnManager == null )
            {
            Debug.Log("Spawn Manger is NULL");
            }

        if (_uiManager == null)
            {
            Debug.Log("UI manager is NULL");
            }

        if(_audioSource == null)
            {
            Debug.Log("Audio source on player is NULL");
            }
        else
            {
            _audioSource.clip = _lazerSoundClip;
            }
        }
    void Update()
        {
        CalculateMovement();

        if (Input.GetKeyDown(KeyCode.Space) && Time.time > _canFire)
            {
            FireLazer();
            }
        }

    void CalculateMovement()
        {
            {
            // Introducing a vector that takes in both the horizontal and vertical inputs and combining them into one
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");
            Vector3 playerDirection = new Vector3(horizontalInput, verticalInput, 0f);

            // Implementing player input, speed, and Time normalization into a method that moves the player
            transform.Translate(playerDirection * _speed * Time.deltaTime);


            // restrictors 
            // if the game object's position hits one of the restrictors it gets locked on the grid it the restrictor,
            // binding it to the restrictors location on that particulars axis
            if (transform.position.x > xrange)
                {
                transform.position = new Vector3(-xrange, transform.position.y, 0f);
                }
            else if (transform.position.x < -xrange)
                {
                transform.position = new Vector3(xrange, transform.position.y, 0f);
                }
            else if (transform.position.y < 0)
                {
                transform.position = new Vector3(transform.position.x, 0f, 0f);
                }
            else if (transform.position.y > 4)
                {
                transform.position = new Vector3(transform.position.x, yrange, 0f);
                }
            }
        }
    void FireLazer()
        {
        // If i hit the space key i I will spawn lazer && If the time that has transpired since the game started is more then the can fire counter
        // which starts at zero            
            // then fire and set the canfire counter to the time that elapsed plus the fire rate. 
            // therefore using the fire rate as a clutch to prevent the user from firing since its that much bigger the Time.time
            _canFire = Time.time + _fireRate;

            if (isTripleShotActive == true)
            {
            Instantiate(tripleShotPrefab, transform.position, Quaternion.identity);
            }
        else
            {
            Instantiate(lazerPrefab, transform.position - offset, Quaternion.identity);
            }
            _audioSource.Play();

            }
  
    public void AddScore(int scoreToAdd)
        {
        score += scoreToAdd;
        _uiManager.UpdateScore(score);
        }

    public void Damage()
        {
        
        if (isShieldActive == true)
           {
            isShieldActive = false;
            shieldOverlay.SetActive(false);
            return;
           }
        _lives--;
        _uiManager.UpdateLives(_lives);
        if (_lives == 2)
            {
            player_Damage1.SetActive(true);
            }
        else if (_lives == 1)
            {
            player_Damage2.SetActive(true);
            }
        if(_lives <= 0)
            {
            _explosionSound.GetComponent<AudioSource>().Play();
            Debug.Log("You lose!");
            Debug.Log("On Player Death Method Called");
            spawnManager.OnPlayerDeath();
            Destroy(this.gameObject);
            player_Damage1.SetActive(false);
            player_Damage2.SetActive(false);
            }


        
        }

    public void TripleShotOn()
        {
        _powerUpSound.GetComponent<AudioSource>().Play();
        isTripleShotActive = true;
        StartCoroutine(TripleShotPowerUpRoutine());
        }

    public void SpeedPowerupOn()
        {
        _powerUpSound.GetComponent<AudioSource>().Play();
        isSpeedActive = true;
        if(isSpeedActive == true)
            {
            _speed += speedMultiplier;
            }   
        StartCoroutine(SpeedPowerupRoutine());
        }

    public void ShieldPowerUpOn()
        {
        _powerUpSound.GetComponent<AudioSource>().Play();
        isShieldActive = true;
        Debug.Log("Shields set to true");
        shieldOverlay.SetActive(true);
        Debug.Log("Shield Overlay set to true");
        }

    IEnumerator TripleShotPowerUpRoutine()
        {
        yield return new WaitForSeconds(5.0f);
        isTripleShotActive = false;
        }

    IEnumerator SpeedPowerupRoutine()
        {
        yield return new WaitForSeconds(5.5f);
        _speed -= speedMultiplier;
        isSpeedActive = false;
        }
        }
        


