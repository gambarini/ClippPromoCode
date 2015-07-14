using NUnit.Framework;

namespace PromoCardsClipp
{
	[TestFixture]
	public class PromoCardGeneratorTest
	{
		const string testKey1 = "QWERTY1234";
		const string testKey2 = "P5@SA$7DFU8JH";
		const int number = 100;
		const string code = "WERYY1";

        [Test]	
		public void NumberToCodeTest(){

			var promoGen = new PromoCardGenerator (testKey1, 6);

			string codeGenerated = promoGen.GenerateCode (number);

			Assert.AreEqual (code, codeGenerated);
		}

		[Test]	
		public void CodeToNumberTest(){

			var promoGen = new PromoCardGenerator (testKey1, 6);

			int numberFromCode = promoGen.ExtractNumber (code);

			Assert.AreEqual (number, numberFromCode);
		}

		[Test]
		public void RangeTest(){

			var promoGen = new PromoCardGenerator (testKey2, 6);

			for (int i = 0; i <= 100000; i++){
				var code = promoGen.GenerateCode (i);
				var number = promoGen.ExtractNumber (code);
				System.Diagnostics.Debug.WriteLine (i + " - " + code);
				Assert.AreEqual (i, number);

			}
		}
	}
}

