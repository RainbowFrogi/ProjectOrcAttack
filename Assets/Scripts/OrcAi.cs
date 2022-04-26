using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using HietakissaUtils;

public class OrcAi : MonoBehaviour
{
    [SerializeField] private Transform movePositionTransform;

    private NavMeshAgent orc;

    private void Awake()
    {
        orc = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (Vector3.Distance(orc.transform.position, orc.destination) > 10)
        {
            Move();
        }
        else
        {
            StartCoroutine(Attack());
        }
    }

    private void Move()
    {
        orc.destination = movePositionTransform.position;
    }

    IEnumerator Attack()
    {
        yield return new WaitForSeconds(4f);
    }
}
