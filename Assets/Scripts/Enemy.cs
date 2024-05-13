using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    // veriables
    float wanderRange = 5;
    float playerAttackRange = 6;
    float currentStateElapsed;
    float recoveryTime;
    // follow player
    public float sphereRadius;
    NavMeshAgent agent;
    public Rigidbody Rigidbody { get; private set; }
    Vector3 origin;
    public float lunge = 20f;
    [SerializeField] EneemyStates enemyStates;
    [SerializeField] FPSController player;
    // Start is called before the first frame update
    public enum EneemyStates
    {
        wander,
        pursue,
        attack,
        recovery
    }
    void Start()
    {
        Rigidbody = GetComponent<Rigidbody>();
        origin = transform.position;
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        void Update()
        {

            switch (enemyStates)
            {
                case EneemyStates.wander:
                    UpdateWander();
                    break;

                case EneemyStates.pursue:
                    UpdatePursue();
                    break;

                case EneemyStates.attack:
                    UpdateAttack();
                    break;

                case EneemyStates.recovery:
                    UpdateRecovery();
                    break;

            }
        }

        void UpdateWander()
        {
            float distance = Vector3.Distance(transform.position, player.transform.position);
            if (distance < wanderRange)
            {
                enemyStates = EneemyStates.pursue;
            }
        }

        void UpdatePursue()
        {
            float distance = Vector3.Distance(transform.position, player.transform.position);
            if (distance > 5)
            {
                enemyStates = EneemyStates.wander;
            }
            if (distance < 4)
            {
                enemyStates = EneemyStates.attack;
            }
        }

        void UpdateAttack()
        {
            {
                Rigidbody.AddForce(transform.position * lunge);
                Debug.Log("Player was hit");
            }
        }
        void UpdateRecovery()
        {
            //if(they collided)
            {
                agent.enabled = false;
            }
        }
    }

    public void ApplyKnockback(Vector3 knockback)
    {
        GetComponent<Rigidbody>().AddForce(knockback, ForceMode.Impulse);
    }

    public void Respawn()
    {
        transform.position = origin;
    }
}
