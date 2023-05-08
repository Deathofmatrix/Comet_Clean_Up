using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CometCleanUP
{
    public class CometManager : MonoBehaviour
    {
        public Collider2D spawncollider;

        public int numberOfCometsToSpawn;
        public GameObject cometPrefab;
        public CometType[] cometTypes;
        public List<GameObject> allComets;

        private void Start()
        {
            spawncollider = GetComponent<Collider2D>();
            SpawnComets();
        }
        public Vector2 PickRandomSpawnLocation()
        {
            float randomX = Random.Range(spawncollider.bounds.max.x, spawncollider.bounds.min.x);
            float randomY = Random.Range(spawncollider.bounds.max.y, spawncollider.bounds.min.y);
            Vector2 spawnLocation = new Vector2(randomX, randomY);
            return spawnLocation;
        }

        public void SpawnComets()
        {
            for (int i = 0; i < numberOfCometsToSpawn; i++)
            {
                GameObject newComet = Instantiate(cometPrefab, transform);
                newComet.GetComponent<CometMovement>().cometType = cometTypes[Random.Range(0, cometTypes.Length)];
                newComet.GetComponent<CometMovement>().LoadScriptableObjectData();
                newComet.transform.position = PickRandomSpawnLocation();  
                allComets.Add(newComet);
            }
        }

        private void Update()
        {
            for(int i = 0; i < allComets.Count; i++)
            {
                if (allComets[i] == null)
                {
                    allComets.Remove(allComets[i]);
                }
            }

            if (allComets.Count <= 0)
            {
                SceneManager.LoadScene(1);
            }
        }
    }
}