using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Platformer.Scripts
{
    public class LevelParser : MonoBehaviour
    {
        public string filename;
        public GameObject rockPrefab;
        public GameObject brickPrefab;
        public GameObject questionBoxPrefab;
        public GameObject stonePrefab;
        public GameObject skwerPrefab;
        public GameObject coinPrefab;
        public GameObject goalPrefab;
        public Transform environmentRoot;

        // --------------------------------------------------------------------------
        void Start()
        {
            LoadLevel();
        }

        // --------------------------------------------------------------------------
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                ReloadLevel();
            }
        }

        // --------------------------------------------------------------------------
        private void LoadLevel()
        {
            string fileToParse = $"{Application.dataPath}{"/Resources/"}{filename}.txt";
            Debug.Log($"Loading level file: {fileToParse}");

            Stack<string> levelRows = new Stack<string>();

            // Get each line of text representing blocks in our level
            using (StreamReader sr = new StreamReader(fileToParse))
            {
                string line = "";
                while ((line = sr.ReadLine()) != null)
                {
                    levelRows.Push(line);
                }

                sr.Close();
            }

            // Go through the rows from bottom to top
            int row = 0;
            while (levelRows.Count > 0)
            {
                string currentLine = levelRows.Pop();

                int column = 0;
                char[] letters = currentLine.ToCharArray();
           
                foreach (var letter in letters)
                {
                    // Todo - Instantiate a new GameObject that matches the type specified by letter
                    // Todo - Position the new GameObject at the appropriate location by using row and column
                    // Todo - Parent the new GameObject under levelRoot
                    ///GameObject block = null;
                    if(!letter.Equals(" ")) {
                        switch (letter)
                        {
                        
                            case 's':
                                var block = Instantiate(stonePrefab, environmentRoot);
                                block.transform.position = new Vector3(column, row, 0);
                                break;
                            case '?':
                                var block2 = Instantiate(questionBoxPrefab, environmentRoot);
                                block2.transform.position = new Vector3(column, row, 0);
                                break;
                            case 'b':
                                var block3 = Instantiate(brickPrefab, environmentRoot);
                                block3.transform.position = new Vector3(column, row, 0);
                                break;
                            case 'x':
                                var block4 = Instantiate(rockPrefab, environmentRoot);
                                block4.transform.position = new Vector3(column, row, 0);
                                break;
                            case  'k':
                                var block5 = Instantiate(skwerPrefab, environmentRoot);
                                block5.transform.position = new Vector3(column, row, 0);
                                break;
                            case  'c':
                                var block6 = Instantiate(coinPrefab, environmentRoot);
                                block6.transform.position = new Vector3(column, row, 0);
                                break;
                            case  'g':
                                var block7 = Instantiate(goalPrefab, environmentRoot);
                                block7.transform.position = new Vector3(column, row, 0);
                                break;
                        
                        }

                
                    }
                    column++;
                }
                row++;
            }
        }

        // --------------------------------------------------------------------------
        private void ReloadLevel()
        {
            foreach (Transform child in environmentRoot)
            {
                Destroy(child.gameObject);
            }
            LoadLevel();
        }
    }
}
