namespace SnakeGUI
{
    public static class AppSettings
    {
        /// <summary>
        /// Период обновлений изображений
        /// </summary>
        public static int GamePeriod = 100;
        /// <summary>
        /// Кол-во обновлений изображения в шаге змейке
        /// </summary>
        public static int SnakeSpeed = 3;
        /// <summary>
        /// Режим мерцающих границ
        /// </summary>
        public static bool EpilepsyMode = true;
        /// <summary>
        /// Ширина поля
        /// </summary>
        public static int AreaWidth = 45;
        /// <summary>
        /// Высота поля
        /// </summary>
        public static int AreaHeight = 45;
        /// <summary>
        /// Размер изображения для поля с игрой
        /// </summary>
        public static int ImgSize = 850;

/// <summary>
/// Возвращает коэфициент масштабирования изображения
/// </summary>
        public static int GetImgResizeK() =>
            (AreaHeight > AreaWidth) ? ImgSize / (AreaHeight + 2) : ImgSize / (AreaWidth + 2);

    }
}