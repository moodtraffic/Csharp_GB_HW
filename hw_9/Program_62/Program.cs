/**
 * @author Igor Frolov <moodtraffic@gmail.com>
 *
 * Программа получает на вход размеры матрицы M x N, далее заполняет от внешнего края
 * по спирали числами от 1 до M x N.
 */

int M = 5; // столбцы
int N = 5; // строки

Matrix matrix = new Matrix(N, M);

matrix.fill(0, 0);

public class Matrix
{
    protected int cols = 0;
    protected int rows = 0;
    protected int number = 0;
    protected int[,] Values;

    public Matrix(int rows, int cols)
    {
        this.cols = cols;
        this.rows = rows;
        this.Values = new int[rows, cols];
    }

    public void fill(int x0 = 0, int y0 = 0, int? rows = null, int? cols = null)
    {
        int steps = 0;
        int cells = 0;

        cols = (cols == null) ? this.cols : cols;
        rows = (rows == null) ? this.rows : rows;

        if (cols == 1 && rows == 1) {
            cells = 1;
        } else if (cols == 1) {
            cells = (int)rows;
        } else if (rows == 1) {
            cells = (int)cols;
        } else {
            cells = 2* (int)cols + 2* (int)rows -4;
        }

        Console.WriteLine($"perimeter = {cells}");

        do {
            int number = this.getNextValue();
            Console.WriteLine(number);
        } while (++steps < cells);

        if (rows -2 > 0 && cols -2 > 0) {
            this.fill(x0, y0, rows -2, cols -2);
        }
    }

    protected int getNextValue()
    {
        return ++this.number;
    }
}
