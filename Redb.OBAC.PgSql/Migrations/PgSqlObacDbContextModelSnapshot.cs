﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Redb.OBAC.PgSql.Migrations
{
    [DbContext(typeof(PgSqlObacDbContext))]
    partial class PgSqlObacDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Redb.OBAC.EFCore.DAL.ObacGroupSubjectEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnName("description")
                        .HasColumnType("text");

                    b.Property<int?>("ExternalIdInt")
                        .HasColumnName("external_id_int")
                        .HasColumnType("integer");

                    b.Property<string>("ExternalIdString")
                        .HasColumnName("external_id_str")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("obac_user_groups");
                });

            modelBuilder.Entity("Redb.OBAC.EFCore.DAL.ObacObjectTypeEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnName("description")
                        .HasColumnType("text");

                    b.Property<int>("Type")
                        .HasColumnName("type")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("obac_objecttypes");
                });

            modelBuilder.Entity("Redb.OBAC.EFCore.DAL.ObacPermissionEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnName("description")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("obac_permissions");
                });

            modelBuilder.Entity("Redb.OBAC.EFCore.DAL.ObacPermissionRoleEntity", b =>
                {
                    b.Property<Guid>("PermissionId")
                        .HasColumnName("perm_id")
                        .HasColumnType("uuid");

                    b.Property<Guid>("RoleId")
                        .HasColumnName("role_id")
                        .HasColumnType("uuid");

                    b.HasKey("PermissionId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("obac_permissions_in_roles");
                });

            modelBuilder.Entity("Redb.OBAC.EFCore.DAL.ObacRoleEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnName("description")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("obac_roles");
                });

            modelBuilder.Entity("Redb.OBAC.EFCore.DAL.ObacTreeEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnName("id")
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .HasColumnName("description")
                        .HasColumnType("text");

                    b.Property<int?>("ExternalIdInt")
                        .HasColumnName("external_id_int")
                        .HasColumnType("integer");

                    b.Property<string>("ExternalIdString")
                        .HasColumnName("external_id_str")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("obac_trees");
                });

            modelBuilder.Entity("Redb.OBAC.EFCore.DAL.ObacTreeNodeEntity", b =>
                {
                    b.Property<Guid>("TreeId")
                        .HasColumnName("tree_id")
                        .HasColumnType("uuid");

                    b.Property<int>("Id")
                        .HasColumnName("id")
                        .HasColumnType("integer");

                    b.Property<int?>("ExternalIdInt")
                        .HasColumnName("external_id_int")
                        .HasColumnType("integer");

                    b.Property<string>("ExternalIdString")
                        .HasColumnName("external_id_str")
                        .HasColumnType("text");

                    b.Property<bool>("InheritParentPermissions")
                        .HasColumnName("inherit_parent_perms")
                        .HasColumnType("boolean");

                    b.Property<int>("OwnerUserId")
                        .HasColumnName("owner_user_id")
                        .HasColumnType("integer");

                    b.Property<int?>("ParentId")
                        .HasColumnName("parent_id")
                        .HasColumnType("integer");

                    b.HasKey("TreeId", "Id");

                    b.HasIndex("OwnerUserId");

                    b.HasIndex("TreeId");

                    b.HasIndex("TreeId", "ParentId");

                    b.HasIndex("TreeId", "Id", "ParentId");

                    b.ToTable("obac_tree_nodes");
                });

            modelBuilder.Entity("Redb.OBAC.EFCore.DAL.ObacTreeNodePermissionEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("uuid");

                    b.Property<bool>("Deny")
                        .HasColumnName("is_deny")
                        .HasColumnType("boolean");

                    b.Property<int>("NodeId")
                        .HasColumnName("tree_node_id")
                        .HasColumnType("integer");

                    b.Property<Guid>("PermissionId")
                        .HasColumnName("perm_id")
                        .HasColumnType("uuid");

                    b.Property<Guid>("TreeId")
                        .HasColumnName("tree_id")
                        .HasColumnType("uuid");

                    b.Property<int?>("UserGroupId")
                        .HasColumnName("user_group_id")
                        .HasColumnType("integer");

                    b.Property<int?>("UserId")
                        .HasColumnName("user_id")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserGroupId");

                    b.HasIndex("TreeId", "NodeId");

                    b.HasIndex("UserId", "UserGroupId", "TreeId", "NodeId", "PermissionId")
                        .IsUnique();

                    b.ToTable("obac_tree_node_permissions");
                });

            modelBuilder.Entity("Redb.OBAC.EFCore.DAL.ObacUserInGroupEntity", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnName("user_id")
                        .HasColumnType("integer");

                    b.Property<int>("GroupId")
                        .HasColumnName("group_id")
                        .HasColumnType("integer");

                    b.HasKey("UserId", "GroupId");

                    b.HasIndex("GroupId");

                    b.HasIndex("UserId");

                    b.ToTable("obac_users_in_groups");
                });

            modelBuilder.Entity("Redb.OBAC.EFCore.DAL.ObacUserPermissionsEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("uuid");

                    b.Property<int?>("ObjectId")
                        .HasColumnName("objid")
                        .HasColumnType("integer");

                    b.Property<Guid>("ObjectTypeId")
                        .HasColumnName("objtypeid")
                        .HasColumnType("uuid");

                    b.Property<Guid>("PermissionId")
                        .HasColumnName("permid")
                        .HasColumnType("uuid");

                    b.Property<int>("UserId")
                        .HasColumnName("userid")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserId", "ObjectTypeId", "ObjectId");

                    b.HasIndex("UserId", "PermissionId", "ObjectTypeId", "ObjectId")
                        .IsUnique();

                    b.ToTable("obac_userpermissions");
                });

            modelBuilder.Entity("Redb.OBAC.EFCore.DAL.ObacUserSubjectEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnName("description")
                        .HasColumnType("text");

                    b.Property<int?>("ExternalIdInt")
                        .HasColumnName("external_id_int")
                        .HasColumnType("integer");

                    b.Property<string>("ExternalIdString")
                        .HasColumnName("external_id_str")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ExternalIdInt");

                    b.HasIndex("ExternalIdString");

                    b.ToTable("obac_users");
                });

            modelBuilder.Entity("Redb.OBAC.EFCore.DAL.ObacPermissionRoleEntity", b =>
                {
                    b.HasOne("Redb.OBAC.EFCore.DAL.ObacRoleEntity", "Role")
                        .WithMany("Permissions")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Redb.OBAC.EFCore.DAL.ObacTreeNodeEntity", b =>
                {
                    b.HasOne("Redb.OBAC.EFCore.DAL.ObacUserSubjectEntity", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Redb.OBAC.EFCore.DAL.ObacTreeEntity", "Tree")
                        .WithMany()
                        .HasForeignKey("TreeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Redb.OBAC.EFCore.DAL.ObacTreeNodeEntity", "Parent")
                        .WithMany()
                        .HasForeignKey("TreeId", "ParentId");
                });

            modelBuilder.Entity("Redb.OBAC.EFCore.DAL.ObacTreeNodePermissionEntity", b =>
                {
                    b.HasOne("Redb.OBAC.EFCore.DAL.ObacGroupSubjectEntity", "UserGroup")
                        .WithMany()
                        .HasForeignKey("UserGroupId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Redb.OBAC.EFCore.DAL.ObacUserSubjectEntity", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Redb.OBAC.EFCore.DAL.ObacTreeNodeEntity", "Node")
                        .WithMany()
                        .HasForeignKey("TreeId", "NodeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Redb.OBAC.EFCore.DAL.ObacUserInGroupEntity", b =>
                {
                    b.HasOne("Redb.OBAC.EFCore.DAL.ObacGroupSubjectEntity", "Group")
                        .WithMany("Users")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Redb.OBAC.EFCore.DAL.ObacUserSubjectEntity", "User")
                        .WithMany("Groups")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}