using UnityEngine;
using UnityEngine.Events;

namespace EPS
{
	public class PoolObject : MonoBehaviour
	{
		/// <summary>
		/// Event that invokes when object activates
		/// </summary>
		[SerializeField] protected UnityEvent OnActivate;

		/// <summary>
		/// Event that invokes when object deactivates
		/// </summary>
		[SerializeField] protected UnityEvent OnDeactivate; 

		/// <summary>
		/// Active state of the object
		/// </summary>
		public virtual bool Active
		{
			get => gameObject.activeSelf;
			protected set => gameObject.SetActive(value);
		}

		/// <summary>
		/// Make this object active
		/// </summary>
		public void Activate()
		{
			Active = true;
			OnActivate.Invoke();
		}

		/// <summary>
		/// Make this object inactive
		/// </summary>
		public void Deactivate()
		{
			OnDeactivate.Invoke();
			Active = false;
		}
	}
}
