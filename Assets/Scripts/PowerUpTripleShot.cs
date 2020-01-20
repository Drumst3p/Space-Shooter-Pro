using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpTripleShot : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    float _speed = 3f;


    [SerializeField]
    private int powerupID;
    //ID for powerups
    //0 = TripleShot
    //1 = Speed
    //2 = Shields

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);    
        
        if(transform.position.y < -5)
            {
            Destroy(this.gameObject);
            }
    }

    private void OnTriggerEnter2D(Collider2D collision)
        {
        if (collision.CompareTag("Player"))
            {
            Debug.Log("Collision detected");
            Destroy(this.gameObject);
            PlayerController player = collision.transform.GetComponent<PlayerController>();

            // null checking
            if (player != null)
                {
                switch (powerupID)
                {     
                case 0:
                    player.TripleShotOn();
                    break;
                 
                case 1:
                    player.SpeedPowerupOn();
                    break;
                    
                case 2:
                    player.ShieldPowerUpOn();
                    break;

                default:
                    Debug.Log("PowerUp not found");
                    break;
                    }
                }
                }
            }

        }
    
