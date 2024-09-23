namespace Hr_Management.Domain.Common
{
    public abstract class BaseEntity
    {
        public DateTime DateCreated { get; set; }

        public int CreatedBy { get; set; }

        public DateTime LastModifiedDate { get; set; }
        public int LastModifiedBy { get; set; }
    }

    

}
