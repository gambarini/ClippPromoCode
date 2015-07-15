using NUnit.Framework;
using System.Collections.Generic;

namespace PromoCardsClipp
{
	[TestFixture]
	public class PromoCardGeneratorTest
	{
		const string testKey1 = "QWERTY1234";
		const string testKey2 = "P5@SA$7DFU8JHEX";
		const int number = 100;
		const string code = "VzFFMVIxWTFZMTEx";

		private class PromoCardGeneratorMock : PromoCardGenerator {
			public PromoCardGeneratorMock (string privateKey, int size) : base(privateKey, size)
			{
				
			}

			protected override int GetFlipFactor ()
			{
				return 1;
			}
		}

		[Test]	
		[ExpectedException(typeof(System.Exception), ExpectedMessage = "privateKey must have at least 10 characters.")]
		public void MinimunCharactersError(){

			var promoGen = new PromoCardGeneratorMock ("A", 6);

		}

		[Test]	
		[ExpectedException(typeof(System.Exception), ExpectedMessage = "Characters in privateKey must be unique.")]
		public void UniqueCharactersError(){

			var promoGen = new PromoCardGeneratorMock ("ABCDEFGHIJKLMNOA", 6);

		}

        [Test]	
		public void NumberToCodeTest(){

			var promoGen = new PromoCardGeneratorMock (testKey1, 6);

			string codeGenerated = promoGen.GenerateCode (number);

			Assert.AreEqual (code, codeGenerated);
		}

		[Test]	
		public void CodeToNumberTest(){

			var promoGen = new PromoCardGeneratorMock (testKey1, 6);

			int numberFromCode = promoGen.ExtractNumber (code);

			Assert.AreEqual (number, numberFromCode);
		}

		[Test]
		public void RangeUniqueTest(){

			var promoGen = new PromoCardGenerator (testKey2, 6);

			var list = new List<string> ();

			for (int i = 0; i < 10000; i++){
				var code = promoGen.GenerateCode (i);
				var number = promoGen.ExtractNumber (code);

				Assert.AreEqual (i, number);
				Assert.IsFalse (list.Contains (code));

				list.Add (code);
			}

			Assert.AreEqual (10000, list.Count);
		}

		[Test]
		public void RangeTest(){

			var promoGen = new PromoCardGenerator (testKey2, 6);

			for (int i = 0; i < 100000; i++){
				var code = promoGen.GenerateCode (i);
				var number = promoGen.ExtractNumber (code);

				Assert.AreEqual (i, number);
			}
		}
	}
}

