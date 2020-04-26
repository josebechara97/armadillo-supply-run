using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
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
        if (collision.gameObject.CompareTag("Enemy")||collision.gameObject.CompareTag("KillZone"))
        {
            this.levelTimer.GetComponent<LevelTimer>().LevelLost();
            Destroy(this.gameObject);
        }
    }
}
