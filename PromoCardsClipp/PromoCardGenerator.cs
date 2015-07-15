using System;
using System.Linq;
using System.Text;

namespace PromoCardsClipp
{
	public class PromoCardGenerator
	{
		private string _privateKey;
		private Random random = new Random ();
		private int _size;

		public PromoCardGenerator (string privateKey, int size)
		{
			if (privateKey.Length < 10)
				throw new Exception ("privateKey must have at least 10 characters.");

			ValidadeUniqueCharacters (privateKey);

			_size = size;
			_privateKey = privateKey;

		}

		private void ValidadeUniqueCharacters(string privateKey){
			for (int count = 0; count < privateKey.Length; count++) {
				char ch = privateKey [count];
				int total = privateKey.ToArray ().Count (c => c == ch);

				if (total > 1) throw new Exception ("Characters in privateKey must be unique.");;
			}

			return;
		}

		private char[] GetNewKeyArray(){
			char[] copyKey = new char[_privateKey.Length];
			Array.Copy (_privateKey.ToArray(), copyKey, _privateKey.Length);

			return copyKey;
		}

		protected virtual int GetFlipFactor(){
			return random.Next (0, 9);
		}

		public int ExtractNumber (string code)
		{
			byte[] bCode = Convert.FromBase64String (code);

			code = Encoding.UTF8.GetString (bCode);

			char[] flipedKey = GetNewKeyArray ();

			string decrypted = string.Empty;

			for (int count = 0; count < code.Length; count += 2) {
				char character = code [count];
				int flipFactor = int.Parse(code [count + 1].ToString());

				FlipKey(flipedKey, flipFactor);

				int index = new string (flipedKey).IndexOf (character);
			
				decrypted += index;
			}
				
			return int.Parse(decrypted);
		}

		public string GenerateCode (int number)
		{
			string data = number.ToString ().PadLeft (_size, '0');

			char[] flipedKey = GetNewKeyArray ();

			string encrypted = string.Empty;

			for(int index = 0; index < data.Length; index++){

				int character = int.Parse(data[index].ToString());

				int flipFactor = GetFlipFactor ();

				FlipKey(flipedKey, flipFactor);

				char toCode = GetCharFromKey (character, flipedKey);

				encrypted += toCode.ToString() + flipFactor;
			}

			byte[] bEncrypted = Encoding.UTF8.GetBytes(encrypted);

			return Convert.ToBase64String (bEncrypted);
		}

		private char GetCharFromKey(int index, char[] flipedKey){
			return flipedKey [index];
		}

		private void FlipKey(char[] toFlip, int iterate){
			for (int i = 0; i < iterate; i++)
				deslocateArray (toFlip);
		}

		private void deslocateArray(char[] array){
			char first = array[0];

			for (int i = 0; i < array.Length - 1; i++)
				array [i] = array [i + 1];

			array [array.Length - 1] = first;
		}
	}
}

