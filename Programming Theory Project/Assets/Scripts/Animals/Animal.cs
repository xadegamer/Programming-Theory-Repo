using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class Animal : MonoBehaviour
{
    public string animalName;
    public float Speed = 3;
    public float height = 3;

    protected NavMeshAgent m_Agent;
    protected AnimatorHandler animatorHandler;
    protected Cage m_Target;

    protected void Awake()
    {
        m_Agent = GetComponent<NavMeshAgent>();
        animatorHandler = GetComponentInChildren<AnimatorHandler>();
        m_Agent.speed = Speed;
        m_Agent.acceleration = 999;
        m_Agent.angularSpeed = 999;
    }

    void Update()
    {
        if (m_Target != null)
        {
            float distance = Vector3.Distance(m_Target.transform.position, transform.position);
            if (distance < 2.0f)
            {
                m_Agent.isStopped = true;
                CageInRange();
            }
        }
    }

    public virtual void IsSelected()
    {
        animatorHandler.OnSelect();
    }

    public virtual void GoTo(Cage target)
    {
        m_Target = target;

        if (m_Target != null)
        {
            m_Agent.SetDestination(m_Target.transform.position);
            m_Agent.isStopped = false;
        }
    }

    public virtual void GoTo(Vector3 position)
    {
        //we don't have a target anymore if we order to go to a random point.
        m_Target = null;
        m_Agent.SetDestination(position);
        m_Agent.isStopped = false;
    }

    protected abstract void CageInRange();
}
