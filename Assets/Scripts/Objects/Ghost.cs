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
        player = GameObject.Find("Player").GetComponent<GhostPlayer>();
        animator = GetComponent<Animator>();
        exerciser = GetComponent<LocomotionController>();

        transform.Rotate(new Vector3(-90, 180, 0));

        chase = Random.Range(0, 3);
        if (chase == 2)
        {
            if (!player)
                return;

            Vector3 dir = player.transform.position - transform.position;
            exerciser.DynamicDirectionChange(dir / 2);
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
