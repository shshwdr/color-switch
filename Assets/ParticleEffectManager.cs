using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ParticleEffectEnum
{
    teleport,
}
public class ParticleEffectManager : Singleton<ParticleEffectManager> {

    public GameObject[] particleEffects;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void playParticleEffect(Vector3 p,ParticleEffectEnum effectEnum)
    {
        GameObject go = Instantiate(particleEffects[(int)effectEnum]);
        go.transform.position = p;
    }
}
