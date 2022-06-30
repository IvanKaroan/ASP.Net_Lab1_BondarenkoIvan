namespace Lab2.Data;

/// <summary>
/// Simple POCO class for work with Data
/// </summary>
public class DishOfTheWeek
{
    public DishOfTheWeek ()
    { }

    public DishOfTheWeek (string nameDish, string dayOfWeek, string servingTime, string tipeDish, decimal price)
    {
        NameDish = nameDish;            // Название блюда
        DayOfWeek = dayOfWeek;          // День когда блюдо подаётся
        ServingTime = servingTime;      // Время подачи
        TipeDish = tipeDish;            //
        Price = price;                  //
    }

    // Индетификационный номер блюда
    public Guid Id { get; set; }

    // Название блюда
    public string NameDish { get; set; }

    // День недели когда подаётся блюдо:
    /*              Понедельник
     *              Вторник
     *              Среда
     *              Четверг
     *              Пятница
     *              Суббота
     *              Восскресенье
     * */
    public string DayOfWeek { get; set; }

    // Время приёма пищи: Завтрак, Обед, Ужин
    public string ServingTime { get; set; }

    // тип блюда:
    /*      Суп
     *      Второе
     *      Десерт
     *      Напиток
     *      Закуска
     *      Соус
     * */
    public string TipeDish { get; set; }

    // Цена блюда
    public decimal Price { get; set; }

}
