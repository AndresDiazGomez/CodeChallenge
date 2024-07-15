# Evolutive Algorithm

In this exercise, we are going to implement an evolutionary algorithm. The steps are described below:

- Start with a random string of 26 characters.
- Make 50 copies of the initial string, considering that each character in the copied string has a 3% probability of being replaced by a new random character.
- Compare each of the 50 generated strings with the text "MVM INGENIERIA DE SOFTWARE" and assign a score to each string.
  - The score corresponds to the number of characters in the copied string that match the text "MVM INGENIERIA DE SOFTWARE"
  - For example the score for the string "MVA INGENIKRIA DE SOHTWARO" is 22 (there are 4 incorrect characters out of the 26).
- If any of the generated strings has a perfect score (26 points), the algorithm ends.
- Otherwise, take the string (among the 50 generated) with the highest score and return to step 2, using that string as the starting point.
- Each iteration of this algorithm is known as a Generation. You need to display the string with the highest score of each generation on the screen.
- For the purposes of this algorithm, a character is any uppercase letter or a blank space.
- The correct characters of each generation are not locked, meaning a correct character could become incorrect in subsequent generations.

## Example

- Generation: 1 - Mutation: LQCXM GFZOFEBVXCZKXWQFQDAV - Score: 1
- Generation: 2 - Mutation: LQCXM GFZOFEBV CZKXWQFQDAV - Score: 2
- Generation: 3 - Mutation: LQCXM GFZOFEBA CZKXWQFQDAV - Score: 3
- Generation: 4 - Mutation: LQCXM GFZOFEBA CZKXWQFQDAN - Score: 3
- ...
- Generation: 10 - Mutation: MQMXM GFZOFCBA CE SWQFQDQE - Score: 9
- Generation: 11 - Mutation: MQMXM GFZOFCBA CE SWQTQDQE - Score: 10
- Generation: 12 - Mutation: MQMXM GFZOFCBA CE SWQTQDQE - Score: 10
- ...
- Generation: 148 - Mutation: MVM IWGENIERIA DE SOFTWARE - Score: 25
- Generation: 149 - Mutation: MVM IWGENIERIA DE SOFTWARE - Score: 25
- Generation: 150 - Mutation: MVM INGENIERIA DE SOFTWARE - Score: 26
