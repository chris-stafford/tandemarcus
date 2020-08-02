using System;
using AutoMapper;

namespace API.Arcus.Infrastructure.Mapping
{
	public static class AutoMapperExtensions
	{
		class Resolver : IMemberValueResolver<object, object, object, object>
		{
			public object Resolve(object source, object destination, object sourceMember, object destinationMember, ResolutionContext context)
			{
				return sourceMember ?? destinationMember;
			}
		}

		// this is to solve a bug with AutoMapper where patching with nullable value types results in default values being copied
		public static void IgnoreSourceWhenNull(this IMapperConfigurationExpression cfg)
		{
			cfg.ForAllPropertyMaps(pm =>
			{
				if (pm.SourceMember != null && (pm.DestinationMember.Name != pm.SourceMember.Name))
				{
					return false;
				}

				if (pm.SourceType == null)
				{
					return false;
				}

				var isNullable = pm.SourceType.IsGenericType && (pm.SourceType.GetGenericTypeDefinition() == typeof(Nullable<>));

				return isNullable || pm.SourceType.IsValueType || pm.SourceType.IsPrimitive;
			}, (pm, c) =>
			{
				c.MapFrom<Resolver, object>(pm.SourceMember.Name);
			});
		}
	}
}