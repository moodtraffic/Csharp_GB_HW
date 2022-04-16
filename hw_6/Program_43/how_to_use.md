# Program 43

## Use cases

### Case #1 – линии параллельные

Найти пересечение линий:
* y = -3x +3
* y = -3x

```
$ dotnet run -3 3 -3 0
Line #1 => y = -3x +3
Line #2 => y = -3x

Given lines do not intersect, lines are parallel
```

### Case #2 – линии совпадают

Найти пересечение линий:
* y = -3x +3
* y = -3x +3

```
$ dotnet run -3 3 -3 3
Line #1 => y = -3x +3
Line #2 => y = -3x +3

Given lines are the same
```

### Case #3 – линии пересекаются

Найти пересечение линий:
* y = x +2
* y = 3x +4

```
$ dotnet run 1 2 3 4
Line #1 => y = x +2
Line #2 => y = 3x +4

Intersection coords is (-1; 1)
```

### Case #4 – ввели k и b только для первой линии

Найти пересечение линий:
* y = -3x +3
* y = _коэффициент задать вручую_

```
$ dotnet run 3 2
Input k2: 4
Input b2: -1
Line #1 => y = 3x +2
Line #2 => y = 4x -1

Intersection coords is (3; 11)
```

### Case #5

Найти пересечение линий:
* y = x -1
* y = -x +1

```
$ dotnet run 1 -1 -1 1
Line #1 => y = x -1
Line #2 => y = -x +1

Intersection coords is (1; 0)
```

### Case #6

Найти пересечение линий:
* y = -1
* y = -x

```$ dotnet run 0 -1 -1 0
Line #1 => y = -1
Line #2 => y = -x

Intersection coords is (1; -1)
```

### Case #7

Найти пересечение линий:
* y = x
* y = -x

```
$ dotnet run 1 0 -1 0
Line #1 => y = x
Line #2 => y = -x

Intersection coords is (0; 0)
```

### Case #8 – вещественные числа

Найти пересечение линий:
* y = 1.5x -2
* y = -3.5x +5.5

```
$ dotnet run 1,5 -2 -3,5 5,5
Line #1 => y = 1,5x -2
Line #2 => y = -3,5x +5,5

Intersection coords is (1,5; 0,25)
```
