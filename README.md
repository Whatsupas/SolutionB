# SolutionB
``
Exercise from Kattis testing system. Level - medium
``

Problem:
Kattis is taking one of her kittens out on several hiking trips, and they need to pack their backpacks.
They have a number of items (tents, cooking equipment, food, clothing, etc), and need to split the weight between them as 
evenly as possible. In case the weight can't be split evenly, Kattis will carry the extra weight. Can you
help them split the items between them for each trip?

## Input
Input contains of up to **150** hiking trips. Each trip is given as a line in the input. The line startrs with
1 <= **n** <= 20, the number of items they need to split. Then follows the weight of each item. The weights
are all in the range of [**100**,**600**] grams. End of input is indicated by a linecontaining a single **0**.

## Output
For each trip, output the weights of the two backpacks. Output the weight of the backpack Kattis will carry first

## Sample  
```
Input                                                          Output 
8 529 382 130 462 223 167 235 529                              1344 1313 
12 528 129 376 504 543 363 213 138 206 440 504 418             2181 2181
0
```
