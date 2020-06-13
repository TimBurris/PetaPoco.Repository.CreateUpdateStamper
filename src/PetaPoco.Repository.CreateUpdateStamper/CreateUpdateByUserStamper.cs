using PetaPoco.Repository.Abstractions;
using PetaPoco.Repository.CreateUpdateStamper.Options;
using System;

namespace PetaPoco.Repository.CreateUpdateStamper
{
    public class CreateUpdateByUserStamper : ICrudRepositoryService
    {
        private readonly CreateUpdateByUserStamperOptions _options;

        public CreateUpdateByUserStamper(CreateUpdateByUserStamperOptions options)
        {
            _options = options;
        }

        #region ICrudRepositoryService

        public void AfterAdd<T, TPrimaryKeyType>(ICrudRepository<T, TPrimaryKeyType> repository, T entity)
        {
        }

        public void AfterRemove<T, TPrimaryKeyType>(ICrudRepository<T, TPrimaryKeyType> repository, TPrimaryKeyType entityId)
        {
        }

        public void AfterUpdate<T, TPrimaryKeyType>(ICrudRepository<T, TPrimaryKeyType> repository, T entity)
        {
        }

        public void BeforeAdd<T, TPrimaryKeyType>(ICrudRepository<T, TPrimaryKeyType> repository, T entity)
        {
            this.TrySetCreatedBy(entity);

        }

        public void BeforeRemove<T, TPrimaryKeyType>(ICrudRepository<T, TPrimaryKeyType> repository, TPrimaryKeyType entityId)
        {
        }

        public void BeforeUpdate<T, TPrimaryKeyType>(ICrudRepository<T, TPrimaryKeyType> repository, T entity)
        {
            this.TrySetUpdatedBy(entity);
        }

        #endregion

        private void TrySetCreatedBy(object entity)
        {
            if (!_options.StampWithCreatedBy) return;

            var p = entity.GetType().GetProperty(_options.CreatedByPropertyName);
            if (p != null)
            {
                p.SetValue(entity, _options.GetUserId());
            }
        }

        private void TrySetUpdatedBy(object entity)
        {
            if (!_options.StampWithUpdatedBy) return;
            var p = entity.GetType().GetProperty(_options.UpdateByPropertyName);
            if (p != null)
            {
                p.SetValue(entity, _options.GetUserId());
            }
        }
    }
}

