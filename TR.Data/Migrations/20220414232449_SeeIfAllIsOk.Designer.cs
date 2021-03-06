// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TR.Data;

#nullable disable

namespace TR.Data.Migrations
{
    [DbContext(typeof(TRContext))]
    [Migration("20220414232449_SeeIfAllIsOk")]
    partial class SeeIfAllIsOk
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ClientProduct", b =>
                {
                    b.Property<long>("ClientsCIN")
                        .HasColumnType("bigint");

                    b.Property<long>("ProductsProductId")
                        .HasColumnType("bigint");

                    b.HasKey("ClientsCIN", "ProductsProductId");

                    b.HasIndex("ProductsProductId");

                    b.ToTable("ClientProduct");
                });

            modelBuilder.Entity("ProductProvider", b =>
                {
                    b.Property<long>("ProductsProductId")
                        .HasColumnType("bigint");

                    b.Property<long>("ProvidersId")
                        .HasColumnType("bigint");

                    b.HasKey("ProductsProductId", "ProvidersId");

                    b.HasIndex("ProvidersId");

                    b.ToTable("Providings", (string)null);
                });

            modelBuilder.Entity("TR.Domain.Category", b =>
                {
                    b.Property<long>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("CategoryId"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("MyName");

                    b.HasKey("CategoryId");

                    b.ToTable("MyCategories", (string)null);
                });

            modelBuilder.Entity("TR.Domain.Client", b =>
                {
                    b.Property<long>("CIN")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("CIN"), 1L, 1);

                    b.Property<DateTime>("DateNaissance")
                        .HasColumnType("datetime2");

                    b.Property<string>("Mail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prenom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CIN");

                    b.ToTable("Clients", (string)null);
                });

            modelBuilder.Entity("TR.Domain.Facture", b =>
                {
                    b.Property<DateTime>("DateAchat")
                        .HasColumnType("datetime2");

                    b.Property<long>("ClientFk")
                        .HasColumnType("bigint");

                    b.Property<long>("ProductFk")
                        .HasColumnType("bigint");

                    b.Property<float>("Prix")
                        .HasColumnType("real");

                    b.HasKey("DateAchat", "ClientFk", "ProductFk");

                    b.HasIndex("ClientFk");

                    b.HasIndex("ProductFk");

                    b.ToTable("Factures");
                });

            modelBuilder.Entity("TR.Domain.Product", b =>
                {
                    b.Property<long>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("ProductId"), 1L, 1);

                    b.Property<long>("CategoryId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("DateProd")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasDefaultValue("Name")
                        .HasColumnName("MyName");

                    b.Property<long>("Quantity")
                        .HasColumnType("bigint");

                    b.HasKey("ProductId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products", (string)null);
                });

            modelBuilder.Entity("TR.Domain.Provider", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsApproved")
                        .HasColumnType("bit");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Providers");
                });

            modelBuilder.Entity("TR.Domain.Biological", b =>
                {
                    b.HasBaseType("TR.Domain.Product");

                    b.Property<string>("Herbs")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("Biologicals", (string)null);
                });

            modelBuilder.Entity("TR.Domain.Chemical", b =>
                {
                    b.HasBaseType("TR.Domain.Product");

                    b.Property<string>("LabName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("Chemicals", (string)null);
                });

            modelBuilder.Entity("ClientProduct", b =>
                {
                    b.HasOne("TR.Domain.Client", null)
                        .WithMany()
                        .HasForeignKey("ClientsCIN")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TR.Domain.Product", null)
                        .WithMany()
                        .HasForeignKey("ProductsProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProductProvider", b =>
                {
                    b.HasOne("TR.Domain.Product", null)
                        .WithMany()
                        .HasForeignKey("ProductsProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TR.Domain.Provider", null)
                        .WithMany()
                        .HasForeignKey("ProvidersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TR.Domain.Facture", b =>
                {
                    b.HasOne("TR.Domain.Client", "Client")
                        .WithMany("Factures")
                        .HasForeignKey("ClientFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TR.Domain.Product", "Product")
                        .WithMany("Factures")
                        .HasForeignKey("ProductFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("TR.Domain.Product", b =>
                {
                    b.HasOne("TR.Domain.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("TR.Domain.Biological", b =>
                {
                    b.HasOne("TR.Domain.Product", null)
                        .WithOne()
                        .HasForeignKey("TR.Domain.Biological", "ProductId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TR.Domain.Chemical", b =>
                {
                    b.HasOne("TR.Domain.Product", null)
                        .WithOne()
                        .HasForeignKey("TR.Domain.Chemical", "ProductId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.OwnsOne("TR.Domain.Address", "Address", b1 =>
                        {
                            b1.Property<long>("ChemicalProductId")
                                .HasColumnType("bigint");

                            b1.Property<string>("City")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("MyCity");

                            b1.Property<string>("StreetAddress")
                                .IsRequired()
                                .HasMaxLength(50)
                                .HasColumnType("nvarchar(50)")
                                .HasColumnName("MyAddress");

                            b1.HasKey("ChemicalProductId");

                            b1.ToTable("Chemicals");

                            b1.WithOwner()
                                .HasForeignKey("ChemicalProductId");
                        });

                    b.Navigation("Address")
                        .IsRequired();
                });

            modelBuilder.Entity("TR.Domain.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("TR.Domain.Client", b =>
                {
                    b.Navigation("Factures");
                });

            modelBuilder.Entity("TR.Domain.Product", b =>
                {
                    b.Navigation("Factures");
                });
#pragma warning restore 612, 618
        }
    }
}
