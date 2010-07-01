namespace dotless.Test
{
	using Core.Parser.Infrastructure;
	using NUnit.Framework;
	using Core.Engine;
	
	public class ColorFormatHexFixtureBase : SpecFixtureBase
	{
		[SetUp]
		public void Setup()
		{
			DefaultEnv = () => new Env { ColorFormat = ColorFormat.Hex };
		}
	}
}
