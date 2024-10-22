using UnityEngine;

public class TicTacToeBoard3D : MonoBehaviour
{
    public GameObject cellPrefab;  
    private GameObject[,] cells = new GameObject[3, 3];
    public float cellSize = 2.0f;
    public TicTacToeGame game;

    void Start()
    {
        GenerateBoard();
    }

    void GenerateBoard()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                Vector3 position = new Vector3(i * cellSize, 0, j * cellSize);
                Quaternion rotation = Quaternion.Euler(90, 0, 0); 

                cells[i, j] = Instantiate(cellPrefab, position, rotation); 
                cells[i, j].GetComponent<CellController>().Setup(i, j, game);
            }
        }
    }


    public void OnPlayerMove(int x, int y, char currentPlayer)
    {
        if (cells[x, y] != null)
        {
            if (currentPlayer == 'X')
            {
                cells[x, y].GetComponent<Renderer>().material.color = Color.red;
            }
            else
            {
                cells[x, y].GetComponent<Renderer>().material.color = Color.blue;
            }
        }
    }
}
