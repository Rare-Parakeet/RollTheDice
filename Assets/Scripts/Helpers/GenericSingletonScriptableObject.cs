using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericSingletonScriptableObject<T> : ScriptableObject where T : GenericSingletonScriptableObject<T> {
    private static T instance;
    public static T Instance {
        get {
            if (instance == null)
            {
                instance = Resources.Load<T>(typeof(T).ToString()); // TODO give explicit filename to improve performance
                (instance as GenericSingletonScriptableObject<T>).OnInitialize();
            }
            return instance;
        }
    }

    // Optional overridable method for initializing the instance.
    protected virtual void OnInitialize() { }
}