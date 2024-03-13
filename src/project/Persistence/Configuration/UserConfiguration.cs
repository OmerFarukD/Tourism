using Core.Security.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users").HasKey(x=>x.Id);
        builder.Property(x => x.Id).HasColumnName("user_id");
        builder.Property(x => x.FirstName).HasColumnName("firstname");
        builder.Property(x => x.LastName).HasColumnName("lastname");
        builder.Property(x => x.Email).HasColumnName("email");
        builder.Property(x => x.Status).HasColumnName("status");
        builder.Property(x => x.AuthenticatorType).HasColumnName("auyhenticator_type");
        builder.Property(x => x.PasswordHash).HasColumnName("password_hash");
        builder.Property(x => x.PasswordSalt).HasColumnName("password_salt");
        builder.Property(x => x.CreatedDate).HasColumnName("created_date");
        builder.Property(x => x.UpdatedDate).HasColumnName("updated_date");


        builder.HasMany(x => x.UserOperationClaims);
        builder.HasMany(x => x.RefreshTokens);
        builder.HasMany(x => x.EmailAuthenticators);
        builder.HasMany(x => x.OtpAuthenticators);
    }
}