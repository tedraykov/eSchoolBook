using System.ComponentModel;

namespace SchoolBook.BusinessLogicLayer.DTOs.Enums
{
    public enum Grades
    {
        [Description("Слаб")] Slab = 2,
        [Description("Среден")] Sreden = 3,
        [Description("Добър")] Dobur = 4,
        [Description("Много добър")] Mnogo_dobur = 5,
        [Description("Отличен")] Otlichen = 6
    
    }
}