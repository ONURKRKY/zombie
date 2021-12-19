using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]Transform Target;
    [SerializeField] float chaseRange=10f;
    float distantToTarget =Mathf.Infinity;
    NavMeshAgent navMeshAgent;
    void Start()
    {
        navMeshAgent=GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        distantToTarget=Vector3.Distance(Target.position,transform.position);

        if(distantToTarget<chaseRange)
        {        
        navMeshAgent.SetDestination(Target.position);
        }
    }
    void OnDrawGizmosSelected()
    {
        
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }
}
