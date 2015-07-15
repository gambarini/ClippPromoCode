# ClippPromoCode

Class to generate and validade promocodes from integer numbers.
Requires 10 unique characters key and number max size.

Exemple of codes generated for numbers:

 [0]	    "QDJENUYxRjA1OEAx"	
 [1]	    "QTQ3MkU3UzVENDgy"	
 [2]	    "JDVVNEU0WDE1Mjcz"	
 [3]	    "NTFTMlMwRjVFNUQ2"	
 [4]	    "UzNGNUg0QTdEMzU1"	
 [5]	    "NTFAMUAwJDNKNiQ0"	


## Challenge description:

Clipp is producing 100,000 promotional cards to be handed out to prospective customers. Each card will be printed with a unique code that will be entered during the registration process to track the effectiveness of the campaign.  You are required to write the algorithm to generate the codes.

Requirements:

Write a C# function that accepts a single integer argument and returns a code that represents the number.
- Codes must be unique.
- Codes must appear random so that they are not easily guessable.  Any pattern should not be obvious.
- It must be possible to determine the original integer number from a code using another function.
