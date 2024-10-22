using UnityEngine;

public class TicTacToeGame : TurnBasedGame
{
    public TicTacToeBoard3D board3D;
    private bool gameEnded = false;

    void Start()
    {
        currentPlayer = 'X'; 
        InitializeBoard();
    }

    private void InitializeBoard()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                board[i, j] = '-'; 
            }
        }
    }

    public void MakePlayerMove(int x, int y)
    {
        if (!gameEnded)
        {
            PlayTurn(x, y);
        }
    }

    protected override bool IsValidMove(int x, int y)
    {
        return board[x, y] == '-'; 
    }

    protected override void MakeMove(int x, int y)
    {
        board[x, y] = currentPlayer; 
        board3D.OnPlayerMove(x, y, currentPlayer); 

        Debug.Log($"Игрок {currentPlayer} делает ход на ({x}, {y}).");
    }

    protected override bool CheckWinCondition()
    {
        for (int i = 0; i < 3; i++)
        {
            if (board[i, 0] == currentPlayer && board[i, 1] == currentPlayer && board[i, 2] == currentPlayer)
                return true;
            if (board[0, i] == currentPlayer && board[1, i] == currentPlayer && board[2, i] == currentPlayer)
                return true;
        }
        if (board[0, 0] == currentPlayer && board[1, 1] == currentPlayer && board[2, 2] == currentPlayer)
            return true;
        if (board[0, 2] == currentPlayer && board[1, 1] == currentPlayer && board[2, 0] == currentPlayer)
            return true;

        return false;
    }

    protected override void EndGame()
    {
        Debug.Log($"Игрок {currentPlayer} побеждает!");
        gameEnded = true;
    }
}
