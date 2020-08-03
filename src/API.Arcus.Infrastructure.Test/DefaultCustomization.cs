using AutoFixture;
using AutoFixture.AutoMoq;

namespace API.Arcus.Infrastructure.Test
{
	public class DefaultCustomization : CompositeCustomization
	{
		public DefaultCustomization() : base(new AutoMoqCustomization())
		{
		}
	}
}
