namespace ShapesLib;

/// <summary>
/// Круг
/// </summary>
public class Circle : IShape
{
    /// <summary>
    /// Радиус круга
    /// </summary>
    private double radius;
    /// <summary>
    /// Радиус круга
    /// </summary>
    /// <exception cref="ArgumentException">Если радиус не больше 0</exception>
    public double Radius 
    { 
        get => radius; 
        set
        {
            if (value > 0)
                radius = value;
            else
                throw new ArgumentException("Радиус должен быть больше 0", nameof(radius));
        } 
    }

    /// <summary>
    /// Инициализирует объект класса Circle по его радиусу
    /// </summary>
    /// <param name="radius">Радиус круга</param>
    /// <exception cref="ArgumentException">Если радиус не больше 0</exception>
    public Circle(double radius)
    {
        try
        {
            Radius = radius;
        }
        catch (ArgumentException)
        {
            throw;
        }
    }

    /// <summary>
    /// Возвращает площадь круга
    /// </summary>
    /// <returns>Площадь круга</returns>
    public double GetArea()
    {
        return Math.PI * Radius * Radius;
    }

    /// <summary>
    /// Возвращает периметр круга (длину окружности)
    /// </summary>
    /// <returns>Периметр круга</returns>
    public double GetPerimeter()
    {
        return 2 * Math.PI * Radius;
    }
}
