using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

namespace BoardGame
{
    public class PlayerMovement : MonoBehaviour
    {
        public float speed = 5f;

        int currentWaypointIndex = 0;

        public List<Transform> waypoints = new List<Transform>();

        public void StartCoroutineMovement(int countPoints)
        {
            StartCoroutine(MovePlayer(countPoints));
        }

        private IEnumerator MovePlayer(int countPoints)
        {
            int i = 0;
            print(countPoints);
            if (currentWaypointIndex + countPoints < waypoints.Count)
            {
                while (i < countPoints)
                {
                    Vector3 targetPosition = waypoints[currentWaypointIndex].position;

                    while (transform.position != targetPosition)
                    {

                        transform.position = Vector3.MoveTowards(transform.position,
                            targetPosition, speed * Time.deltaTime);
                        yield return null;
                    }

                    i++;
                    currentWaypointIndex++;
                }
            }

        }
    }

}
