using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    [SerializeField] private float countdownObstacle;

    private float timer;
    private PoolScript obstaclePool;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        obstaclePool = GetComponent<PoolScript>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= countdownObstacle) 
        {
            GameObject obj = obstaclePool.RequestObject();

            float randY = Random.Range(7.42f, 2.13f);
            obj.transform.position = new Vector3(transform.position.x, randY, 0);
            timer = 0;
        }
    }
}
