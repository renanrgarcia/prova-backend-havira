using System.ComponentModel.DataAnnotations.Schema;

namespace Havira.Business.Models
{
    public abstract class Entity
    {
        protected Entity()
        {
            Id = Guid.NewGuid();
            CreatedAt = DateTimeOffset.Now.DateTime;
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public void UpdateLog()
        {
            UpdatedAt = DateTimeOffset.Now.DateTime;
        }
    }
}