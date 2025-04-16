namespace ShapesLib;

/// <summary>
/// Многоугольник
/// </summary>
public abstract class Polygon : IShape
{
    /// <summary>
    /// Список сторон многоугольника
    /// </summary>
    public List<double> Sides { get; protected set; }

    /// <summary>
    /// Инициирует объект класса Polygon по его сторонам (абстрактно)
    /// </summary>
    /// <param name="sides">Стороны многоугольника</param>
    /// <exception cref="ArgumentException">Если многоугольник с заданными сторонами невозможен</exception>
    public Polygon(params double[] sides)
    {
        try
        {
            CheckSides(sides);
            Sides = new List<double>(sides);
        }
        catch (ArgumentException)
        {
            throw;
        }
    }

    /// <summary>
    /// Возвращает площадь многоугольника
    /// </summary>
    /// <returns>Площадь многоугольника</returns>
    public abstract double GetArea();

    /// <summary>
    /// Возвращает периметр многоугольника
    /// </summary>
    /// <returns>Периметр многоугольника</returns>
    public double GetPerimeter()
    {
        return Sum(Sides, 0);
    }

    /// <summary>
    /// Пытается установить размер заданной стороны многоугольника
    /// </summary>
    /// <param name="index">Индекс стороны многоугольника</param>
    /// <param name="value">Новый размер стороны многоугольника</param>
    /// <returns>Удалось ли установить новый размер стороны</returns>
    public bool TrySetSide(int index, double value)
    {
        try
        {
            CheckSide(index, value);
            Sides[index] = value;
            return true;
        }
        catch (ArgumentOutOfRangeException)
        {
            return false;
        }
        catch (ArgumentException)
        {
            return false;
        }
    }

    /// <summary>
    /// Проверка, можно ли придать стороне многоугольника указанный размер
    /// </summary>
    /// <param name="index">Индекс стороны многоугольника</param>
    /// <param name="value">Новый размер стороны многоугольника</param>
    /// <exception cref="ArgumentOutOfRangeException">Если стороны с таким индексом нет</exception>
    /// <exception cref="ArgumentException">Если данной стороне нельзя придать указанный размер</exception>
    protected void CheckSide(int index, double value)
    {
        if (index < 0 || index >= Sides.Count)
        {
            throw new ArgumentOutOfRangeException(nameof(index));
        }
        if (value <= 0)
        {
            throw new ArgumentException($"Сторона многоугольника должна быть положительным числом", nameof(value));
        }

        double[] sides = Sides.ToArray();
        sides[index] = value;
        Array.Sort(sides);
        if (Sum(sides, 1) < sides[^1])
        {
            throw new ArgumentException($"{index}-я сторона не может иметь размер {value}");
        }
    }

    /// <summary>
    /// Проверка, можно ли создать многоугольник по заданным сторонам
    /// </summary>
    /// <param name="values">Размеры сторон многоугольника</param>
    /// <exception cref="ArgumentException">Если многоугольник с заданными сторонами невозможен</exception>
    protected void CheckSides(params double[] values)
    {
        foreach (double value in values)
        {
            if (value <= 0)
                throw new ArgumentException("Все стороны многоугольника должны быть положительными числами");
        }

        double[] sides = values.ToArray();
        Array.Sort(sides);
        if (Sum(sides, 1) < sides[^1])
        {
            throw new ArgumentException("Одна из сторон больше суммы остальных сторон");
        }
    }

    /// <summary>
    /// Возвращает сумму элементов массива без учета последних offset элементов
    /// </summary>
    /// <param name="values">Массив элементов</param>
    /// <param name="offset">Количество неучитываемых элементов в конце массива</param>
    /// <returns>Сумма заданных элементов массива</returns>
    /// <exception cref="ArgumentNullException">Если список values = null</exception>
    /// <exception cref="ArgumentException">Если offset < 0</exception>
    protected double Sum(IList<double> values, int offset)
    {
        if (values == null)
        {
            throw new ArgumentNullException(nameof(values));
        }
        if (offset < 0)
        {
            throw new ArgumentException($"Аргумент должен быть положительным числом", nameof(offset));
        }
        double sum = 0;
        for (int i = 0; i < values.Count - offset; i++)
        {
            sum += values[i];
        }
        return sum;
    }
}
