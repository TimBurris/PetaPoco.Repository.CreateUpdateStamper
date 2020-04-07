using PetaPoco.Repository.Abstractions;
using PetaPoco.Repository.CreateUpdateStamper.Options;
using System;

namespace PetaPoco.Repository.CreateUpdateStamper
{
    public class CreateUpdateDateStamper : ICrudRepositoryService
    {
        private readonly CreateUpdateDateStamperOptions _options;

        public CreateUpdateDateStamper(CreateUpdateDateStamperOptions options)
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
            this.TrySetCreatedDate(entity);
        }

        public void BeforeRemove<T, TPrimaryKeyType>(ICrudRepository<T, TPrimaryKeyType> repository, TPrimaryKeyType entityId)
        {
        }

        public void BeforeUpdate<T, TPrimaryKeyType>(ICrudRepository<T, TPrimaryKeyType> repository, T entity)
        {
            this.TrySetUpdatedDate(entity);
        }

        #endregion

        private void TrySetCreatedDate(object entity)
        {
            if (!_options.StampWithCreatedOn) return;

            var p = entity.GetType().GetProperty(_options.CreatedOnPropertyName);
            if (p != null)
            {
                p.SetValue(entity, this.GetDateTime());
            }
        }

        private void TrySetUpdatedDate(object entity)
        {
            if (!_options.StampWithUpdatedOn) return;

            var p = entity.GetType().GetProperty(_options.UpdateOnPropertyName);
            if (p != null)
            {
                p.SetValue(entity, this.GetDateTime());
            }
        }

        private DateTime GetDateTime()
        {
            if (_options.UseUtc)
            {
                return DateTime.UtcNow;
            }
            else
            {
                return DateTime.Now;
            }
        }
    }
}

