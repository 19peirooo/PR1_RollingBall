using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    //1. Obtener NavMeshAgent
        private NavMeshAgent navMeshAgent;
        //2. Obtener un destino
        [SerializeField] private GameObject player;
        //3. Marca como destino al player
    
        private void Awake()
        {
            navMeshAgent = GetComponent<NavMeshAgent>();
            navMeshAgent.areaMask = 1 << NavMesh.GetAreaFromName("Walkable");
        }
        
        void Update()
        {
            NavMeshHit hit;
            if (NavMesh.SamplePosition(player.transform.position, out hit, 1.0f, navMeshAgent.areaMask))
            {
                navMeshAgent.SetDestination(hit.position);
            }
        }
}
