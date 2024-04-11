namespace TaskManager.Entities
{
    public class User : BaseEntity
    {
        /// <summary>
        /// ��� ������������
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// �����
        /// </summary>
        public string Login { get; set; } = string.Empty;

        /// <summary>
        /// ������
        /// </summary>
        public string Password { get; set; } = string.Empty;

        /// <summary>
        /// ���� � ������ ������������
        /// </summary>
        public string IconPath { get; set; } = string.Empty;
    }
}