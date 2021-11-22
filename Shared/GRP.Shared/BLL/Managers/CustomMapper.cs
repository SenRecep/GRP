﻿using GRP.Shared.BLL.Interfaces;

using System.Reflection;

namespace GRP.Shared.BLL.Managers;

public class CustomMapper : ICustomMapper
{
    public T Map<T, D>(D dto, T entity)
    {
        if (dto is null || entity is null) throw new ArgumentNullException();
        PropertyInfo[] entityProperties = entity.GetType().GetProperties();
        PropertyInfo[] dtoTypeProperties = dto.GetType().GetProperties();
        foreach (PropertyInfo dtoProperty in dtoTypeProperties)
        {
            PropertyInfo? entityProperty = entityProperties
                .FirstOrDefault(x =>
                x.Name.Equals(dtoProperty.Name) &&
                dtoProperty.CanRead &&
                x.CanWrite &&
                x.PropertyType.IsPublic &&
                dtoProperty.PropertyType.IsPublic &&
                x.PropertyType.Equals(dtoProperty.PropertyType));

            entityProperty?.SetValue(entity, dtoProperty.GetValue(dto));
        }
        return entity;

    }
}
