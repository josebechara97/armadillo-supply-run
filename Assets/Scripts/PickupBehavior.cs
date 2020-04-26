using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupBehavior : MonoBehaviour
{
    public AudioClip pickup;
    public LevelTimer levelTimer;

    // Start is called before the first frame update
    void Start()
    {
        this.levelTimer = GameObject.FindGameObjectWithTag("LevelTimer").GetComponent<LevelTimer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("hit");
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("trigered");
        if (other.CompareTag("Player"))
        {
            //gameObject.GetComponent<Animator>().SetTrigger("pickedTrigger");
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        if (!LevelTimer.isGameOver)
        {
            levelTimer.GetComponent<LevelTimer>().currentPickup++;
            var cameraPosition = GameObject.FindGameObjectWithTag("MainCamera").transform.position;
            AudioSource.PlayClipAtPoint(pickup, cameraPosition);
            if (levelTimer.GetComponent<LevelTimer>().currentPickup>= levelTimer.GetComponent<LevelTimer>().originalPickupCount)
            {
                levelTimer.GetComponent<LevelTimer>().LevelWon();
            }
        }
    }
}
