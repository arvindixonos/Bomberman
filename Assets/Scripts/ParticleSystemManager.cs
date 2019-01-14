using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSystemManager : MonoBehaviour {

	public	static	ParticleSystemManager	Instance = null;

	[System.Serializable]
	public	class	ParticleSystemCollection
	{
		public	eParticleEffectsType	particleEffectsType;
		public	ParticleSystem			particleSystem;
	}

	void Awake()
	{
		if(Instance == null)
			Instance = this;
	}

	void OnDestroy()
	{
		Instance = null;
	}
}
