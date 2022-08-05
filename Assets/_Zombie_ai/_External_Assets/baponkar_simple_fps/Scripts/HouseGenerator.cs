using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Baponkar.FPS.Simple
{
    [ExecuteInEditMode]
    public class HouseGenerator : MonoBehaviour
    {
        public bool randomize;
        public Transform houseParent;
        public Transform treeParent;
        public GameObject [] houses;
        public GameObject [] trees;
        List<GameObject> houseList = new List<GameObject>();
        List<GameObject> treeList = new List<GameObject>();
        public GameObject groundPlane;
        float length;
        float bredth;
        public int totalHouses = 10;
        public int totalTrees = 10;
        List<Vector3> housePositions = new List<Vector3>();
        // Start is called before the first frame update
        void Start()
        {
            length = groundPlane.GetComponent<Renderer>().bounds.size.x;
            bredth = groundPlane.GetComponent<Renderer>().bounds.size.z;

            PlaceHouses();
            PlaceTrees();
        }

        

        void PlaceHouses()
        {
            while (totalHouses > 0)
            {
                Vector3 position = new Vector3(Random.Range(-length / 2, length / 2), 0, Random.Range(-bredth / 2, bredth / 2));
                if (!housePositions.Contains(position))
                {
                    housePositions.Add(position);
                    var house = Instantiate(houses[Random.Range(0,houses.Length)],position,Quaternion.identity);
                    houseList.Add(house);
                    house.transform.parent = houseParent.transform;
                    totalHouses--;
                }
            }
        }

        void ClearHouses()
        {
            foreach (var house in houseList)
            {
                Destroy(house);
            }
            houseList.Clear();
        }

        void ClearTrees()
        {
            foreach (var tree in treeList)
            {
                Destroy(tree);
            }
            treeList.Clear();
        }

        void PlaceTrees()
        {
            while (totalTrees > 0)
            {
                Vector3 position = new Vector3(Random.Range(-length / 2, length / 2), 0, Random.Range(-bredth / 2, bredth / 2));
                if (!housePositions.Contains(position))
                {
                    housePositions.Add(position);
                    var tree = Instantiate(trees[Random.Range(0,trees.Length)],position,Quaternion.identity);
                    treeList.Add(tree);
                    tree.transform.parent = treeParent.transform;
                    totalTrees--;
                }
            }
        }
    }
}
