/**
 * @author Igor Frolov <moodtraffic@gmail.com>
 *
 * Программа получает на вход размеры матрицы M x N, далее заполняет от внешнего края
 * по спирали числами от 1 до M x N.
 */

int M = 6; // столбцы
int N = 5; // строки

Matrix matrix = new Matrix(N, M);

matrix.fill(0, 0);

public class Matrix
{
    protected int cols = 0;
    protected int rows = 0;
    protected int number = 0;
    protected int[,] Values;

    public Matrix(int cols, int rows)
    {
        this.cols = cols;
        this.rows = rows;
        this.Values = new int[rows, cols];
    }

    public (int, int) fill(int x0, int y0, int? cols = null, int? rows = null)
    {
        int cells = 0;
        int number = 0;

        cols = (cols == null) ? this.cols : cols;
        rows = (rows == null) ? this.rows : rows;

        do {
            number = this.getNextValue();
        } while (++cells < rows * cols);

        return (x0, y0);
    }

    protected int getNextValue()
    {
        return ++this.number;
    }
}
