using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
                    // Get all components of the current game object
        Component[] allComponents = GetComponents<Component>();

        // Iterate through each component
        foreach (Component component in allComponents)
        {
            // Check if the component is of type NavMeshSurface
            if (component is NavMeshSurface)
            {
                // Cast the component to NavMeshSurface type
                NavMeshSurface navMeshSurface = (NavMeshSurface)component;

                // Access properties and methods of NavMeshSurface
                Debug.Log("Component Type: NavMeshSurface");
                Debug.Log("Agent Type: " + navMeshSurface.agentTypeID);
                Debug.Log("Collect Objects: " + navMeshSurface.collectObjects);
                // Add more properties and methods as needed
            }
        }
    }        

    // Update is called once per frame
    void Update()
    {
        
    }
}
