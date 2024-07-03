using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    public Animator animator;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            animator.SetBool("spikes", true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            animator.SetBool("spikes", false);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        animator.SetBool("spikes", false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
