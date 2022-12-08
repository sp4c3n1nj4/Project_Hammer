using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public CharacterController player;

    private Vector3 directionInput;
    private float attackTimer = 0;

    [SerializeField]
    private float damage = 10f;
    [SerializeField]
    private float attackDelay = 0.5f;
    [SerializeField]
    private GameObject hitBox;

    //update physics of player
    private void FixedUpdate()
    {
        MovePlayer();
    }

    //move player in fixed update
    private void MovePlayer()
    {
        player.Move(directionInput * (Time.fixedDeltaTime * speed));
    }

    //get player input
    private void Update()
    {
        directionInput = MovementInput();

        if (attackTimer < 0)
        {
            PlayerAttack();
        }
        else
            attackTimer -= Time.deltaTime;
    }

    //convert player input to vector3
    private Vector3 MovementInput()
    {
        Vector3 input = Vector3.zero;

        input.x = Input.GetAxis("Horizontal");
        input.z = Input.GetAxis("Vertical");

        //normalize in case of diagonal movement direction
        if (input.magnitude > 1)
            input = input.normalized;

        return input;
    }

    private void PlayerAttack()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            attackTimer = attackDelay;
            StartCoroutine(SpawnAttack());
        }
    }

    IEnumerator SpawnAttack()
    {
        hitBox.SetActive(true);
        yield return new WaitForSeconds(0.25f);
        hitBox.SetActive(false);
    }

    public void HitBoxEnter(GameObject other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<Enemy>().TakeDamage(damage);
        }
        else if (other.CompareTag("Tower"))
        {
            other.GetComponent<Tower>().TakeDamage(-damage);
        }
    }
}
