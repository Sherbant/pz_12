using UnityEngine;

public class CellController : MonoBehaviour
{
    private int x, y;
    private TicTacToeGame game;

    public void Setup(int x, int y, TicTacToeGame game)
    {
        this.x = x;
        this.y = y;
        this.game = game;
    }

    void OnMouseDown()
    {
        game.MakePlayerMove(x, y);
    }
}

