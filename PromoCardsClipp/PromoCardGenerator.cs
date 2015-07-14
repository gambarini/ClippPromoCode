using System;
using System.Linq;

namespace PromoCardsClipp
{
	public class PromoCardGenerator
	{
		private string _privateKey;

		private int _size;

		public PromoCardGenerator (string privateKey, int size)
		{
			if (privateKey.Length < 10)
				throw new Exception ("privateKey must have at least 10 characters");

			_size = size;
			_privateKey = privateKey;

		}

		public int ExtractNumber (string code)
		{
			char[] flipedKey = FlipKey (_privateKey.ToArray());

			char[] decrypted = code.ToArray ().Select (c => {

				int index = new string (flipedKey).IndexOf (c);

				flipedKey = FlipKey (flipedKey);

				return char.Parse(index.ToString());
			}).ToArray();
				
			return int.Parse(new string(decrypted));
		}

		public string GenerateCode (int number)
		{
			string data = number.ToString ().PadLeft (_size, '0');
			char[] flipedKey = FlipKey (_privateKey.ToArray());

			char[] encrypted = data.ToArray ().Select (c => {

				int i = int.Parse(c.ToString());

				char toCode = GetCharFromKey (i, flipedKey);

				flipedKey = FlipKey(flipedKey);

				return toCode;
					
			}).ToArray();

			return new string (encrypted);
		}

		private char GetCharFromKey(int index, char[] flipedKey){
			return flipedKey [index];
		}

		private char[] FlipKey(char[] toFlip){
			char first = toFlip[0];

			char[] _flipedKey = new char[toFlip.Length];

			_flipedKey [toFlip.Length - 1] = first;

			for (int i = 0; i < toFlip.Length - 1; i++)
				_flipedKey [i] = toFlip [i + 1];

			return _flipedKey;
		}
	}
}

