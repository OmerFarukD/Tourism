using Core.Security.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration;

public class RefreshTokenConfiguration : IEntityTypeConfiguration<RefreshToken>
{
    public void Configure(EntityTypeBuilder<RefreshToken> builder)
    {
        builder.ToTable("RefreshTokens").HasKey(r => r.Id);
        builder.Property(r => r.Id).HasColumnName("id");
        builder.Property(r => r.UserId).HasColumnName("user_id");
        builder.Property(r => r.Token).HasColumnName("token");
        builder.Property(r => r.Expires).HasColumnName("expires");
        builder.Property(r => r.CreatedDate).HasColumnName("created_date");
        builder.Property(r => r.CreatedByIp).HasColumnName("created_by_ip");
        builder.Property(r => r.Revoked).HasColumnName("revoked");
        builder.Property(r => r.RevokedByIp).HasColumnName("revoked_by_ip");
        builder.Property(r => r.ReplacedByToken).HasColumnName("replaced_by_token");
        builder.Property(r => r.ReasonRevoked).HasColumnName("reason_revoked");
        builder.HasOne(r => r.User);
    }
}