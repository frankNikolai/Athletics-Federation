﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Athletics_Federation
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class AthleticsFederationDatabaseEntities : DbContext
    {
        public AthleticsFederationDatabaseEntities()
            : base("name=AthleticsFederationDatabaseEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Activity> Activities { get; set; }
        public virtual DbSet<Championship> Championships { get; set; }
        public virtual DbSet<Competition> Competitions { get; set; }
        public virtual DbSet<Gender> Genders { get; set; }
        public virtual DbSet<MainPanelOfJudge> MainPanelOfJudges { get; set; }
        public virtual DbSet<MainPanelOfJudges_Championships> MainPanelOfJudges_Championships { get; set; }
        public virtual DbSet<Participant> Participants { get; set; }
        public virtual DbSet<PersonCompetition> PersonCompetitions { get; set; }
        public virtual DbSet<ResultOfTeamPrimacy> ResultOfTeamPrimacies { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Team> Teams { get; set; }
        public virtual DbSet<User> Users { get; set; }
    }
}