using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using HietakissaUtils;
using HietakissaUtils.Health;
using HietakissaUtils.Timer;

public class OrcAi : MonoBehaviour
{
    TowerShooting towerShooting;

    CurrencySystem currencySystem;

    [SerializeField] private Transform movePositionTransform;

    public HealthSystem healthSystem;

    public Timer timer;

    public Animator walkAnim;
    
    private NavMeshAgent orc;
    float distanceToCastle;

    private void Awake()
    {
        orc = GetComponent<NavMeshAgent>();

        Timer timer = new Timer(3f, gameObject);

        healthSystem = new HealthSystem(100f);

        healthSystem.OnDied += Die;

        timer.OnCompleted += Actions;
    }

    private void Start()
    {

        currencySystem = GameManager.Instance.currencySystem;

        towerShooting = GameManager.Instance.towerShooting;

        //towerShooting.enemies.Add(gameObject);

        movePositionTransform = GameObject.Find("OrcAttackCastle").transform;
        
        orc.destination = movePositionTransform.position;
        Move();
    }

    void Actions()
    {
        distanceToCastle = Vector3.Distance(transform.position, movePositionTransform.position);
        if (distanceToCastle < 23)
        {
            CastleManager.healthSystem.Damage(100f);
            orc.isStopped = true;

            walkAnim.SetBool("IsAttacking", true);
        }
        else Move();
    }
    private void Move()
    {
        print("tried to move");
        orc.isStopped = false;
        
    }

    void Die()
    {
        Destroy(gameObject);

        currencySystem.addMoney(50);
    }
}
