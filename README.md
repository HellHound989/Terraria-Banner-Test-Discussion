# Terraria-Banner-Test-Discussion

This is in regards to a simple discussion I had with several players on the Terraria reddit site in regards to the calculations made for players who are using an item called a Banner in the game. The idea is that when this banner buff is active, you get some simple bonuses in combat with the NPC monsters depending on the game mode you are in.

The discussion turned into the following question...
### Is a straight multiplcation or division operation faster than using the bit-shifting hack in C#?

As well, a second question was put forth...
### To increase a player's damage by 50%, is doing a straight floating point equation: f(x) = x * 1.5 faster than this straight integer equation: f(x) = x + (x / 2)

Be aware that in order to do a floating point equation in C#, you have to first cast to a float, then cast your result back to an integer, which are expensive operations.

You can find my [simple discussion here](https://www.reddit.com/r/Terraria/comments/3crwd7/does_anyone_know_the_exact_bonus_you_get_from/csypnyo)

## Final Results

It would appear that in C#, straight multiplication or division on integers vs. using the bit-shifting hack shows no improvement. If we would look at the assembled code, its likely that CIL assembly has the same instructions for both operations.

As for using floating point numbers versus straight integer equations, operation cost appears to be nearly 400% quicker when using just integers over attempting to cast to a float and back
