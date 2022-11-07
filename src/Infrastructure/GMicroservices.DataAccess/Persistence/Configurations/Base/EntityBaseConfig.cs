using GMicroservices.Domain.Daos.Base;
using Microsoft.EntityFrameworkCore;
using GMicroservices.Domain.Abstraction.DataAccess;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GMicroservices.DataAccess.Persistence.Configurations.Base
{
    public class EntityBaseConfig<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : EntityBase, IEntity
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.Property(x => x.Id).HasColumnName("Id");
        }
    }
}
