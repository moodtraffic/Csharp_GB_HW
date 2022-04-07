/**
 * @author Igor Frolov <moodtraffic@gmail.com>
 *
 * Принимает координаты двух точек в 3D,
 * счмтает и выводит расстояние между ними
 */

// простой вариант хранения координат, можно сделать структура вида Coord{x: double, y: double, z: double}
double[] A = {0, 0, 0};
double[] B = {0, 0, 0};

string? coord; // при запуска ругается что знаение может быть NULL - добавил проверку

/**
    Немного не красиво при вводе координат, можно улучшить:
    - через цикл, чтобы не писать 6 раз `coord == null ? 0 : double.Parse(coord);`
    - через регулярное выражение, чтобы вводить координаты вида `1.23 4.56 7.89`
*/

Console.Write("Inout x of A: ");
coord = Console.ReadLine();
A[0] = coord == null ? 0 : double.Parse(coord);

Console.Write("input y of A: ");
coord = Console.ReadLine();
A[1] = coord == null ? 0 : double.Parse(coord);

Console.Write("input z of A: ");
coord = Console.ReadLine();
A[2] = coord == null ? 0 : double.Parse(coord);

Console.WriteLine();

Console.Write("Inout x of B: ");
coord = Console.ReadLine();
B[0] = coord == null ? 0 : double.Parse(coord);

Console.Write("input y of B: ");
coord = Console.ReadLine();
B[1] = coord == null ? 0 : double.Parse(coord);

Console.Write("input z of B: ");
coord = Console.ReadLine();
B[2] = coord == null ? 0 : double.Parse(coord);

double length = calcDistanceBetweenPoints3D(A, B);

Console.WriteLine($"A ({A[0]}; {A[1]}; {A[2]})");
Console.WriteLine($"B ({B[0]}; {B[1]}; {B[2]})");
Console.WriteLine();
Console.WriteLine($"|AB| = {length}");
Console.WriteLine();

double calcDistanceBetweenPoints3D(double[] A, double[] B, int precision = 3)
{
    double length = 0;

    for (int i = 0; i < 2; i++) {
        length = length + Math.Pow(B[i] - A[i], 2);
    }

    return Math.Round(Math.Sqrt(length), precision);
}
