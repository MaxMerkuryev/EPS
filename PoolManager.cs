using UnityEngine;
using System.Collections.Generic;

namespace EPS
{
	public static class PoolManager
	{
		/// <summary>
		/// Dictionary of all pools currently created on scene.
		/// </summary>
		private static Dictionary<int, Pool> pools = new Dictionary<int, Pool>();
		

		private static PoolObject poolObject;

		/// <summary>
		/// Spawn pool object made from the prefab
		/// </summary>
		/// <param name="prefab">Prefab that will be copied to spawn</param>
		/// <param name="position">Position where to spawn the object (optional)</param>
		/// <param name="rotation">Rotation of the object on spawn (optional)</param>
		/// <param name="scale">Scale of the object on spawn (optional)</param>
		/// <param name="activate">Activate the object on spawn (optional)</param>
		/// <returns>Pooled object</returns>
		public static PoolObject Spawn(PoolObject prefab, Vector3? position = null, Quaternion? rotation = null, Vector3? scale = null, bool activate = true)
		{
			// Check if some object want to spawn nothing
			if(!prefab)
			{
				Debug.LogWarning("Hey! Some prefab doesn't exist there! Do something!!!");
				return null;
			}

			poolObject = GetObjectFromPool(prefab);
			
			// Set the object properties before spawn
			if(position.HasValue) poolObject.transform.position = position.Value;
			if(rotation.HasValue) poolObject.transform.rotation = rotation.Value;
			if(scale.HasValue)	  poolObject.transform.localScale = scale.Value;
			if(activate)          poolObject.Activate();
			
			return poolObject;
		}


		private static Pool pool;

		/// <summary>
		/// Get an object from pool by prefab 
		/// </summary>
		/// <param name="prefab"></param>
		/// <returns></returns>
		private static PoolObject GetObjectFromPool(PoolObject prefab)
		{
			// Create pool if the object is spawning for the first time
			if(!pools.TryGetValue(prefab.GetInstanceID(), out pool))
				pool = CreatePool(prefab);

			return pool.GetObject();
		}


		private static Pool newPool;
		private static string newPoolName;

		/// <summary>
		/// Create a pool using given pool object prefab
		/// </summary>
		/// <param name="prefab"></param>
		/// <returns></returns>
		private static Pool CreatePool(PoolObject prefab)
		{
			newPoolName = $"Pool ({ prefab.name })";
			newPool = new GameObject(newPoolName).AddComponent<Pool>();
			newPool.SetObjectPrefab(prefab);

			pools.Add(prefab.GetInstanceID(), newPool);

			return newPool;
		}
	}
}
