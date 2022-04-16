/**
 * @author Igor Frolov <moodtraffic@gmail.com>
 *
 * Программа для поиска коориднат пересечению двух прямых в 2D плоскости
 */

// линия задается выражением [[y = kx + b]], со-но индекс 0 - это b, индекс 1 - это k
double[] line1, line2 = new double[2];

(line1, line2) = readLines(args);

try {
    Console.WriteLine("Line #1 => " + printFormula(line1));
    Console.WriteLine("Line #2 => " + printFormula(line2));
    Console.WriteLine();

    // точка пересечения (x; y)
    (double x, double y) = calcLinesMergeCoord(line1, line2);

    Console.WriteLine($"Intersection coords is ({x}; {y})");
} catch (Exception e) {
    Console.WriteLine(e.Message);
}

Console.WriteLine();

(double, double) calcLinesMergeCoord(double[] line1, double [] line2)
{
    double x, y;

    // задано два уравнения
    // y = k1 * x + b1
    // y = k2 * x + b2

    // вычтем второе из первого
    // k1 * x - k2 * x + b1 - b2 = 0

    // и выразим x
    // x = (b2 - b1) / (k1 - k2)

    // линии пересекутся если угол наклона у них разный, т.е. разница коэффициентов при x ≠ 0
    // со-но и делить на 0 нельзя

    if (0 == line1[1] - line2[1]) {
        // если так же совпадают коэффициенты при свободном члене, то линии идентичны
        if (line1[0] == line2[0]) {
            throw new Exception("Given lines are the same");
        }

        throw new Exception("Given lines do not intersect, lines are parallel");
    }

    x = (line2[0] - line1[0]) / (line1[1] - line2[1]);
    y = line1[0] + line1[1] * x;

    return (x, y);
}

(double[], double[]) readLines(string[] args)
{
    double[] line1 = new double[2];
    double[] line2 = new double[2];

    if (args.Length >= 1) {
        line1[1] = double.Parse(args[0]);
    } else {
        Console.Write("Input k1: ");
        line1[1] = Convert.ToDouble(Console.ReadLine());
    }

    if (args.Length >= 2) {
        line1[0] = double.Parse(args[1]);
    } else {
        Console.Write("Input b1: ");
        line1[0] = Convert.ToDouble(Console.ReadLine());
    }

    if (args.Length >= 3) {
        line2[1] = double.Parse(args[2]);
    } else {
        Console.Write("Input k2: ");
        line2[1] = Convert.ToDouble(Console.ReadLine());
    }

    if (args.Length >= 4) {
        line2[0] = double.Parse(args[3]);
    } else {
        Console.Write("Input b2: ");
        line2[0] = Convert.ToDouble(Console.ReadLine());
    }

    return (line1, line2);
}

string printFormula(double[] line)
{
    int size = line.Length;

    if (size < 1) {
        return "y = 0";
    }

    string formula = "";
    bool isFirst = true;

    for (int i = size - 1; i >= 0; i--) {
        formula = formula + printFormulaMember(i, line[i], ref isFirst);
    }

    return $"y = {formula}";
}

string printFormulaMember(int i, double k, ref bool isFirst)
{
    if (k == 0) {
        return "";
    }

    string sign = (k > 0)
        ? (isFirst ? ""  : " +")
        : (isFirst ? "-" : " -");

    k = Math.Abs(k);
    isFirst = false;

    string member = (k == 1 && i != 0) ? sign : $"{sign}{k}";

    if (i > 1) {
        return $"{member}x^{i}";
    } else if (i == 1) {
        return $"{member}x";
    }

    return member;
}
