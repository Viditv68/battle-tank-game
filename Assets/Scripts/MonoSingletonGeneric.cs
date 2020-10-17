using UnityEngine;

public class MonoSingletonGeneric<T> : MonoBehaviour where T : MonoSingletonGeneric<T>
{
	private static T instance;
	public static T Instance { get { return instance; } }

	private void Awake()
    {
		if(instance == null)
        {
			instance = (T)this;
			Debug.Log(instance.name);
        }

        else 
		{
			Destroy(this);
		}
    }
	
}
