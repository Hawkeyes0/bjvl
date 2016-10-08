using System;
using System.Linq;
using System.Reflection;

namespace Net.Bjvl.Models
{
    public abstract class BaseModel<TEntity>
    {
        public void CloneFrom(TEntity other, params string[] skipFields)
        {
            if (other == null)
            {
                throw new NullReferenceException($"The other {nameof(TEntity)} object is null.");
            }

            var properties = typeof(TEntity).GetProperties();

            foreach (var propInfo in properties)
            {
                if (skipFields.Contains(propInfo.Name))
                {
                    continue;
                }
                propInfo.SetValue(this, propInfo.GetValue(other));
            }
        }

    }
}