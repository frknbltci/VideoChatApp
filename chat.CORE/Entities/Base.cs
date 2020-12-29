using System.ComponentModel.DataAnnotations;

namespace chat.CORE.Entities
{
    public abstract class Base
    {
        [Key]
        public int ID { get; set; }

    }
}
