using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3f;

    private PlayerController player;


    [SerializeField]
    private GameObject lazerPrefab;

    private Animator _enemyexplosion;

    [SerializeField]
    private AudioSource enemyAudio;


    private float _randomx;
    private float _fireRate = 3.0f;
    private float _canFire = -1f;
   
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerController>();
        _enemyexplosion = gameObject.GetComponent<Animator>();
         
        

        if(_enemyexplosion == null)
            {
            Debug.Log("Anim set to NULL");
            }
    }

   
    void Update()
    {
    CalculateMovement();
     if (Time.time > _canFire)
            {
            _fireRate = Random.Range(3f, 7f);
            _canFire = Time.time + _fireRate;
           GameObject enemyLaser =  Instantiate(lazerPrefab, transform.position, Quaternion.identity);
            LazerBehavior[] lasers = lazerPrefab.GetComponentsInChildren<LazerBehavior>();

            for (int i = 0; i < lasers.Length; i++)
                {
                lasers[i].AssignEnemyLaser();
                }
            }  
    }

    void CalculateMovement()
        {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);

        if (transform.position.y < -5f)
            {
            _randomx = Random.Range(-5, 5);
            transform.position = new Vector3(_randomx, 7f, 0f); 
            }
        }
    private void OnTriggerEnter2D(Collider2D other)
        {
       
        if (other.CompareTag("Lazer"))
            {
            enemyAudio.Play();
            Destroy(other.gameObject);
            if (player != null)
                {
                player.AddScore(10);
                }
            _enemyexplosion.SetTrigger("OnEnemyDeath");
            _speed = 0 ;

            Destroy(GetComponent<Collider2D>());
            Destroy(this.gameObject , 2.0f);
            }
        else if (other.CompareTag("Player"))
            {
            enemyAudio.Play();
            if ( player != null)
                {
                player.GetComponent<PlayerController>().Damage();
                }
            _enemyexplosion.SetTrigger("OnEnemyDeath");
            _speed = 0;
            Destroy(gameObject, 2.1f);
            }
        }
        
    }
