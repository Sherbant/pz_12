using UnityEngine;

public abstract class TurnBasedGame : MonoBehaviour
{
    protected char[,] board = new char[3, 3];
    protected char currentPlayer;

    public void PlayTurn(int x, int y)
    {
        if (IsValidMove(x, y))
        {
            MakeMove(x, y);
            if (CheckWinCondition())
            {
                EndGame();
            }
            else
            {
                SwitchPlayer();
            }
        }
        else
        {
            Debug.Log("Неверный ход. Попробуйте снова.");
        }
    }

    protected abstract bool IsValidMove(int x, int y);
    protected abstract void MakeMove(int x, int y);
    protected abstract bool CheckWinCondition();
    protected abstract void EndGame();

    protected virtual void SwitchPlayer()
    {
        currentPlayer = currentPlayer == 'X' ? 'O' : 'X';
    }
}
