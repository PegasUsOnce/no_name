namespace domain.objects
{
    /// <summary>
    /// Репозиторий объектов
    /// </summary>
    public interface IListObjectRepository
    {
        /// <summary>
        /// Добавление объекта
        /// </summary>
        /// <param name="item">Объект</param>
        void AddObject(ListObject item);
        /// <summary>
        /// Удаление объекта и все вложенных
        /// </summary>
        /// <param name="itemId">Идентификатор объекта</param>
        void RemoveObject(int itemId);
    }
}
