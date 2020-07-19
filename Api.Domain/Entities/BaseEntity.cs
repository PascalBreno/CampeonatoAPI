using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities {
    
    public class BaseEntity {
        [Key]
        public Guid Id { get; set; }
        private DateTime? _createAt;
        public DateTime? CreateAt {
            get { return _createAt; }
            set { _createAt = value ?? DateTime.UtcNow; }
        }

        public DateTime? UpdateAt { private get; set; }
        public DateTime? DateDeletedAt { private get; set; }
        public bool isDeleted { get; set; }
    }
}
