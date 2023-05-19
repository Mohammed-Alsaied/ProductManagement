namespace Common
{
    using Common.Dtos;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public abstract class DtoConfiguration<T> : IEntityTypeConfiguration<T>
        where T : BaseDto
    {
        public void Configure(EntityTypeBuilder<T> builder)
        {

        }
    }
}
