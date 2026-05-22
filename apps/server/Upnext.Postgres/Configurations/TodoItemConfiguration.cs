using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Upnext.Domain;

namespace Upnext.Postgres.Configurations;

public class TodoItemConfiguration : IEntityTypeConfiguration<TodoItem>
{
    public void Configure(EntityTypeBuilder<TodoItem> builder)
    {
        builder.HasKey(t => t.Id);

        builder.Property(t => t.Id)
            .HasConversion(t => t.Value, t => TodoItemId.From(t));

        builder.Property(t => t.CreatedAt)
            .HasConversion(d => d.ToUniversalTime(), v => DateTime.SpecifyKind(v, DateTimeKind.Utc))
            .IsRequired();
        
        builder.Property(t => t.UpdatedAt)
            .HasConversion(d => d.ToUniversalTime(), v => DateTime.SpecifyKind(v, DateTimeKind.Utc))
            .IsRequired();
        
        builder.Property(t => t.Name)
            .HasConversion(t => t.Value, t => TodoItemName.Create(t).Value)
            .IsRequired();
        
        builder.Property(t => t.Description)
            .HasConversion(t => t.Value, t => TodoItemDescription.Create(t).Value)
            .IsRequired();
        
        builder.Property(t => t.DueDate)
            .IsRequired();
        
        builder.Property(t => t.Status)
            .IsRequired();
        
        builder.Property(t => t.Priority)
            .IsRequired();
    }
}