using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField]
    private GameObject _explosionanimation;

    [SerializeField]
    private AudioClip _explosionClip;

    private float _rotatespeed = 20 ;
    // spawn manager handle
    private SpawnManager _spawnManager;

    void Start()
    {
        _spawnManager = GameObject.Find("Spawn_Manager").GetComponent<SpawnManager>();

        if(_explosionanimation != null)
            {
            _explosionanimation.gameObject.GetComponent<Animator>();
            }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward *_rotatespeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
        {
        if(other.CompareTag("Lazer"))
            {
            AudioSource.PlayClipAtPoint(_explosionClip, transform.position);
            Debug.Log("Laser Col Detected");
            Instantiate(_explosionanimation, transform.position, Quaternion.identity);
            _spawnManager.StartSpawning();
            Destroy(this.gameObject, 0.5f);
            }
        }
    }
