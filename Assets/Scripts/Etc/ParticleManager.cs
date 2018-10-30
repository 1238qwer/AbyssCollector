using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ParticleManager : MonoBehaviour {

    [SerializeField] private GameObject hitFX;
    [SerializeField] private GameObject ghostDispearFX;
    [SerializeField] private GameObject snowFX;
    [SerializeField] private GameObject lightFX;

    private ObjectPooler hitFXpooler;
    private ObjectPooler ghostDispearFXpooler;
    private ObjectPooler snowFXpooler;
    private ObjectPooler lightFXpooler;

    void Awake () {
        DontDestroyOnLoad(this);

        hitFXpooler = new ObjectPooler();
        ghostDispearFXpooler = new ObjectPooler();

        hitFXpooler.AutoReturnPool(hitFX, 5,2);
        ghostDispearFXpooler.AutoReturnPool(ghostDispearFX, 5,2);
    }
	
	public void CreateHitFX(Vector3 spawnPos)
    {
        GameObject particle = hitFXpooler.GetPool();
        particle.transform.position = spawnPos;
    }

    public void CreateGhostDisapearFX(Vector3 spawnPos)
    {
        GameObject particle = ghostDispearFXpooler.GetPool();
        particle.transform.position = spawnPos;
    }
}
