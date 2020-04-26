using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{

    public Transform target;
    public float speed = 1f;
    public LevelTimer levelTimer;
    public float distanceToTarget = float.MaxValue;
    public float targetDetectionRadious = 20f;

    // Start is called before the first frame update
    void Start()
    {
        this.levelTimer = GameObject.FindGameObjectWithTag("LevelTimer").GetComponent<LevelTimer>();

        if (target == null)
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!LevelTimer.isGameOver)
        {

            distanceToTarget = Vector3.Distance(target.position, transform.position);
            if(target != null && distanceToTarget < targetDetectionRadious)
            {
                this.transform.LookAt(target);
                this.transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            this.levelTimer.GetComponent<LevelTimer>().EnemyDestroyed();
            Destroy(gameObject);
        }
    }
}
