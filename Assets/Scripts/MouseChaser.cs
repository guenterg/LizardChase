using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MouseChaser : MonoBehaviour
{
    public NavMeshAgent chaser;
    public Camera camera;
    public Vector3 testDestination;
    Animator walkAnimator;
    // Start is called before the first frame update
    void Start()
    {
        chaser.SetDestination(testDestination);
        walkAnimator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Ray mouseRay = camera.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(mouseRay, out hit))
        {
            chaser.SetDestination(hit.point);
            if((chaser.destination-chaser.transform.position).magnitude<0.5)
            {

                walkAnimator.SetTrigger("StopWalk");
            }else
            {
                walkAnimator.SetTrigger("StartWalk");
            }
        }
    }
}
