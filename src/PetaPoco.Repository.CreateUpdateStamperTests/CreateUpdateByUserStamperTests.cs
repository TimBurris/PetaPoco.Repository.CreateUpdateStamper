using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;
using System;

namespace PetaPoco.Repository.CreateUpdateStamperTests
{
    [TestClass]
    public class CreateUpdateByUserStamperTests
    {
        private TestRepository _repo = new TestRepository(new CrudRepositoryServiceCollection());
        private int _currentUserId = 13;// this is the user id that we expect to be stamped
        private CreateUpdateStamper.Options.CreateUpdateByUserStamperOptions _options;
        [TestInitialize]
        public void Init()
        {
            _options = new CreateUpdateStamper.Options.CreateUpdateByUserStamperOptions(() => _currentUserId);
            _repo.Services.AddCreateUpdateByUserStamper(_options);

            //assign option defauls, these may get changed depending on individual test needs
            _options.CreatedByPropertyName = nameof(TestEntity.CreatedByUserId);
            _options.UpdateByPropertyName = nameof(TestEntity.LastUpdatedByUserId);
            _options.StampWithCreatedBy = true;
            _options.StampWithUpdatedBy = true;
        }

        [TestMethod]
        public void repo_add_sets_createdbyuserid()
        {
            //*************  arrange  ******************
            //*************    act    ******************
            var result = _repo.Add(new TestEntity());

            //*************  assert   ******************
            result.CreatedByUserId.Should().Be(_currentUserId);

        }

        [TestMethod]
        public void repo_add_does_not_set_createdbyuserid_when_option_off()
        {
            //*************  arrange  ******************
            var id = 8675309;
            _options.StampWithCreatedBy = false;

            //*************    act    ******************
            var result = _repo.Add(new TestEntity() { CreatedByUserId = id });

            //*************  assert   ******************
            result.CreatedByUserId.Should().Be(id);
        }

        [TestMethod]
        public void repo_add_ignores_updateddbyuserid()
        {
            //*************  arrange  ******************
            var id = 8675309;
            //*************    act    ******************
            var result = _repo.Add(new TestEntity() { LastUpdatedByUserId = id });

            //*************  assert   ******************
            result.LastUpdatedByUserId.Should().Be(id);

        }

        [TestMethod]
        public void repo_update_sets_updatedbyuserid()
        {
            //*************  arrange  ******************
            //*************    act    ******************
            var result = _repo.Update(new TestEntity());

            //*************  assert   ******************
            result.LastUpdatedByUserId.Should().Be(_currentUserId);

        }

        [TestMethod]
        public void repo_update_does_not_set_updatedbyuserid_when_option_off()
        {
            //*************  arrange  ******************
            var id = 8675309;
            _options.StampWithUpdatedBy = false;

            //*************    act    ******************
            var result = _repo.Update(new TestEntity() { LastUpdatedByUserId = id });

            //*************  assert   ******************
            result.LastUpdatedByUserId.Should().Be(id);
        }

        [TestMethod]
        public void repo_update_ignores_createddbyuserid()
        {
            //*************  arrange  ******************
            var id = 8675309;
            //*************    act    ******************
            var result = _repo.Update(new TestEntity() { CreatedByUserId = id });

            //*************  assert   ******************
            result.CreatedByUserId.Should().Be(id);

        }
    }
}
