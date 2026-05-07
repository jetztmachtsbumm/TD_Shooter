using System.Collections;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{

    [SerializeField] float moveSpeed = 5f;

    float destinationReachedThreshhold = 0.00001f;

    void Start()
    {
        StartCoroutine(MoveToHQ());
    }

    IEnumerator MoveToHQ()
    {
        foreach(var gridNode in EnemyPathfindingManager.Instance.CurrentEnemyPath)
        {
            while(Vector3.Distance(transform.position, gridNode.worldPosition) > destinationReachedThreshhold)
            {
                transform.position = Vector3.MoveTowards(transform.position, gridNode.worldPosition, moveSpeed * Time.deltaTime);

                yield return null;
            }
        }
    }

}
