using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GunduzDev
{
    public class TPersonCharacterController : MonoBehaviour
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
            CharacterMovement();
        }

        private void CharacterMovement()
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            Vector3 movement = new Vector3(horizontalInput, 0.0f, verticalInput);
            movement.Normalize();

            if (movement.magnitude > 0.1f)
            {
                Quaternion targetRotation = Quaternion.LookRotation(movement);
                transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

                animator.SetBool("Walking", true);
            }
            else
            {
                animator.SetBool("Walking", false);
            }

            transform.Translate(movement * moveSpeed * Time.deltaTime);

            if (Input.GetButtonDown("Fire1") && !enemyDied)
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
            if (!enemyDied) return;
            
            other.gameObject.SetActive(false);
            int randomNum = Random.Range(10, 20);
            PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score") + randomNum);
            UIManager8.Instance.OnScoreChanged();

            PlayerPrefs.SetInt("Kill", PlayerPrefs.GetInt("Kill") + 1);
            UIManager8.Instance.OnKillChanged();
        }
    }
}
