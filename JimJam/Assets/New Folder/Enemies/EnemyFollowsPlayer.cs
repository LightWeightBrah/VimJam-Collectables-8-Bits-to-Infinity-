using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyFollowsPlayer : MonoBehaviour
{
    Player player;

    public Transform playerPos;
    public float speed;
    public float minX;
    public float maxX;
    public float seeDistance;
    public float attackRange;
    private float patrolTime = 0;
    private SpriteRenderer srenderer;
    int damage = 1;

    private void Awake()
    {
        player = FindObjectOfType<Player>();
    }

    private void Start()
    {
        srenderer = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        float distX = Mathf.Abs(transform.position.x - playerPos.position.x);
        float distY = Mathf.Abs(transform.position.y - playerPos.position.y);
        if (distY < 2f && distX < seeDistance)
        { // Move close to player
            srenderer.flipX = transform.position.x < playerPos.position.x; // Face the player. You may want to reverse this depending on where the spite is faces normally.
            if (distX < attackRange)
                DoAttack(); // Do a function like this to attak, line in the example
            else
            {
                Vector3 dest = transform.position;
                dest.x = playerPos.position.x;
                transform.position = Vector2.MoveTowards(transform.position, dest, speed * Time.deltaTime);
            }
        }
        else
        { // patrol
            patrolTime += Time.deltaTime;
            Vector3 dest = transform.position;
            if (patrolTime < 4)
            {
                dest.x = (patrolTime * minX + (4 - patrolTime) * maxX) * .25f;
                srenderer.flipX = false;
            }
            else
            {
                dest.x = ((8 - patrolTime) * minX + (patrolTime - 4) * maxX) * .25f;
                srenderer.flipX = true;
            }
            if (patrolTime >= 8) patrolTime = 0;
            transform.position = Vector2.MoveTowards(transform.position, dest, speed * Time.deltaTime);
        }
    }
    float lastAttaack = 1;
    void DoAttack()
    {
        lastAttaack += Time.deltaTime;
        if (lastAttaack < 1) return;
        lastAttaack = 0;
        player.Damaged();

        // Have here the player being hit
        Debug.Log("Attacking");

    }

}