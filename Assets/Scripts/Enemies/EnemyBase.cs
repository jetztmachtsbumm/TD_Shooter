using System.Collections;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{

    [SerializeField] float moveSpeed = 5f;

    const float destinationReachedThreshold = 0.01f;

    void Start()
    {
        StartCoroutine(MoveToHQ());
    }

    IEnumerator MoveToHQ()
    {
        foreach(var gridNode in EnemyPathfindingManager.Instance.CurrentEnemyPath)
        {
            while(Vector3.Distance(transform.position, gridNode.worldPosition) > destinationReachedThreshold)
            {
                transform.position = Vector3.MoveTowards(transform.position, gridNode.worldPosition, moveSpeed * Time.deltaTime);

                yield return null;
            }
        }
    }

}
