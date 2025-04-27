
using UnityEngine;
using UnityEngine.SceneManagement;

public class Singleton<T> : MonoBehaviour where T : Component
{
    private static T instance;

    public static T Instance
    {
        get 
        {
            if (instance == null)
            {
                GameObject obj = new GameObject();
                obj.name = typeof(T).Name;

                // Will not set it to hierarchy, and will remain invisible within scenes:
                //obj.hideFlags = HideFlags.HideAndDontSave;
                instance = obj.AddComponent<T>();
                //Debug.Log("created " + obj.name);
            }

            return instance; 
        }
    }

    private void OnDestroy()
    {
        if (instance == this) 
        {
            instance = null;
        }
    }

    // for managing object between scenes.
    public virtual void Awake()
    {
        if (instance != null)
        {
            if (instance == this)
            {
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}

// Whereas the first Singleton is more in the realm of expecting to be loaded in separately upon every scene,
// SingletonPersistent creates a separate background scene alongside the current one,
// similarly to how DontDestroyOnLoad exists in parallel with the scene on screen.
// THIS ALSO REQUIRES ANOTHER SCRIPT, I BELIEVE FOR ACTUALLY SPAWNING THE SEPARATE SCENE IN. SEE SAMYAM.
public class SingletonPersistent<T> : MonoBehaviour where T : Component
{

    private static T instance;

    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                Scene activeScene = SceneManager.GetActiveScene();
                SceneManager.SetActiveScene(SceneManager.GetSceneByName("Managers"));
                GameObject obj = new GameObject();
                obj.name = typeof(T).Name;
                obj.hideFlags = HideFlags.HideAndDontSave;
                instance = obj.AddComponent<T>();
                SceneManager.SetActiveScene(activeScene);
            }
            
            return instance;
        }
    }

    private void OnDestroy()
    {
        if (instance == this)
        {
            instance = null;
        }
    }

    // virtual means: can be overridden.
    /*
    public virtual void Awake()
    {
        if (instance == null)
        {
            instance = this as T;
            DontDestroyOnLoad(gameObject);
        }
        else 
        {
            Destroy(this);
        }
    } */
}