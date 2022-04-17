/**
 * @author Igor Frolov <moodtraffic@gmail.com>
 *
 * Программа получает на вход размеры матрицы M x N, далее заполняет от внешнего края
 * по спирали числами от 1 до M x N.
 */

int M = 4; // столбцы
int N = 4; // строки

// кол-во строк
if (args.Length >= 1) {
    N = int.Parse(args[0]);
}

// кол-во столбцов
if (args.Length >= 2) {
    M = int.Parse(args[1]);
}

Matrix matrix = new Matrix(N, M);

matrix.fill();
matrix.print();

public class Matrix
{
    protected const char MOVE_RIGHT = 'r';
    protected const char MOVE_DOWN = 'd';
    protected const char MOVE_LEFT = 'l';
    protected const char MOVE_UP = 'u';

    protected int cols = 0;
    protected int rows = 0;
    protected int number = 0;
    protected int[,] Values;

    // конструктор
    public Matrix(int rows, int cols)
    {
        this.cols = cols;
        this.rows = rows;
        this.Values = new int[rows, cols];
    }

    public void fill(MatrixArea? area = null)
    {
        if (area == null) {
            area = new MatrixArea(0, 0, this.cols -1, this.rows -1);
        }

        if (area.cols < 1 || area.rows < 1) {
            return;
        }

        int steps = 0;
        int x = area.xMin;
        int y = area.yMin;

        if (area.cols == 1 && area.rows == 1) {
            steps = 1;
        } else if (area.cols == 1) {
            steps = area.rows;
        } else if (area.rows == 1) {
            steps = area.cols;
        } else {
            steps = 2* area.cols + 2* area.rows -4;
        }

        // Console.WriteLine($"({x};{y}) {rows}x{cols}");
        // Console.WriteLine($"perimeter = {steps}");
        this.Values[y, x] = this.getNextValue();

        if (steps-- == 1) {
            return;
        }

        do {
            (x, y) = this.move(area, Matrix.MOVE_RIGHT, x, y, ref steps);
            (x, y) = this.move(area, Matrix.MOVE_DOWN, x, y, ref steps);
            (x, y) = this.move(area, Matrix.MOVE_LEFT, x, y, ref steps);
            (x, y) = this.move(area, Matrix.MOVE_UP, x, y, ref steps);
        } while (steps > 0);

        area.crop();

        this.fill(area);
    }

    protected (int, int) move(MatrixArea area, char direction, int x, int y, ref int steps)
    {
        int dx = 0, dy = 0;

        // в данном цикле не осталось шагов
        if (steps == 0) {
            return (x, y);
        }

        // высчитываем смещение
        switch (direction) {
            case Matrix.MOVE_RIGHT:
                dx = (x < area.xMax) ? 1 : 0;
                break;

            case Matrix.MOVE_DOWN:
                dy = (y < area.yMax) ? 1 : 0;
                break;

            case Matrix.MOVE_LEFT:
                dx = (x > area.xMin) ? -1 : 0;
                break;

            case Matrix.MOVE_UP:
                dy = (y > area.yMin) ? -1 : 0;
                break;
        }

        // если есть смещение, то запишем значение и продолжим движение
        if (dx != 0 || dy != 0) {
            --steps;
            x += dx;
            y += dy;

            this.Values[y, x] = this.getNextValue();

            (x, y) = this.move(area, direction, x, y, ref steps);
        }

        return (x, y);
    }

    public void print()
    {
        for (int r = 0; r < this.rows; r++) {
            for (int c = 0; c < this.cols; c++) {
                Console.Write($"{this.Values[r, c], 5}");
            }

            Console.WriteLine();
        }

        Console.WriteLine();
    }

    protected int getNextValue()
    {
        return ++this.number;
    }
}

public class MatrixArea
{
    public int xMin;
    public int yMin;
    public int xMax;
    public int yMax;
    public int cols;
    public int rows;

    // конструктор
    public MatrixArea(int xmin, int ymin, int xmax, int ymax)
    {
        this.xMin = xmin;
        this.yMin = ymin;
        this.xMax = xmax;
        this.yMax = ymax;

        this.cols = this.xMax - this.xMin + 1;
        this.rows = this.yMax - this.yMin + 1;
    }

    public void crop()
    {
        this.xMin += 1;
        this.yMin += 1;
        this.xMax -= 1;
        this.yMax -= 1;

        this.cols -= 2;
        this.rows -= 2;
    }
}
