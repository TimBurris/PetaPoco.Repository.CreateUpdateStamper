using PetaPoco.Repository.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using Moq;

namespace PetaPoco.Repository.CreateUpdateStamperTests
{
    public class TestDatabaseFactory : IDatabaseFactory
    {
        public IDatabase Invoke()
        {
            return new Mock<IDatabase>().Object;
        }
    }

    public class TestRepository : CrudRepositoryBase<TestEntity, int>
    {
        public Abstractions.ICrudRepositoryServiceCollection Services { get; }
        public TestRepository(Abstractions.ICrudRepositoryServiceCollection crudRepositoryServices)
            : base(new TestDatabaseFactory(), crudRepositoryServices)
        {
            this.Services = crudRepositoryServices;
        }
    }

    public class TestEntity
    {


        public int CreatedByUserId { get; set; }
        public int LastUpdatedByUserId { get; set; }

        public DateTime CreatedOnDate { get; set; }
        public DateTime LastUpdatedOnDate { get; set; }
    }
}
