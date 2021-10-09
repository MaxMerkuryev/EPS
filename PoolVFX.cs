using UnityEngine;
using UnityEngine.Events;

namespace EPS
{
	[RequireComponent(typeof(ParticleSystem))]
	public class PoolVFX : PoolObject
	{
		private ParticleSystem ps;
		private void Awake() => ps = GetComponent<ParticleSystem>();
		
		/// <summary>
		/// Active state of the object
		/// </summary>
		public override bool Active
		{
			get => ps.isPlaying;

			protected set
			{
				if(value)
					ps.Play();
				else
					ps.Stop();
			}
		}
	}
}
