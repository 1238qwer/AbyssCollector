using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostPlayer : MonoBehaviour
{    
    [SerializeField] private Inventory inventory;
    [SerializeField] private ParticleManager particleManager;
    [SerializeField] private List<GameObject> catchedGhostes = new List<GameObject>();

    private GameObject currentPickup;

    private StateManager stateManager;
    private Animator animator;
    public GameObject PickUpGhost;
    public bool isCatched;
    public string ghostString;
    
    void Awake ()
    {
        stateManager = GetComponentInChildren<StateManager>();
        animator = GetComponentInChildren<Animator>();

        foreach (GameObject item in catchedGhostes)
            item.SetActive(false);
    }

    public void ActiveAttack()
    {
        stateManager.State = "attack";
    }
    public void DeactiveAttack()
    {
        stateManager.State = "run";
    }

    public void Attack()
    {
        animator.Play("attack");
        stateManager.State = "attack";
    }

    public void Die()
    {
        animator.Play("die");
    }

    public void HitGhost(GameObject ghost)
    {
        particleManager.CreateHitFX(new Vector3(transform.position.x,transform.position.y,transform.position.z + 1));
        particleManager.CreateGhostDisapearFX(ghost.transform.position);

        Ghost hitGhost = ghost.GetComponent<Ghost>();
        hitGhost.Hit();
    }

    private ObjectGenerater objectGenerater;
    private ObjectPooler catchablePooler;
    public CatchableGhost returnGhost;
    public void OnCheckPoint()
    {
        if (!isCatched && ghostString == string.Empty)
            return;

        objectGenerater = GameObject.Find("AdvancedGenerator").GetComponent<ObjectGenerater>();
        catchablePooler = objectGenerater.catchablePooler;

        returnGhost = catchablePooler.GetPool(ghostString).GetComponentInChildren<CatchableGhost>();
        returnGhost.OnCheckPoint();

        PickUpGhost.SetActive(false);
        isCatched = false;
        ghostString = string.Empty;
    }

    public void PickUp(GameObject gameObject)
    {
        foreach(GameObject item in catchedGhostes)
        {
            Character character = gameObject.GetComponent<Character>();

            if (item.name.Contains(character.id))
            {
                if (isCatched)
                {
                    return;
                }

                gameObject.transform.parent.gameObject.SetActive(false);
                item.SetActive(true);
                PickUpGhost = item;
                ghostString = character.id;
                isCatched = true;
                inventory.Add(character.id);

                animator.Play("runtake");
                animator.SetBool("catched", true);
            }
        }
    }
}
