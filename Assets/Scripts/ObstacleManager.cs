using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour {

    private readonly Vector3 appearPos = new Vector3(0, 0, 600);

    public float distance;

    private List<Obstacle> obstacles;
    private List<Vector3> appearXPos;

    private uint playerSpeed;
    private int beforePos, curPos;

    private void Awake() {
        GameObject.FindWithTag("Player").GetComponent<PlayerSpeed>().SpeedEvent = (speed) => playerSpeed = speed;

        obstacles = new List<Obstacle>();

        for (int i = 0; i < transform.childCount; i++)
            obstacles.Add(transform.GetChild(i).GetComponent<Obstacle>());

        appearXPos = new List<Vector3>();

        Vector3 temp = Vector3.zero;

        for (temp.x = -10; temp.x <= 10; temp.x += 10)
            appearXPos.Add(temp);
    }

    private IEnumerator Start() {
        while (true) {
            yield return CoroutineManager.WaitForSeconds(GetWaitTime());

            Request();
        }
    }

    public void Request() {
        GetRandomObstacle().Active(Arrange, GetRandomPos());
    }

    public void Arrange(Obstacle obstacle) {
        obstacles.Add(obstacle);
    }

    private Obstacle GetRandomObstacle() {
        int rand = Random.Range(0, obstacles.Count);
        Obstacle obstacle = obstacles[rand];

        obstacles.RemoveAt(rand);

        return obstacle;
    }

    private Vector3 GetRandomPos() {
        do {
            curPos = Random.Range(0, appearXPos.Count);
        } while (curPos.Equals(beforePos));

        beforePos = curPos;

        return appearPos + appearXPos[curPos];
    }

    private float GetWaitTime() {
        if (Mathf.Approximately(playerSpeed, 0)) return 0.1f;

        return distance / playerSpeed;
    }
}
