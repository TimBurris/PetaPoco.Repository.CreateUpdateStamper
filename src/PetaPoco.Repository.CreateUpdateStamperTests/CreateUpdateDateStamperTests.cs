using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;
using System;

namespace PetaPoco.Repository.CreateUpdateStamperTests
{
    [TestClass]
    public class CreateUpdateDateStamperTests
    {
        private TestRepository _repo = new TestRepository(new CrudRepositoryServiceCollection());
        private CreateUpdateStamper.Options.CreateUpdateDateStamperOptions _options = new CreateUpdateStamper.Options.CreateUpdateDateStamperOptions();

        [TestInitialize]
        public void Init()
        {
            _repo.Services
                .AddCreateUpdateDateStamper(_options);

            //assign option defauls, these may get changed depending on individual test needs
            _options.CreatedOnPropertyName = nameof(TestEntity.CreatedOnDate);
            _options.UpdateOnPropertyName = nameof(TestEntity.LastUpdatedOnDate);
            _options.StampWithCreatedOn = true;
            _options.StampWithUpdatedOn = true;
        }

        [TestMethod]
        public void repo_add_sets_createdondate()
        {
            //*************  arrange  ******************
            var timeAtStart = DateTime.Now;
            //*************    act    ******************
            var result = _repo.Add(new TestEntity());

            //*************  assert   ******************
            result.CreatedOnDate.Should().BeOnOrAfter(timeAtStart);

        }

        [TestMethod]
        public void repo_add_does_not_set_createdondate_when_option_off()
        {
            //*************  arrange  ******************
            var date = new DateTime(month: 1, day: 1, year: 2000);
            _options.StampWithCreatedOn = false;

            //*************    act    ******************
            var result = _repo.Add(new TestEntity() { CreatedOnDate = date });

            //*************  assert   ******************
            result.CreatedOnDate.Should().Be(date);
        }

        [TestMethod]
        public void repo_add_ignores_updateddondate()
        {
            //*************  arrange  ******************
            var date = new DateTime(month: 1, day: 1, year: 2000);
            //*************    act    ******************
            var result = _repo.Add(new TestEntity() { LastUpdatedOnDate = date });

            //*************  assert   ******************
            result.LastUpdatedOnDate.Should().Be(date);

        }

        [TestMethod]
        public void repo_update_sets_updatedondate()
        {
            //*************  arrange  ******************
            var timeAtStart = DateTime.Now;
            //*************    act    ******************
            var result = _repo.Update(new TestEntity());

            //*************  assert   ******************
            result.LastUpdatedOnDate.Should().BeOnOrAfter(timeAtStart);

        }

        [TestMethod]
        public void repo_update_does_not_set_updatedondate_when_option_off()
        {
            //*************  arrange  ******************
            var date = new DateTime(month: 1, day: 1, year: 2000);
            _options.StampWithUpdatedOn = false;

            //*************    act    ******************
            var result = _repo.Update(new TestEntity() { LastUpdatedOnDate = date });

            //*************  assert   ******************
            result.LastUpdatedOnDate.Should().Be(date);
        }

        [TestMethod]
        public void repo_update_ignores_createddondate()
        {
            //*************  arrange  ******************
            var date = new DateTime(month: 1, day: 1, year: 2000);
            //*************    act    ******************
            var result = _repo.Update(new TestEntity() { CreatedOnDate = date });

            //*************  assert   ******************
            result.CreatedOnDate.Should().Be(date);

        }
    }
}
