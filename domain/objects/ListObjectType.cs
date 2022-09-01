namespace domain.objects
{
    /// <summary>
    /// Тип объекта
    /// </summary>
    public enum ListObjectType: byte
    {
        /// <summary>
        /// Папка
        /// </summary>
        Folder = 0,
        /// <summary>
        /// Чеклист
        /// </summary>
        CheckList = 1,
        /// <summary>
        /// Статья
        /// </summary>
        Article = 2,
    }
}
