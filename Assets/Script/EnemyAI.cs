using System;
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
    bool isProvoked=false;
    void Start()
    {
        navMeshAgent=GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        distantToTarget=Vector3.Distance(Target.position,transform.position);

        if(isProvoked)
        {
            EngageTarget();
        }
        else if(distantToTarget<chaseRange)
        {        
        isProvoked=true;
        
        }
    }

     void EngageTarget()
    {
        if(distantToTarget>=navMeshAgent.stoppingDistance)
        {
            ChaseTarget();
        }
         if(distantToTarget<navMeshAgent.stoppingDistance)
        {
            AttackTarget();
        }
    }

    private void AttackTarget()
    {
       Debug.Log(name+"is seeked and destroying"+Target.name);
    }

    private void ChaseTarget()
    {
        navMeshAgent.SetDestination(Target.position);
    }

    void OnDrawGizmosSelected()
    {
        
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }
}
