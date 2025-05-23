﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MomBeatPvz.Persistence;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MomBeatPvz.Persistence.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20250221202239_Adding")]
    partial class Adding
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ChampionshipEntityHeroEntity", b =>
                {
                    b.Property<long>("ChampionshipEntityId")
                        .HasColumnType("bigint");

                    b.Property<int>("HeroesId")
                        .HasColumnType("integer");

                    b.HasKey("ChampionshipEntityId", "HeroesId");

                    b.HasIndex("HeroesId");

                    b.ToTable("ChampionshipEntityHeroEntity");
                });

            modelBuilder.Entity("HeroEntityTeamEntity", b =>
                {
                    b.Property<int>("HeroesId")
                        .HasColumnType("integer");

                    b.Property<long>("TeamEntityId")
                        .HasColumnType("bigint");

                    b.HasKey("HeroesId", "TeamEntityId");

                    b.HasIndex("TeamEntityId");

                    b.ToTable("HeroEntityTeamEntity");
                });

            modelBuilder.Entity("MomBeatPvz.Persistence.Entities.ChampionshipEntity", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnType("bigint");

                    b.Property<long>("CreatorId")
                        .HasColumnType("bigint");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Format")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.Property<int>("Stage")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("StartDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("CreatorId");

                    b.ToTable("Championship", (string)null);
                });

            modelBuilder.Entity("MomBeatPvz.Persistence.Entities.HeroEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Hero", (string)null);
                });

            modelBuilder.Entity("MomBeatPvz.Persistence.Entities.HeroPriceEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("HeroId")
                        .HasColumnType("integer");

                    b.Property<long>("SolutionId")
                        .HasColumnType("bigint");

                    b.Property<int>("Value")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("HeroId");

                    b.HasIndex("SolutionId");

                    b.ToTable("HeroPrice", (string)null);
                });

            modelBuilder.Entity("MomBeatPvz.Persistence.Entities.MatchEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long>("ChampionshipId")
                        .HasColumnType("bigint");

                    b.Property<bool>("IsCompleted")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.HasIndex("ChampionshipId");

                    b.ToTable("Match", (string)null);
                });

            modelBuilder.Entity("MomBeatPvz.Persistence.Entities.MatchResultEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<long>("MatchId")
                        .HasColumnType("bigint");

                    b.Property<double>("Score")
                        .HasColumnType("double precision");

                    b.Property<long>("TeamId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("MatchId");

                    b.HasIndex("TeamId");

                    b.ToTable("MatchResult", (string)null);
                });

            modelBuilder.Entity("MomBeatPvz.Persistence.Entities.TeamEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long>("AuthorId")
                        .HasColumnType("bigint");

                    b.Property<long>("ChampionshipId")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.HasKey("Id");

                    b.HasAlternateKey("AuthorId", "ChampionshipId");

                    b.HasIndex("ChampionshipId");

                    b.ToTable("Team", (string)null);
                });

            modelBuilder.Entity("MomBeatPvz.Persistence.Entities.TierListEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long>("CreatorId")
                        .HasColumnType("bigint");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("MaxPrice")
                        .HasColumnType("integer");

                    b.Property<int>("MinPrice")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("character varying(80)");

                    b.Property<long>("ResultId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("CreatorId");

                    b.HasIndex("ResultId");

                    b.ToTable("TierList", (string)null);
                });

            modelBuilder.Entity("MomBeatPvz.Persistence.Entities.TierListSolutionEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long>("OwnerId")
                        .HasColumnType("bigint");

                    b.Property<long>("TierListId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasAlternateKey("OwnerId", "TierListId");

                    b.HasIndex("TierListId");

                    b.ToTable("TierListSolution", (string)null);
                });

            modelBuilder.Entity("MomBeatPvz.Persistence.Entities.UserEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("character varying(80)");

                    b.HasKey("Id");

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("ChampionshipEntityHeroEntity", b =>
                {
                    b.HasOne("MomBeatPvz.Persistence.Entities.ChampionshipEntity", null)
                        .WithMany()
                        .HasForeignKey("ChampionshipEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MomBeatPvz.Persistence.Entities.HeroEntity", null)
                        .WithMany()
                        .HasForeignKey("HeroesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HeroEntityTeamEntity", b =>
                {
                    b.HasOne("MomBeatPvz.Persistence.Entities.HeroEntity", null)
                        .WithMany()
                        .HasForeignKey("HeroesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MomBeatPvz.Persistence.Entities.TeamEntity", null)
                        .WithMany()
                        .HasForeignKey("TeamEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MomBeatPvz.Persistence.Entities.ChampionshipEntity", b =>
                {
                    b.HasOne("MomBeatPvz.Persistence.Entities.UserEntity", "Creator")
                        .WithMany()
                        .HasForeignKey("CreatorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MomBeatPvz.Persistence.Entities.TierListEntity", "TierList")
                        .WithOne("Championship")
                        .HasForeignKey("MomBeatPvz.Persistence.Entities.ChampionshipEntity", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Creator");

                    b.Navigation("TierList");
                });

            modelBuilder.Entity("MomBeatPvz.Persistence.Entities.HeroPriceEntity", b =>
                {
                    b.HasOne("MomBeatPvz.Persistence.Entities.HeroEntity", "Hero")
                        .WithMany()
                        .HasForeignKey("HeroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MomBeatPvz.Persistence.Entities.TierListSolutionEntity", "Solution")
                        .WithMany("HeroPrices")
                        .HasForeignKey("SolutionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hero");

                    b.Navigation("Solution");
                });

            modelBuilder.Entity("MomBeatPvz.Persistence.Entities.MatchEntity", b =>
                {
                    b.HasOne("MomBeatPvz.Persistence.Entities.ChampionshipEntity", "Championship")
                        .WithMany("Matches")
                        .HasForeignKey("ChampionshipId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Championship");
                });

            modelBuilder.Entity("MomBeatPvz.Persistence.Entities.MatchResultEntity", b =>
                {
                    b.HasOne("MomBeatPvz.Persistence.Entities.MatchEntity", "Match")
                        .WithMany("Results")
                        .HasForeignKey("MatchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MomBeatPvz.Persistence.Entities.TeamEntity", "Team")
                        .WithMany()
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Match");

                    b.Navigation("Team");
                });

            modelBuilder.Entity("MomBeatPvz.Persistence.Entities.TeamEntity", b =>
                {
                    b.HasOne("MomBeatPvz.Persistence.Entities.UserEntity", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MomBeatPvz.Persistence.Entities.ChampionshipEntity", "Championship")
                        .WithMany("Teams")
                        .HasForeignKey("ChampionshipId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("Championship");
                });

            modelBuilder.Entity("MomBeatPvz.Persistence.Entities.TierListEntity", b =>
                {
                    b.HasOne("MomBeatPvz.Persistence.Entities.UserEntity", "Creator")
                        .WithMany()
                        .HasForeignKey("CreatorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MomBeatPvz.Persistence.Entities.TierListSolutionEntity", "Result")
                        .WithMany()
                        .HasForeignKey("ResultId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Creator");

                    b.Navigation("Result");
                });

            modelBuilder.Entity("MomBeatPvz.Persistence.Entities.TierListSolutionEntity", b =>
                {
                    b.HasOne("MomBeatPvz.Persistence.Entities.UserEntity", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MomBeatPvz.Persistence.Entities.TierListEntity", "TierList")
                        .WithMany("Solutions")
                        .HasForeignKey("TierListId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Owner");

                    b.Navigation("TierList");
                });

            modelBuilder.Entity("MomBeatPvz.Persistence.Entities.ChampionshipEntity", b =>
                {
                    b.Navigation("Matches");

                    b.Navigation("Teams");
                });

            modelBuilder.Entity("MomBeatPvz.Persistence.Entities.MatchEntity", b =>
                {
                    b.Navigation("Results");
                });

            modelBuilder.Entity("MomBeatPvz.Persistence.Entities.TierListEntity", b =>
                {
                    b.Navigation("Championship")
                        .IsRequired();

                    b.Navigation("Solutions");
                });

            modelBuilder.Entity("MomBeatPvz.Persistence.Entities.TierListSolutionEntity", b =>
                {
                    b.Navigation("HeroPrices");
                });
#pragma warning restore 612, 618
        }
    }
}
