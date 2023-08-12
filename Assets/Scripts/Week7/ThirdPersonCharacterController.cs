using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCharacterController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 3.0f;
    [SerializeField] private float rotationSpeed = 150.0f;
    private Animator animator;
    bool enemyDied;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, 0.0f, verticalInput) * moveSpeed * Time.deltaTime;
        transform.Translate(movement);

        if (movement.magnitude > 0.1f)
        {
            Quaternion newRotation = Quaternion.LookRotation(movement);
            transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, rotationSpeed * Time.deltaTime);
        }

        animator.SetBool("Walking", true);

        if (Input.GetButtonDown("Fire1"))
        {
            StartCoroutine(DieTime());
            animator.SetTrigger("Attack");
        }
    }

    IEnumerator DieTime()
    {
        enemyDied = true;
        yield return new WaitForSeconds(1f);
        enemyDied = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (enemyDied)
        {
            other.gameObject.SetActive(false);
            PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score") + 10);
            Debug.Log("Score: " + PlayerPrefs.GetInt("Score"));
        }
    }
}
