using UnityEngine;
using System.Collections.Generic;

namespace EPS
{
	public class Pool : MonoBehaviour
	{
		/// <summary>
		/// Object prefab with PoolObject component
		/// </summary>
		private PoolObject prefab;

		/// <summary>
		/// List of object stored in this pool on scene
		/// </summary>
		private List<PoolObject> poolObjects = new List<PoolObject>();

		/// <summary>
		/// Initialize this pool and give it an object prefab to create copies
		/// </summary>
		/// <param name="prefab">Prefab</param>
		public void SetObjectPrefab(PoolObject prefab) => this.prefab = prefab;

		/// <summary>
		/// Get any available object from this pool
		/// </summary>
		/// <returns>Any available pool object from this pool</returns>
		public PoolObject GetObject()
		{
			for(int i = 0; i < poolObjects.Count; i++)
			{
				// Check in case the object was deleted from scene somehow
				if(poolObjects[i] == null)
					continue;

				// Return only inactive object to avoid objects magically disappearing from scene
				if(!poolObjects[i].Active)
					return poolObjects[i];
			}

			return CreateObject();
		}
		
		
		private PoolObject newPoolObject;

		/// <summary>
		/// Create a copy of poolObjectPrefab in case there no available objects in this pool
		/// </summary>
		/// <returns>New copy of poolObjectPrefab</returns>
		private PoolObject CreateObject()
		{
			newPoolObject = Instantiate(prefab, transform);
			newPoolObject.name += $"_{(poolObjects.Count + 1)}";
			poolObjects.Add(newPoolObject);							

			return newPoolObject;
		}
	}
}
