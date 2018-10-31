using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostPlayer : MonoBehaviour
{    
    [SerializeField] private Inventory inventory;
    [SerializeField] private ParticleManager particleManager;

    private StateManager stateManager;
    private Animator animator;
    private CatchableGhost PickUpGhost;
    
    void Awake () {
        stateManager = GetComponentInChildren<StateManager>();
        animator = GetComponentInChildren<Animator>();
    }
	
    public void ActiveAttack()
    {
        stateManager.State = "attack";
    }
    public void DeactiveAttack()
    {
        stateManager.State = "run";
    }

    public void LateUpdate()
    {     
        if (PickUpGhost)
        {
            GhostFollow();
        }
    }

    private void GhostFollow()
    {
        PickUpGhost.transform.localPosition = new Vector3(transform.localPosition.x + 0.35f, transform.localPosition.y - 0.8f, transform.localPosition.z - 0.7f);
    }

    public void Attack()
    {
        animator.Play("attack");
        stateManager.State = "attack";
    }

    public void Die()
    {

    }

    public void HitGhost(GameObject ghost)
    {
        particleManager.CreateHitFX(new Vector3(transform.position.x,transform.position.y,transform.position.z + 1));
        particleManager.CreateGhostDisapearFX(ghost.transform.position);

        Ghost hitGhost = ghost.GetComponent<Ghost>();
        hitGhost.Hit();
    }

    public void OnCheckPoint()
    {
        if (PickUpGhost)
        {
            PickUpGhost.OnCheckPoint();
            PickUpGhost = null;
        }
    }

    public void PickUp(GameObject gameObject)
    {
        if (PickUpGhost)
        {
            PickUpGhost.Decatched();
        }

        PickUpGhost = gameObject.GetComponent<CatchableGhost>();
        animator.Play("catch");

        PickUpGhost.Catched();
        inventory.Add(gameObject.name);
    }
}
