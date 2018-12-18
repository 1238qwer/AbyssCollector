using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    [HideInInspector] public Animator animator;
    private int chase;
    private GhostPlayer player;
    private LocomotionController exerciser;

    void Start () {
        rnd = Random.Range(0, 2);
        player = GameObject.Find("Player").GetComponent<GhostPlayer>();
        animator = GetComponent<Animator>();
        exerciser = GetComponent<LocomotionController>();

        //transform.Rotate(new Vector3(-90, 180, 0));

        //chase = Random.Range(0, 3);
        //if (chase == 2)
        //{
        //    if (!player)
        //        return;

        //    Vector3 dir = player.transform.position - transform.position;
        //    exerciser.DynamicDirectionChange(dir / 2);
        //}    
    }

    Ray ray;
    Vector3 fwd;
    RaycastHit hit;

    public float time;
    public bool timeCheck;
    public float remainTime;

    int rnd;

    void Update()
    {
        fwd = transform.TransformDirection(-Vector3.forward);
        ray = new Ray(transform.position, fwd);

        if (Physics.Raycast(ray, out hit, 4))
        {
            if (hit.transform.CompareTag("Obstacle") || hit.transform.CompareTag("CatchableGhost"))
            {
                
                time = 0.07f;
                timeCheck = true;
            }
        }

        if (timeCheck)
        {
            time -= Time.deltaTime;

            if (rnd == 0)
                transform.Rotate(0, 1, 0);
            else
                transform.Rotate(0, -1, 0);

            transform.Translate(-Vector3.forward * Time.deltaTime * 17);

            if (time <= 0)
            {
                timeCheck = false;
            }
        }
        else
        {
            if (rnd == 0)
            {
                if (transform.localRotation.y >= 0)
                {
                    transform.Rotate(0, -1, 0);
                }
            }
            else
            {
                if (transform.localRotation.y <= 0)
                {
                    transform.Rotate(0, 1, 0);
                }
            }

            transform.Translate(-Vector3.forward * Time.deltaTime * 17);
        }
    }

    public void Hit()
    {
        StartCoroutine(HitCorutine());
    }

    private IEnumerator HitCorutine()
    {
        transform.Translate(0, 0.5f, 0);

        yield return new WaitForSeconds(0.1f);

        gameObject.SetActive(false);
    }
}
