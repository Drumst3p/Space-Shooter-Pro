using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerBehavior : MonoBehaviour
    {
    [SerializeField]
    private float _speed = 8.0f;
    public bool _isEnemyLaser = false;
    void Update()
        {
        if (_isEnemyLaser == false)
            {
            MoveUp();
            }
        else
            {
            Movedown();
            }

        }
    void MoveUp()
        {
        transform.Translate(Vector3.up * _speed * Time.deltaTime);

        if (transform.position.y > 20)
            {
            // check if this object has a parent.
            // destroy the parent too
            if (transform.parent != null)
                {
                Destroy(transform.parent.gameObject);
                }

            Destroy(this.gameObject);
            }
        }
        

    void Movedown()
        {

        transform.Translate(Vector3.down * _speed * Time.deltaTime);

        if (transform.position.y < -3f && _isEnemyLaser == true)
            {
            if (transform.parent != null)
                {
                Destroy(transform.parent.gameObject);
                }
            Destroy(this.gameObject);
            }
        }
    public void AssignEnemyLaser()
        {
        _isEnemyLaser = true;
        }
    private void OnTriggerEnter2D(Collider2D other)
        {
        if(other.tag == "Player" && _isEnemyLaser == true)
            {
            PlayerController player = other.GetComponent<PlayerController>();
            if (player != null)
                {
                player.Damage();
                }
            }
        }

    }
