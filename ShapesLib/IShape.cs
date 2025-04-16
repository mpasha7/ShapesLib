namespace ShapesLib;

/// <summary>
/// Фигура
/// </summary>
public interface IShape
{
    /// <summary>
    /// Возвращает площадь фигуры
    /// </summary>
    /// <returns>Площадь фигуры</returns>
    double GetArea();

    /// <summary>
    /// Возвращает периметр фигуры
    /// </summary>
    /// <returns>Периметр фигуры</returns>
    double GetPerimeter();
}
