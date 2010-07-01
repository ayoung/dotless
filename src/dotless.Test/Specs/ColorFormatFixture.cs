namespace dotless.Test.Specs
{
	using NUnit.Framework;
	
	public class ColorFormatFixture : ColorFormatHexFixtureBase
	{
		[Test]
		public void Overflow()
		{
			AssertExpression("#00ff00", "#00ee00 + #009900");
			AssertExpression("#ff0000", "#ee0000 + #990000");
		}
	}
}
