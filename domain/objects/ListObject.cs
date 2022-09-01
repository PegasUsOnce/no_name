namespace domain.objects
{
    /// <summary>
    /// Объект (список или папка)
    /// </summary>
    public class ListObject
    {
        /// <summary>
        /// Идентификатор объекта
        /// </summary>
        public int Id { get; init; }
        /// <summary>
        /// Идентификатор объекта-родителя
        /// </summary>
        public int ParentId { get; init; }
        /// <summary>
        /// Наименование
        /// </summary>
        public string Name { get; init; }
        /// <summary>
        /// Описание
        /// </summary>
        public string Description { get; init; }
        /// <summary>
        /// Тип объекта
        /// </summary>
        public ListObjectType ObjectType { get; init; }
    }
}
